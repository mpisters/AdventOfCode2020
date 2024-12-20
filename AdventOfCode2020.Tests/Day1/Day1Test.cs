namespace AdventOfCode2020.Tests.Day1;

public class Day1Test : ITest
{
    
    [Fact]
    public void ShouldReturnResultExamplePart1(){
        var result = Sut().GetSumOf2020Part1("example_input_part1.txt");
        Assert.Equal(514579, result);
    }
    
    [Fact]
    public void ShouldReturnResultPart1(){
        var result = Sut().GetSumOf2020Part1("input_part1.txt");
        Assert.Equal(1016964, result);
    }
    
    [Fact]
    public void ShouldReturnResultExamplePart2(){
        var result = Sut().GetSumOf2020Part2("example_input_part1.txt");
        Assert.Equal(241861950, result);
    }
    
    [Fact]
    public void ShouldReturnResultPart2(){
        var result = Sut().GetSumOf2020Part2("input_part1.txt");
        Assert.Equal(182588480, result);
    }

    private static Solutions.Day1.Day1 Sut() => new Solutions.Day1.Day1();
}