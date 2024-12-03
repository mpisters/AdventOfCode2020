namespace AdventOfCode2020.Tests.Day5;

public class Day5Test : ITest
{

    [Fact]
    public void ShouldReturnResultExamplePart1()
    {
        var result = Sut().GetHighestBoardingPass("input_example.txt");
        Assert.Equal(820, result);
    }

    [Fact]
    public void ShouldReturnResultPart1()
    {
        var result = Sut().GetHighestBoardingPass("input.txt");
        Assert.Equal(820, result);
    }

    public void ShouldReturnResultExamplePart2()
    {
        throw new NotImplementedException();
    }

    public void ShouldReturnResultPart2()
    {
        throw new NotImplementedException();
    }
    private Solutions.Day5.Day5 Sut() => new Solutions.Day5.Day5();
}