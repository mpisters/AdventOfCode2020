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

    public void ShouldReturnResultExamplePart2()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void ShouldReturnResultPart2()
    {
        var result = Sut().ValidatePassports2("input.txt");
        Assert.Equal(140, result);
    }

    [Fact]
    public void ShouldReturnFalseWhenInvalidPassport()
    {
        var passport = new Solutions.Day4.Day4.Passport();
        var result = Sut().IsValidPassport(passport);
        Assert.False(result.Item1);
    }
    
    [Fact]
    public void ShouldReturnTrueWhenPassportIsValid()
    {
        var passport = new Solutions.Day4.Day4.Passport
        {
            Byr = 1920,
            Iyr = 2012,
            Eyr = 2023,
            Hgt = "150cm",
            Ecl = "amb",
            Hcl = "#fffffd",
            Pid = "000000000",
            Cid = "cid"
        };
        var result = Sut().IsValidPassport(passport);
        Assert.True(result.Item1);
    }

    

    private Solutions.Day4.Day4 Sut() => new Solutions.Day4.Day4();
}