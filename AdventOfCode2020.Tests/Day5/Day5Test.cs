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
        Assert.Equal(951, result);
    }

    public void ShouldReturnResultExamplePart2()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void ShouldReturnResultPart2()
    {
        var result = Sut().GetMissingBoardingPass("input.txt");
        Assert.Equal(653, result);
    }
    private Solutions.Day5.Day5 Sut() => new Solutions.Day5.Day5();
}