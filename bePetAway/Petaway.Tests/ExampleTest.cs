using NUnit.Framework;

namespace Petaway.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void OnePlusTwoEquals3()
    {
        int sum = 1 + 2;
        Assert.AreEqual(sum, 3);
    }
}