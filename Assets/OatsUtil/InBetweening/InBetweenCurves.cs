namespace OatsUtil.InBetweening
{
    public static class InBetweenCurves
    {
        public delegate float CurveFunction(float inputValue);

        public static CurveFunction Linear = f => f;

        public static CurveFunction EaseIn = f => f * f;

        public static CurveFunction EaseOut = f => -(f * (f - 2f));

        public static CurveFunction EaseInAndOut = f =>
        {
            if (f < 0.5f)
            {
                return 2 * f * f;
            }
            else
            {
                return (-2 * f * f) + (4 * f) - 1;
            }
        };
    }
}
