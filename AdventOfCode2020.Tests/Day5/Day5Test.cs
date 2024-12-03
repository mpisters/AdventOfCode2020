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
        throw new NotImplementedException();
    }

    [Fact]
    public void ShouldReturnResultPart2()
    {
        throw new NotImplementedException();
    }

    [Theory]
    [InlineData('F', 64, 0 , 63)]
    [InlineData('B', 64, 64 , 127)]
    public void ShouldRightHalf(char state, int total, int minValue, int maxValue)
    {
        var rows = Enumerable.Range(0, 128);
        var result = Sut().GetNewRowsArray(rows, state);
        Assert.Equal(total, result.Count());
        Assert.Equal(minValue, result.ElementAt(0));
        Assert.Equal(maxValue, result.ElementAt(result.Count() - 1));
    }
    
    [Theory]
    [InlineData('F', 2, 0 , 1)]
    [InlineData('B', 2, 1 , 2)]
    public void ShouldRightHalfWithSmallArray(char state, int total, int minValue, int maxValue)
    {
        var rows = Enumerable.Range(0, 3);
        var result = Sut().GetNewRowsArray(rows, state);
        Assert.Equal(total, result.Count());
        Assert.Equal(minValue, result.ElementAt(0));
        Assert.Equal(maxValue, result.ElementAt(result.Count() - 1));
    }
    private Solutions.Day5.Day5 Sut() => new Solutions.Day5.Day5();
}