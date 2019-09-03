using NUnit.Framework;
using OatsUtil;

public class NumberUtilsTests
{
    [TestCase(0, 5, 0, ExpectedResult = true)]
    [TestCase(0, 5, 1, ExpectedResult = true)]
    [TestCase(0, 5, 4, ExpectedResult = true)]
    [TestCase(0, 5, 5, ExpectedResult = false)]
    [TestCase(0, 5, 6, ExpectedResult = false)]
    [TestCase(-5, 5, 0, ExpectedResult = true)]
    [TestCase(-5, 5, -5, ExpectedResult = true)]
    [TestCase(-5, 5, -6, ExpectedResult = false)]
    [TestCase(-5, 5, 5, ExpectedResult = false)]
    [TestCase(5, -5, 0, ExpectedResult = false, TestName = "Invalid range")]
    public bool IsWithinRange_3arg_Test(int min, int max, int value)
    {
        return NumberUtils.IsWithinRange(min, max, value);
    }

    [TestCase(5, 0, ExpectedResult = true)]
    [TestCase(5, 1, ExpectedResult = true)]
    [TestCase(5, 2, ExpectedResult = true)]
    [TestCase(5, 3, ExpectedResult = true)]
    [TestCase(5, 4, ExpectedResult = true)]
    [TestCase(5, 5, ExpectedResult = false)]
    [TestCase(5, 6, ExpectedResult = false)]
    [TestCase(0, 0, ExpectedResult = false)]
    [TestCase(-1, 0, ExpectedResult = false)]
    [TestCase(-2, -1, ExpectedResult = false)]
    [TestCase(int.MaxValue, int.MaxValue - 1, ExpectedResult = true)]
    [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = false)]
    public bool IsWithinRange_2arg_Test(int max, int value)
    {
        return NumberUtils.IsWithinRange(max, value);
    }

    [TestCase(0, 5, 0, ExpectedResult = 0)]
    [TestCase(0, 5, 3, ExpectedResult = 3)]
    [TestCase(0, 5, 5, ExpectedResult = 0)]
    [TestCase(0, 5, 6, ExpectedResult = 1)]
    [TestCase(0, 5, 7, ExpectedResult = 2)]
    [TestCase(0, 5, 10, ExpectedResult = 0)]
    [TestCase(0, 5, 11, ExpectedResult = 1)]
    [TestCase(0, 5, 500, ExpectedResult = 0)]
    [TestCase(0, 5, -1, ExpectedResult = 4)]
    [TestCase(0, 5, -2, ExpectedResult = 3)]
    [TestCase(0, 5, -5, ExpectedResult = 0)]
    [TestCase(0, 5, -6, ExpectedResult = 4)]
    [TestCase(-3, 5, -6, ExpectedResult = 2)]
    [TestCase(-3, 5, 0, ExpectedResult = 0)]
    [TestCase(-3, 5, 5, ExpectedResult = -3)]
    [TestCase(-3, 5, 6, ExpectedResult = -2)]
    [TestCase(10, 30, 10, ExpectedResult = 10)]
    [TestCase(10, 30, 30, ExpectedResult = 10)]
    [TestCase(10, 30, 31, ExpectedResult = 11)]
    [TestCase(10, 30, 9, ExpectedResult = 29)]
    public int WrapRange_3arg_Test(int min, int max, int value)
    {
        return NumberUtils.WrapRange(min, max, value);
    }

    [TestCase(0f, 10f, 50f, 60f, 0f, ExpectedResult = 50f)]
    [TestCase(0f, 10f, 50f, 60f, 10f, ExpectedResult = 60f)]
    [TestCase(0f, 10f, 50f, 60f, 5f, ExpectedResult = 55f)]
    [TestCase(0f, 1f, 0f, 100f, 0f, ExpectedResult = 0f)]
    [TestCase(0f, 1f, 0f, 100f, 1f, ExpectedResult = 100f)]
    [TestCase(0f, 1f, 0f, 100f, 0.5f, ExpectedResult = 50f)]
    public double MapRange_Test(float min1, float max1, float min2, float max2, float val1)
    {
        return NumberUtils.MapRange(min1, max1, min2, max2, val1);
    }
}
