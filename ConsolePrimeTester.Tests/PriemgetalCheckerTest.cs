using JetBrains.Annotations;
using Xunit;

namespace ConsolePrimeTester.Tests;

[TestSubject(typeof(PriemgetalChecker))]
public class PriemgetalCheckerTest
{
    private readonly PriemgetalChecker sut;

    public PriemgetalCheckerTest()
    {
        sut = new PriemgetalChecker();
    }
    
    [Fact]
    public void test()
    {
        var actual = sut.testPrime(1);
        var expected = false;
        
        Assert.Equal(expected, actual);
    }
}