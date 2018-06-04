using System.Collections.Generic;

namespace MatchmakerEngine {
    public class Queue {
        /// <summary>Maximum time spent in queue, seconds.</summary>
        public float MaxWait = 600;

        /// <summary>Players required to start a game.</summary>
        public int PlayersNeeded = 12;

        List<Player> QueuedPlayers = new List<Player>(); // TODO: use something always sorted

        public int PlayersIn { get { return QueuedPlayers.Count; } }

        public delegate void MatchMade(List<Player> Players);

        public event MatchMade OnMatchMade;

        public void QueuePlayer(Player Target) {
            QueuedPlayers.Add(Target);
        }

        public void DequeuePlayer(Player Target) {
            QueuedPlayers.Remove(Target);
        }

        public bool IsInQueue(Player Target) {
            return QueuedPlayers.Contains(Target);
        }

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
    }
}