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

    
    [Fact]
    public void TestBigIntegerPrimeNumberIsCheckedAsPrime()
    {
        var actual = sut.IsPriemgetal(BigInteger.Parse("32416190071"));
        var expected = true;
        
        Assert.Equal(expected, actual.IsPriemgetal);
    }

    [Fact]
    public void TestBigIntegerNonPrimeNumberIsCheckedAsNonPrime()
    {
        var actual = sut.IsPriemgetal(BigInteger.Parse("12340293840239840293843"));
        var expected = false;
        
        Assert.Equal(expected, actual.IsPriemgetal);
    }

}