namespace AdventOfCode2020.Tests.Day3;

public class Day3Test
{
    [Fact]
    public void ShouldReturnResultExamplePart1()
    {
        var result = Sut().GetTotalTrees("input_example.txt");
        Assert.Equal(7, result);
    }
    
    [Fact]
    public void ShouldReturnResultPart1()
    {
        var resutl = Sut().GetTotalTrees("input.txt");
        Assert.Equal(220, resutl);
    }
    
    [Fact]
    public void ShouldReturnResultExamplePart2()
    {
        var resutl = Sut().GetAllTreesOfAllSlopes("input_example.txt");
        Assert.Equal(336, resutl);
    }
    
    [Fact]
    public void ShouldReturnResultPart2()
    {
        var resutl = Sut().GetAllTreesOfAllSlopes("input.txt");
        Assert.Equal(2138320800, resutl);
    }
    private Solutions.Day3.Day3 Sut() => new Solutions.Day3.Day3();
}