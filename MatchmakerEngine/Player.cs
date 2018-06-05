using System.Collections.Generic;

namespace MatchmakerEngine {
    public class Player {
        /// <summary>Gained rating in a completely fair match for average contribution.</summary>
        public static float MedianGain = .005f;
        /// <summary>New players have this level of skill. Should be lower than the average, as they usually don't have average skills.</summary>
        public static float RedistributionCenter = .4f;

        /// <summary>Actual skill level earned.</summary>
        public float SkillRating { get; private set; }
        /// <summary>Adjusted target skill rating next round.</summary>
        public float MatchmakingRating { get; private set; }

        /// <summary>Maximum rating difference while queueing near this player, based on time in queue.</summary>
        internal float QueueRange;

        public enum Results { Win, Draw, Loss }

        public enum MatchTypes {
            /// <summary>Not ranked matches, but balance by the player's current mood is needed.</summary>
            LowStakes,
            /// <summary>The average ranked match.</summary>
            HighStakes,
            /// <summary>Ranked matches to determine the player's skill level faster.</summary>
            Placement
        }

        public Player() {
            SkillRating = MatchmakingRating = RedistributionCenter;
        }

        public Player(float SkillRating, float MatchmakingRating) {
            this.SkillRating = SkillRating;
            this.MatchmakingRating = MatchmakingRating;
        }

        /// <summary>Handle match results for an individual player and calculate his new ratings.</summary>
        /// <param name="TeamSkill">The players' team's average skill rating, including the player</param>
        /// <param name="OpponentSkill">All opponents' average skill rating</param>
        /// <param name="Contribution">Individual player performance, [0;1].</param>
        /// <param name="Result">Match outcome</param>
        /// <param name="MatchType">Ranking weight modifier</param>
        public void Evaluate(float TeamSkill, float OpponentSkill, float Contribution, Results Result, MatchTypes MatchType) {
            // TODO: Win chance must be a factor for non-team games, but it is not required for teams, as it doesn't change their contribution to their own team.
            //float WinChance = MMath.Clamp01(OpponentSkill / TeamSkill);

            // Contribution is weighted with skill difference, this has many advantages:
            // - If the player is much more skilled than the team, he'll go up the ranks faster.
            // - If the player deserved this high rank, but has a bad day, deranking will be slower.
            // - If the player constantly fails to deliver an expected contribution for his level, he'll go down fast.
            if (TeamSkill != 0)
                Contribution = Mathf.Clamp01(MatchmakingRating / TeamSkill * Contribution);
            float TeamContribBonus = Contribution * MedianGain * 2;
            if (Result == Results.Win)
                SkillRating = Mathf.Clamp01(SkillRating + TeamContribBonus);
            else if (Result == Results.Loss)
                SkillRating = Mathf.Clamp01(SkillRating + TeamContribBonus - MedianGain * 2);
            MatchmakingRating = Mathf.Clamp01(SkillRating + (Contribution - .5f) * MedianGain * 4);

            if (MatchType != MatchTypes.HighStakes)
                SkillRating = MatchmakingRating; // When accurate rating over a larger timespan is not key, simply use MMR only.
        }
    }
}