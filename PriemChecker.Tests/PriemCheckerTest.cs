using JetBrains.Annotations;
using PrimeChecker;
using Xunit;

namespace PriemChecker.Tests;

[TestSubject(typeof(PrimeChecker.PriemChecker))]
public class PriemCheckerTest
{
    private readonly PrimeChecker.PriemChecker sut = new();

    [Fact]
    public void test()
    {
        var actual = sut.IsPriemgetal(1);
        var expected = false;
        
        Assert.Equal(expected, actual);
    }
}