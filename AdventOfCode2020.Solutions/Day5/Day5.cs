using AdventOfCode2020.Common;

namespace AdventOfCode2020.Solutions.Day5;

public class Day5
{
    public int GetHighestBoardingPass(string filename)
    {
        var lines = ParseFile.GetLines("Day5", filename);
        var boardingPassIds = GetBoardingPassIds(lines);

        return boardingPassIds.Max();
    }

    private static List<int> GetBoardingPassIds(string[] lines)
    {
        var boardingPassIds = new List<int>();
        foreach (var line in lines)
        {
            var firstPart = line.Substring(0, 7);
            var secondPart = line.Substring(7, 3);
            var row = GetRow(firstPart);
            var column = GetColumn(secondPart);
            var id = row * 8 + column;
            boardingPassIds.Add(id);
        }

        return boardingPassIds;
    }

    public int GetMissingBoardingPass(string filename)
    {
        var lines = ParseFile.GetLines("Day5", filename);
        var boardingPassIds = GetBoardingPassIds(lines);


        boardingPassIds.Sort();
        var previous = boardingPassIds[0];
        for (var i = 1; i < boardingPassIds.Count; i++)
        {
            var current = boardingPassIds[i];
            var distance = current - previous;
            if (distance > 1)
            {
                return current - 1;
            }
            previous = current;
        }
        return 0;
    }

    private static int GetColumn(string secondPart)
    {
        var maxInt = 7d;
        var minInt = 0d;
        var index = 0;
        var column = int.MaxValue;
        foreach (var columnChar in secondPart)
        {
            var range = maxInt - minInt;
            var half = Math.Ceiling(range / 2.0);
            if (columnChar == 'L')
            {
                maxInt -= half;
            }

            if (columnChar == 'R')
            {
                minInt += half;
            }

            if (index == 2)
            {
                column = columnChar == 'L' ? (int)minInt : (int)maxInt;
            }

            index++;
        }

        return column;
    }

    private static int GetRow(string firstPart)
    {
        var maxInt = 127d;
        var minInt = 0d;
        var row = int.MaxValue;
        var index = 0;
        foreach (var rowChar in firstPart)
        {
            var range = maxInt - minInt;
            var half = Math.Ceiling(range / 2.0);
               
            if (rowChar == 'F')
            {
                maxInt -= half;
            }

            if (rowChar == 'B')
            {
                minInt += half;
            }
            
            if (index == 6)
            {
                row = rowChar == 'F' ? (int)minInt : (int)maxInt;
            }
            index++;
        }

        return row;
    }
}