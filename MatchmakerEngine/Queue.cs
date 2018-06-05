using System.Collections.Generic;

namespace MatchmakerEngine {
    public abstract class Queue {
        /// <summary>Maximum time spent in queue, seconds.</summary>
        public float MaxWait = 600;
        /// <summary>Players required to start a game.</summary>
        public int PlayersNeeded = 12;

        /// <summary>Match initialization delegate.</summary>
        /// <param name="Players">Selected players for this match.</param>
        public delegate void MatchMade(List<Player> Players);
        /// <summary>Invoked when players are found for a match.</summary>
        public event MatchMade OnMatchMade;

        /// <summary>Players that are in this queue.</summary>
        List<Player> QueuedPlayers = new List<Player>(); // TODO: use something always sorted

        /// <summary>Player count in the queue.</summary>
        public int PlayersIn {
            get => QueuedPlayers.Count;
        }

        /// <summary>Add a player to the queue.</summary>
        public void QueuePlayer(Player Target) {
            QueuedPlayers.Add(Target);
        }

        /// <summary>Remove a player from the queue.</summary>
        public void DequeuePlayer(Player Target) {
            QueuedPlayers.Remove(Target);
        }

        /// <summary>Check if a player is in this queue.</summary>
        public bool IsInQueue(Player Target) {
            return QueuedPlayers.Contains(Target);
        }

        /// <summary>Queue thread loop.</summary>
        public void Tick(float DeltaTime) {
            for (int i = 0, qc = QueuedPlayers.Count; i < qc; ++i)
                QueuedPlayers[i].QueueRange += DeltaTime / MaxWait;
            QueuedPlayers.Sort((a, b) => a.MatchmakingRating.CompareTo(b.MatchmakingRating));
            int RangeDiff = PlayersNeeded - 1;
            for (int i = 0, RangeLength = QueuedPlayers.Count - RangeDiff; i < RangeLength; ++i) {
                float MaxGroupRange = 0;
                for (int j = i, end = i + PlayersNeeded; j < end; ++j)
                    if (MaxGroupRange < QueuedPlayers[j].QueueRange)
                        MaxGroupRange = QueuedPlayers[j].QueueRange;
                float CurrentRange = QueuedPlayers[i + RangeDiff].MatchmakingRating - QueuedPlayers[i].MatchmakingRating;
                if (CurrentRange <= MaxGroupRange) {
                    OnMatchMade?.Invoke(QueuedPlayers.GetRange(i, PlayersNeeded));
                    QueuedPlayers.RemoveRange(i, PlayersNeeded);
                    RangeLength -= PlayersNeeded;
                }
            }
        }

        /// <summary>Create teams close in skill.</summary>
        /// <param name="ool">Player pool. No P in the ool.</param>
        /// <param name="Teams">Number of teams</param>
        public static List<Player>[] DistributeTeams(List<Player> ool, int Teams) {
            List<Player>[] MatchedTeams = new List<Player>[Teams];
            float[] Ratings = new float[Teams];
            int MaxPerTeam = ool.Count / Teams;
            if (MaxPerTeam * Teams != ool.Count)
                ++MaxPerTeam;
            for (int i = 0; i < Teams; ++i)
                MatchedTeams[i] = new List<Player>(MaxPerTeam);
            float PeakRating = 0;
            foreach (Player p in ool) {
                for (int i = 0; i < Teams; ++i) {
                    if (Ratings[i] <= PeakRating && MatchedTeams[i].Count != MaxPerTeam) {
                        MatchedTeams[i].Add(p);
                        Ratings[i] += p.MatchmakingRating;
                        if (PeakRating < Ratings[i])
                            PeakRating = Ratings[i];
                        break;
                    }
                }
            }
            return MatchedTeams;
        }
    }
}