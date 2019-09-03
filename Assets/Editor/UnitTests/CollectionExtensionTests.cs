using System.Collections.Generic;
using NUnit.Framework;
using OatsUtil;

public class CollectionExtensionTests
{
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(-1)]
    [TestCase(int.MaxValue)]
    [TestCase(int.MinValue)]
    public void ListRandom_returns_same_value_for_same_seed(int seed)
    {
        List<int> exampleList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        int firstRandomElement = exampleList.Random<int>(new System.Random(seed));
        int secondRandomElement = exampleList.Random<int>(new System.Random(seed));

        Assert.AreEqual(firstRandomElement, secondRandomElement);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(-1)]
    [TestCase(int.MaxValue)]
    [TestCase(int.MinValue)]
    public void ArrayRandom_returns_same_value_for_same_seed(int seed)
    {
        int[] exampleArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        int firstRandomElement = exampleArray.Random<int>(new System.Random(seed));
        int secondRandomElement = exampleArray.Random<int>(new System.Random(seed));

        Assert.AreEqual(firstRandomElement, secondRandomElement);
    }

    [TestCase(0, 1)]
    [TestCase(1, 0)]
    [TestCase(-1, -4)]
    [TestCase(int.MaxValue, int.MaxValue - 1)]
    [TestCase(10000, 40000)]
    public void ListRandom_returns_different_value_for_different_seed(int seed1, int seed2)
    {
        List<int> exampleList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        int firstRandomElement = exampleList.Random<int>(new System.Random(seed1));
        int secondRandomElement = exampleList.Random<int>(new System.Random(seed2));

        Assert.AreNotEqual(firstRandomElement, secondRandomElement);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(-1)]
    [TestCase(int.MaxValue)]
    [TestCase(int.MinValue)]
    public void Shuffle_shuffles_the_same_for_same_seed(int seed)
    {
        List<int> exampleList1 = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        List<int> exampleList2 = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        exampleList1.Shuffle(new System.Random(seed));
        exampleList2.Shuffle(new System.Random(seed));

        Assert.AreEqual(exampleList1.Count, exampleList2.Count);
        for (int index = 0; index < exampleList1.Count; index += 1)
        {
            Assert.AreEqual(exampleList1[index], exampleList2[index]);
        }
    }
}
