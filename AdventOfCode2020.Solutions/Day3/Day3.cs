using AdventOfCode2020.Common;

namespace AdventOfCode2020.Solutions.Day3;

public class Day3
{
    public int GetTotalTrees(string filename)
    {
        var lines = ParseFile.GetLines("Day3", filename);
        var rows = lines.Select(l => l.ToCharArray()).ToList();
        var positionHorizontal = 0;
        var positionVertical = 0;
        var totalHorizontal = rows[0].Length;
        var totalVertical = rows.Count;
        var totalTrees = 0;
        while (positionVertical != totalVertical -1)
        {
            positionHorizontal += 3;
            positionVertical += 1;
            if (positionHorizontal >= totalHorizontal)
            {
                positionHorizontal = positionHorizontal - totalHorizontal;
            }
            var item = rows[positionVertical][positionHorizontal];
            if (item == '#')
            {
                totalTrees++;
            }
        }
        
        return totalTrees;
    }

    public int GetAllTreesOfAllSlopes(string filename)
    {
        var lines = ParseFile.GetLines("Day3", filename);
        var rows = lines.Select(l => l.ToCharArray()).ToList();
        var slopes = new List<Tuple<int, int>>(){new (1,1), new (3,1), new (5,1), new (7,1), new (1,2)};
        var totalTrees = slopes.Select(x => GetTotalTreesPerSlope(rows, x.Item1, x.Item2)).Aggregate(1, (x,y) => x * y);
        return totalTrees;
    }

    private int GetTotalTreesPerSlope(List<char[]> rows, int increaseHorizontal, int increaseVertical)
    {
        var positionHorizontal = 0;
        var positionVertical = 0;
        var totalHorizontal = rows[0].Length;
        var totalVertical = rows.Count;
        var totalTrees = 0;
        while (positionVertical != totalVertical - 1)
        {
            positionHorizontal += increaseHorizontal;
            positionVertical += increaseVertical;
            if (positionHorizontal >= totalHorizontal)
            {
                positionHorizontal = positionHorizontal - totalHorizontal;
            }
            var item = rows[positionVertical][positionHorizontal];
            if (item == '#')
            {
                totalTrees++;
            }
        }
        
        return totalTrees;
    }

     
}
