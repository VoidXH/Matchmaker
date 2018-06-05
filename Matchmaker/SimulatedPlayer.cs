using MatchmakerEngine;
using System;

namespace Matchmaker {
    public class SimulatedPlayer : Player {
        /// <summary>Placement matches required before evaluating actual skill rating.</summary>
        public static int PlacementMatches = 10;
        /// <summary>Maximum time to wait before joining the queue.</summary>
        public static float CooldownRange = 30;

        public string Name { get; private set; }
        /// <summary>Skill target to reach and maintain in the simulation.</summary>
        public float ActualSkill { get; private set; }

        /// <summary>SR before the current match to retrieve SR change.</summary>
        internal int SkillBeforeMatch;

        internal int PlacementMatchesRemaining { get; private set; }

        internal bool InMatch = false;

        /// <summary>Wait time between matches.</summary>
        float Cooldown;

        static Random Rand = new Random();
        /// <summary>Auto-incrementing player ID in the new player's name.</summary>
        static int ID = 0;

        void Randomize() {
            Name = "Player " + ++ID;
            Cooldown = (float)Rand.NextDouble() * CooldownRange;
            ActualSkill = -1;
            while (ActualSkill < 0 || ActualSkill > 1) { // Rejection sampling
                double u1 = 1.0 - Rand.NextDouble(), u2 = 1.0 - Rand.NextDouble(); // Box-Muller transform values
                ActualSkill = (float)(Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2)) / 5f + .5f; // Gaussian random skill
            }
        }

        public SimulatedPlayer() : base() {
            PlacementMatchesRemaining = PlacementMatches;
            Randomize();
        }

        public SimulatedPlayer(float SkillRating, float MatchmakingRating) : base(SkillRating, MatchmakingRating) {
            PlacementMatchesRemaining = PlacementMatches;
            Randomize();
        }

        public void QueueSimulation(Queue Line, float DeltaTime) {
            if (InMatch || Line.IsInQueue(this))
                return;
            if ((Cooldown -= DeltaTime) <= 0) {
                Line.QueuePlayer(this);
                Cooldown = (float)new Random((int)DateTime.Now.Ticks).NextDouble() * CooldownRange;
            }
        }

        public void Evaluate(float TeamSkill, float OpponentSkill, float Contribution, Results Result) {
            Evaluate(TeamSkill, OpponentSkill, Contribution, Result, --PlacementMatchesRemaining < 0 ? MatchTypes.HighStakes : MatchTypes.Placement);
        }
    }
}