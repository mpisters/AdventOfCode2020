using AdventOfCode2020.Common;

namespace AdventOfCode2020.Solutions.Day1;

public class Day1
{
    public int GetSumOf2020Part1(string fileName)
    {
        var lines = ParseFile.GetLines("Day1", fileName);
        foreach (var line in lines)
        {
            foreach (var otherLine in lines)
            {
                var sum = Int32.Parse(line) + Int32.Parse(otherLine);
                if (sum == 2020)
                {
                    return Int32.Parse(line) * Int32.Parse(otherLine);
                }
            }
        }
        return Int32.MaxValue;
    }
    
    public int GetSumOf2020Part2(string fileName)
    {
        var lines = ParseFile.GetLines("Day1", fileName);
        foreach (var line in lines)
        {
            foreach (var otherLine in lines)
            {
                foreach (var otherLine2 in lines)
                {
                    var sum = Int32.Parse(line) + Int32.Parse(otherLine) + Int32.Parse(otherLine2);
                    if (sum == 2020)
                    {
                        return Int32.Parse(line) * Int32.Parse(otherLine) * Int32.Parse(otherLine2);
                    }
                }
           
            }
        }
        return Int32.MaxValue;
    }
}