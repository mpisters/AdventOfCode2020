namespace AdventOfCode2020.Tests.Day4;

public class Day4Test : ITest
{
    [Fact]
    public void ShouldReturnResultExamplePart1()
    {
        var result = Sut().ValidatePassportsPart1("input_example.txt");
        Assert.Equal(2, result);
    }

    [Fact]
    public void ShouldReturnResultPart1()
    {
        var result = Sut().ValidatePassportsPart1("input.txt");
        Assert.Equal(222, result);
    }

    [Fact]
    public void ShouldReturnResultPart2()
    {
        var result = Sut().ValidatePassports2("input.txt");
        Assert.Equal(222, result);
    }

    private Solutions.Day4.Day4 Sut() => new Solutions.Day4.Day4();
}