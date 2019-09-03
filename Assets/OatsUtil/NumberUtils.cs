namespace OatsUtil
{
    /// <summary>
    /// Collection of methods for operating on numeric values
    /// </summary>
    public static class NumberUtils
    {
        /// <summary>
        /// Maps a value from one numeric range to another
        /// </summary>
        /// <param name="range1Min">The minimum value of the range to map from</param>
        /// <param name="range1Max">The maximum value of the range to map from</param>
        /// <param name="range2Min">The minimum value of the range to map to</param>
        /// <param name="range2Max">The maximum value of the range to map to</param>
        /// <param name="range1Value">A value from the first range to map to the second range</param>
        /// <returns>A value from the second range, corresponding to the first value in the first range</returns>
        public static float MapRange(float range1Min, float range1Max, float range2Min, float range2Max, float range1Value)
        {
            float range1 = range1Max - range1Min;
            float range2 = range2Max - range2Min;
            float range2Value = (((range1Value - range1Min) * range2) / range1) + range2Min;

            return range2Value;
        }

        /// <summary>
        /// Clamps a value to a range by wrapping it from 0 (inclusive) to a maximum value (exclusive)
        /// </summary>
        /// <param name="max">The maximum value (exclusive) of the range</param>
        /// <param name="value">The value to wrap within the range</param>
        /// <returns></returns>
        public static int WrapRange(int max, int value)
        {
            return WrapRange(0, max, value);
        }

        /// <summary>
        /// Clamps a value to a range by wrapping it from a minimum value (inclusive) to a maximum value (exclusive)
        /// </summary>
        /// <param name="min">The minimum value (inclusive) of the range</param>
        /// <param name="max">The maximum value (exclusive) of the range</param>
        /// <param name="value">The value to wrap within the range</param>
        /// <returns></returns>
        public static int WrapRange(int min, int max, int value)
        {
            // TODO!!!!! this isnt going to work well in many cases
            if (value >= max)
            {
                return value % max;
            }
            if (value < min)
            {
                return max - (min - value);
            }
            return value;
        }

        /// <summary>
        /// Checks if a value is between 0 (inclusive) and a maximum value (exclusive)
        /// </summary>
        /// <param name="max">The maximum value (exclusive) of the range</param>
        /// <param name="value">The value to check if is within the range</param>
        /// <returns></returns>
        public static bool IsWithinRange(int max, int value)
        {
            return IsWithinRange(0, max, value);
        }

        /// <summary>
        /// Checks if a value is between a minimum value (inclusive) and a maximum value (exclusive)
        /// </summary>
        /// <param name="min">The minimum value (inclusive) of the range</param>
        /// <param name="max">The maximum value (exclusive) of the range</param>
        /// <param name="value">The value to check if is within the range</param>
        /// <returns></returns>
        public static bool IsWithinRange(int min, int max, int value)
        {
            return value >= min && value < max;
        }
    }
}
