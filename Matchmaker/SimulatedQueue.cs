using MatchmakerEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matchmaker {
    public class SimulatedQueue : Queue {
        /// <summary>Skill rating distribution.</summary>
        public int SkillRange = 5000;
        public int PlayersPerTeam = 6;
        /// <summary>All output is written here. Clear this when you want, but don't let it eat all your RAM.</summary>
        public StringBuilder Result = new StringBuilder();

        public int MatchesPlayed { get; private set; } = 0;

        public SimulatedQueue() {
            OnMatchMade += SimulateMatch;
        }

        void EvaluatePlayer(SimulatedPlayer SPlayer, float TeamSkill, float OpponentSkill, float Contribution, bool Winner) {
            SPlayer.Evaluate(TeamSkill, OpponentSkill, Contribution, Winner ? Results.Win : Results.Loss);
            Result.Append(SPlayer.Name).AppendLine(": ");
            int NewSkill = (int)(SPlayer.SkillRating * SkillRange);
            Result.Append(SPlayer.SkillBeforeMatch).Append(" -> ").Append(NewSkill).Append(" (");
            if (SPlayer.PlacementMatchesRemaining <= 0)
                Result.Append(NewSkill - SPlayer.SkillBeforeMatch);
            else
                Result.Append("Placement match ").Append(SimulatedPlayer.PlacementMatches - SPlayer.PlacementMatchesRemaining);
            Result.Append(", ").Append(Winner ? "Victory" : "Defeat").AppendLine(")");
            Result.Append("Contribution: ").AppendLine(Contribution.ToString());
            Result.Append("New MMR: ").AppendLine(((int)(SPlayer.MatchmakingRating * SkillRange)).ToString()).AppendLine();
        }

        /// <summary>Evaluate a match with random winners and contributions.</summary>
        /// <param name="Players">Players found to play by the matchmaker</param>
        void SimulateMatch(List<Player> Players) {
            for (int i = 0, c = Players.Count; i < c; ++i)
                ((SimulatedPlayer)Players[i]).SkillBeforeMatch = (int)(Players[i].SkillRating * SkillRange);
            List<Player>[] Teams = DistributeTeams(Players, 2);
            float WinnerSkill = 0, LoserSkill = 0;
            for (int i = 0; i < PlayersPerTeam; ++i) {
                WinnerSkill += Teams[0][i].MatchmakingRating; // Team 0 is randomly the winner.
                LoserSkill += Teams[1][i].MatchmakingRating; // Team 0 is randomly the winner.
            }
            Random Rand = new Random((int)DateTime.Now.Ticks);
            Result.AppendLine("New match --------------------");
            WinnerSkill /= PlayersPerTeam;
            LoserSkill /= PlayersPerTeam;
            for (int i = 0; i < PlayersPerTeam; ++i) {
                EvaluatePlayer((SimulatedPlayer)Teams[0][i], WinnerSkill, LoserSkill,
                    Mathf.Clamp01(((SimulatedPlayer)Teams[0][i]).ActualSkill / WinnerSkill * .5f + (float)Rand.NextDouble() * .1f - .05f), true);
                EvaluatePlayer((SimulatedPlayer)Teams[1][i], LoserSkill, WinnerSkill,
                    Mathf.Clamp01(((SimulatedPlayer)Teams[1][i]).ActualSkill / LoserSkill * .5f + (float)Rand.NextDouble() * .1f - .05f), false);
            }
            ++MatchesPlayed;
        }

        public void SimulatorTick(float DeltaTime) {
            PlayersNeeded = PlayersPerTeam * 2;
            Tick(DeltaTime);
        }
    }
}