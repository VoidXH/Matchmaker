using MatchmakerEngine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matchmaker {
    public class SimulatedQueue : Queue {
        /// <summary>Skill rating distribution.</summary>
        public int SkillRange = 5000;

        /// <summary>All output is written here. Clear this when you want, but don't let it eat all your RAM.</summary>
        public StringBuilder Result = new StringBuilder();

        public object ResultLock = new object();

        public int MatchesPlayed { get; private set; } = 0;

        public int PlayersPerTeam { get; private set; }

        public SimulatedQueue(int PlayersPerTeam = 6) {
            OnMatchMade += StartMatchSimulation;
            PlayersNeeded = (this.PlayersPerTeam = PlayersPerTeam) * 2;
        }

        void LogPlayer(SimulatedPlayer SPlayer, float Contribution, bool Winner) {
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

        struct SimulationResult {
            public SimulatedPlayer SPlayer;
            public float Contribution;
        }

        /// <summary>Evaluate a match with random winners and contributions.</summary>
        /// <param name="Players">Players found to play by the matchmaker</param>
        void SimulateMatch(List<Player> Players) {
            const int TeamCount = 2;
            for (int i = 0, c = Players.Count; i < c; ++i)
                ((SimulatedPlayer)Players[i]).SkillBeforeMatch = (int)(Players[i].SkillRating * SkillRange);
            List<Player>[] Teams = DistributeTeams(Players, TeamCount);
            float WinnerSkill = 0, LoserSkill = 0;
            for (int t = 0; t < TeamCount; ++t)
                for (int i = 0; i < PlayersPerTeam; ++i)
                    if (t == 0)
                        WinnerSkill += Teams[0][i].MatchmakingRating; // Team 0 is randomly the winner.
                    else
                        LoserSkill += Teams[t][i].MatchmakingRating;
            WinnerSkill /= PlayersPerTeam;
            LoserSkill /= PlayersPerTeam;
            // Random contribution calculation
            Random Rand = new Random((int)DateTime.Now.Ticks);
            SimulationResult[,] STeams = new SimulationResult[2, PlayersPerTeam];
            for (int t = 0; t < 2; ++t) {
                float GroupSkill = t == 0 ? WinnerSkill : LoserSkill;
                for (int i = 0; i < PlayersPerTeam; ++i) {
                    STeams[t, i].SPlayer = (SimulatedPlayer)Teams[t][i];
                    STeams[t, i].Contribution = Mathf.Clamp01(STeams[t, i].SPlayer.ActualSkill / GroupSkill * .5f + (float)Rand.NextDouble() * .1f - .05f);
                }
            }
            // Simulate
            for (int t = 0; t < TeamCount; ++t)
                for (int i = 0; i < PlayersPerTeam; ++i)
                    STeams[t, i].SPlayer.Evaluate(WinnerSkill, LoserSkill, STeams[t, i].Contribution, Results.Win);
            // Log
            lock (ResultLock) {
                Result.AppendLine("New match --------------------");
                for (int t = 0; t < TeamCount; ++t)
                    for (int i = 0; i < PlayersPerTeam; ++i)
                        LogPlayer(STeams[t, i].SPlayer, STeams[t, i].Contribution, t == 0);
            }
            for (int i = 0; i < PlayersPerTeam; ++i)
                ((SimulatedPlayer)Players[i]).InMatch = false;
            ++MatchesPlayed;
        }

        void StartMatchSimulation(List<Player> Players) {
            Task.Run(() => {
                List<Player> MatchPlayers = Players;
                SimulateMatch(MatchPlayers);
            });
        }
    }
}