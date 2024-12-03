namespace AdventOfCode2020.Tests.Day2;

public class Day2Test : ITest
{
    [Fact]
    public void ShouldReturnResultExamplePart1()
    {
        var resutl = Sut().GetValidPasswordsPart1("example_input_part1.txt");
        Assert.Equal(2, resutl);
    }
    
    [Fact]
    public void ShouldReturnResultPart1()
    {
        var resutl = Sut().GetValidPasswordsPart1("input_part1.txt");
        Assert.Equal(410, resutl);
    }

    public void ShouldReturnResultExamplePart2()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void ShouldReturnResultPart2()
    {
        var resutl = Sut().GetValidPasswordsPart2("input_part1.txt");
        Assert.Equal(694, resutl);
    }
    
    private Solutions.Day2.Day2 Sut() => new Solutions.Day2.Day2();
}