namespace AdventOfCode2020.Tests.Day6;

public class Day6Test : ITest
{
    [Fact]
    public void ShouldReturnResultExamplePart1()
    {
        var result = Sut().GetTotalYes("input_example.txt");
        Assert.Equal(11, result);
    }

    [Fact]
    public void ShouldReturnResultPart1()
    {
        var result = Sut().GetTotalYes("input.txt");
        Assert.Equal(6532, result);
    }

    [Fact]
    public void ShouldReturnResultExamplePart2()
    {
        var result = Sut().GetTotalYesPart2("input_example.txt");
        Assert.Equal(6, result);
    }

    [Fact]
    public void ShouldReturnResultPart2()
    {
        var result = Sut().GetTotalYesPart2("input.txt");
        Assert.Equal(3427, result);
    }

    private Solutions.Day6.Day6 Sut() => new Solutions.Day6.Day6();
}