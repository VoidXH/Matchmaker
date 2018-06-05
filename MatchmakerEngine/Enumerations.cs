namespace MatchmakerEngine {
    /// <summary>After-match player evaluation speed and accuracy modifier.</summary>
    public enum MatchTypes {
        /// <summary>Not ranked matches, but relatively accurate balance by the player's current mood is needed.</summary>
        LowStakes,
        /// <summary>The average ranked match.</summary>
        HighStakes,
        /// <summary>Ranked matches to determine the player's skill level faster, but less accurately.</summary>
        Placement
    }

    /// <summary>Match outcome.</summary>
    public enum Results {
        /// <summary>Positive SR change.</summary>
        Win,
        /// <summary>No SR change.</summary>
        Draw,
        /// <summary>Negative SR change.</summary>
        Loss
    }
}