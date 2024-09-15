using JetBrains.Annotations;
using PrimeChecker;
using Xunit;

namespace ConsolePriemChecker.Tests;

[TestSubject(typeof(PriemChecker))]
public class PriemCheckerTest
{
    private readonly PriemChecker sut;

    public PriemCheckerTest()
    {
        sut = new PriemChecker();
    }
    
    [Fact]
    public void test()
    {
        var actual = sut.TestPriemgetal(1);
        var expected = false;
        
        Assert.Equal(expected, actual);
    }
}