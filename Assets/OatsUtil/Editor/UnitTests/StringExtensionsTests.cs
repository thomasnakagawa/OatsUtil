using NUnit.Framework;
using OatsUtil;

public class StringExtensionsTests
{
    [TestCase("thing", 0, ExpectedResult = "0 things")]
    [TestCase("thing", 1, ExpectedResult = "1 thing")]
    [TestCase("thing", 2, ExpectedResult = "2 things")]
    [TestCase("thing", -1, ExpectedResult = "-1 things")]
    [TestCase("", 0, ExpectedResult = "0 s")]
    [TestCase("", 1, ExpectedResult = "1 ")]
    public string Plural_1arg_Test(string inputString, int count)
    {
        return inputString.Plural(count);
    }

    [TestCase("fish", "es", 0, ExpectedResult = "0 fishes")]
    [TestCase("fish", "es", 1, ExpectedResult = "1 fish")]
    [TestCase("fish", "es", 2, ExpectedResult = "2 fishes")]
    [TestCase("fish", "", 0, ExpectedResult = "0 fish")]
    [TestCase("fish", "", 1, ExpectedResult = "1 fish")]
    public string Plural_2arg_Test(string inputString, string suffix, int count)
    {
        return inputString.Plural(count, suffix);
    }

    [TestCase("test", ExpectedResult = "\"test\"")]
    [TestCase("", ExpectedResult = "\"\"")]
    [TestCase("\"", ExpectedResult = "\"\"\"")]
    [TestCase("\\", ExpectedResult = "\"\\\"")]
    public string Quote_Test(string inputString)
    {
        return inputString.Quote();
    }

    [TestCase("test", "<a>", ExpectedResult = "<a>test</a>")]
    [TestCase("test", "<heyheyhey>", ExpectedResult = "<heyheyhey>test</heyheyhey>")]
    [TestCase("", "<a>", ExpectedResult = "<a></a>")]
    public string Tag_1arg_Test(string inputString, string tag)
    {
        return inputString.Tag(tag);
    }

    [TestCase("test", "a")]
    [TestCase("test", "<a")]
    [TestCase("test", "a>")]
    [TestCase("test", "")]
    [TestCase("test", "<")]
    public void Tag_1arg_malformed_arg(string inputString, string tag)
    {
        Assert.Throws<System.ArgumentException>(() => inputString.Tag(tag));
    }

    [TestCase("test", "<a>", "</a>", ExpectedResult = "<a>test</a>")]
    [TestCase("test", "<heyhey>", "</okok>", ExpectedResult = "<heyhey>test</okok>")]
    [TestCase("test", "<heyhey>", "", ExpectedResult = "<heyhey>test")]
    public string Tag_2arg_Test(string inputString, string tag, string endTag)
    {
        return inputString.Tag(tag, endTag);
    }
}
