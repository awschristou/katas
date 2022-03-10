using Mastermind;
using Xunit;

namespace Tests;

public class EngineTests
{
    private readonly Engine _sut = new Engine();

    [Fact]
    public void Test1()
    {
        Assert.NotNull(_sut.Evaluate());
    }
}
