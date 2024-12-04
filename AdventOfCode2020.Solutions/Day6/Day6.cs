using AdventOfCode2020.Common;

namespace AdventOfCode2020.Solutions.Day6;

public class Day6
{
    public int GetTotalYes(string fileName)
    {
        var block = ParseFile.GetBlockOfLines("Day6", fileName);
        var total = 0;
        foreach (var line in block)
        {
            var strings = line.Split("\n");
            var chars = string.Join("", strings).ToCharArray();
            var uniqueChars = new HashSet<char>(chars);
            total += uniqueChars.Count;
        }

        return total;
    }
    
    public int GetTotalYesPart2(string fileName)
    {
        var block = ParseFile.GetBlockOfLines("Day6", fileName);
        var total = 0;
        foreach (var line in block)
        {
            var strings = line.Split("\n");
            var uniqueChars = new HashSet<Char>(strings[0].ToCharArray());
            foreach (var item in strings)
            {
                var uniqueFoundChars = new HashSet<Char>(item.ToCharArray());
                uniqueChars.IntersectWith(uniqueFoundChars);
                
            }
            total += uniqueChars.Count;
        }

        return total;
    }
}