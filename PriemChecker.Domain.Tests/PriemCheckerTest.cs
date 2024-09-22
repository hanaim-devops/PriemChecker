using System.Numerics;
using JetBrains.Annotations;
using PriemChecker.Abstractions;
using Xunit;

namespace PriemChecker.Domain.Tests;

[TestSubject(typeof(SimpelPriemChecker))]
public class PriemCheckerTest
{
    private readonly SimpelPriemChecker sut = new();

    [Fact]
    public void TestPrimeNumberIsCheckedAsPrime()
    {
        var kandidaat = new BigInteger(12037);
        var actual = sut.IsPriemgetal(kandidaat);
        var expected = true;
        
        Assert.Equal(expected, actual.IsPriemgetal);
    }
    
    [Fact]
    public void TestNonPrimeNumberIsCheckedAsNonPrime()
    {
        var actual = sut.IsPriemgetal(12036);
        var expected = false;
        
        Assert.Equal(expected, actual.IsPriemgetal);
    }

}