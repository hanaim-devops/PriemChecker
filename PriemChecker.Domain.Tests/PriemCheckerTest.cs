using JetBrains.Annotations;
using Xunit;

namespace PriemChecker.Domain.Tests;

[TestSubject(typeof(SimpelPriemChecker))]
public class PriemCheckerTest
{
    private readonly SimpelPriemChecker sut = new();

    [Fact]
    public void TestPrimeNumberIsCheckedAsPrime()
    {
        var actual = sut.IsPriemgetal(12037);
        var expected = true;
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestNonPrimeNumberIsCheckedAsNonPrime()
    {
        var actual = sut.IsPriemgetal(12036);
        var expected = false;
        
        Assert.Equal(expected, actual);
    }

}