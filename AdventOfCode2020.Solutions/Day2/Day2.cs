using AdventOfCode2020.Common;

namespace AdventOfCode2020.Solutions.Day2;

public class Day2
{
    public int GetValidPasswordsPart1(string filename)
    {
        var lines = ParseFile.GetLines("Day2", filename);
        var isValid = 0;
        foreach (var line in lines)
        {
            var items = line.Split(" ");
            var limits = items.ElementAt(0).Split("-");
            var testedCharacter = Convert.ToChar(items.ElementAt(1).Replace(":", ""));
            var password = items.ElementAt(2);

            var matchedCharacters = password.Select(x => x == testedCharacter).Where(t => t == true).ToArray();
            var minLimit = int.Parse(limits.ElementAt(0));
            var maxLimit = int.Parse(limits.ElementAt(1));
            if (matchedCharacters.Count() >= minLimit && matchedCharacters.Count() <= maxLimit)
            {
                isValid++;
            }
        }

        return isValid;
    }
    
    public int GetValidPasswordsPart2(string filename)
    {
        var lines = ParseFile.GetLines("Day2", filename);
        var isValid = 0;
        foreach (var line in lines)
        {
            var items = line.Split(" ");
            var limits = items.ElementAt(0).Split("-");
            var testedCharacter = Convert.ToChar(items.ElementAt(1).Replace(":", ""));
            var password = items.ElementAt(2);

            var firstPosition = int.Parse(limits.ElementAt(0)) - 1;
            var secondPosition = int.Parse(limits.ElementAt(1)) - 1;
            if (secondPosition > password.Length)
            {
                break;
            }
            if (password.ElementAt(firstPosition) == testedCharacter && password.ElementAt(secondPosition) != testedCharacter
                || password.ElementAt(firstPosition) != testedCharacter && password.ElementAt(secondPosition) == testedCharacter)
            {
                isValid++;
            }
        }

        return isValid;
    }
}