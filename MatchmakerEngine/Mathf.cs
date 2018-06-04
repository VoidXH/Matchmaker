namespace MatchmakerEngine {
    /// <summary>Floating point mathematics extensions.</summary>
    public static class Mathf {
        /// <summary>Keeps x between l and r.</summary>
        public static float Clamp(float x, float l, float r) {
            return x < l ? l : x > r ? r : x;
        }

        /// <summary>Keeps x between 0 and 1.</summary>
        public static float Clamp01(float x) {
            return x < 0 ? 0 : x > 1 ? 1 : x;
        }
    }
}