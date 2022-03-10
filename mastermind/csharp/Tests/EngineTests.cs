using Mastermind;
using Xunit;

namespace Tests;

public class EngineTests
{

    // Therefore, your function should return, 
    // for a secret and a guessing combination:

    // the number of well placed colors
    // the number of correct but misplaced colors

    private readonly Engine _sut = new Engine();

    // [Fact]
    // public void Test1()
    // {
    //     // Assert.NotNull(_sut.Evaluate());
    // }

    [Fact]
    public void NoMatch()
    {
        var result = _sut.Evaluate(
            new [] {"blue"}, 
            new [] {"red"}
        );

        Assert.Equal(new Results(0, 0), result);
    }

    
    [Fact]
    public void WellPlaced()
    {
        var result = _sut.Evaluate(
            new [] {"blue"}, 
            new [] {"blue"}
        );

        Assert.Equal(new Results(1, 0), result);
    }

    [Fact]
    public void Misplaced()
    {
        var result = _sut.Evaluate(
            new [] {"red", "yellow"}, 
            new [] {"blue", "red"}
        );

        Assert.Equal(new Results(0, 1), result);
    }

    [Fact]
    public void MisplacedWithRepeatColors()
    {
        var result = _sut.Evaluate(
            new [] {"red", "red", "yellow", "yellow", "yellow"}, 
            new [] {"green", "green", "red", "red", "red"}
        );

        Assert.Equal(new Results(0, 2), result);
    }

    // but what happens when there is:
    // one match and one mismatch
    // r r y vvvv r g r (1, 1)
}


// evaluate([blue], [red]) should return [0, 0]  
// evaluate([blue], [blue]) should return [1, 0]  
// evaluate([red, yellow], [blue, red]) should return [0, 1]  
// r r g b vs x x r x -> 1
