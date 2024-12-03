using AdventOfCode2020.Common;

namespace AdventOfCode2020.Solutions.Day5;

public class Day5
{
    public int GetHighestBoardingPass(string filename)
    {
        var lines = ParseFile.GetLines("Day5", filename);
        var rows = Enumerable.Range(0, 128);
        var columns = Enumerable.Range(0, 9);
        var ids = new List<int>();
        foreach (var line in lines)
        {
            var positionRow = 1;
            var positionColumn = 1;

            for(var i = 0; i< line.Length; i++)
            {
                var state = line[i];

                if (i < line.Length - 3)
                {
                    rows = GetNewRowsArray(rows, state);
                    if (rows.Count() <= 2)
                    {
                        positionRow = rows.ElementAt(0);
                    }
                }

                if (i >= line.Length - 3)
                {
                    var totalColumns = columns.Count() / 2;

                    if (state == 'L')
                    {
                        columns = columns.Take(totalColumns).ToList();
                    }

                    if (state == 'R')
                    {
                        columns = columns.Skip(totalColumns).ToList();
                    }
                    if (columns.Count() == 1)
                    {
                        positionColumn = columns.ElementAt(0);
                    }
                }



   
            }

            ids.Add(positionRow * 8 + positionColumn);
        }

        return ids.Max();
    }

    public IEnumerable<int> GetNewRowsArray(IEnumerable<int> rows, char state)
    {
        var totalRows = rows.Count() / 2;


            if (state == 'F')
            {
                var steps = totalRows == 1 ? 2 : totalRows;
                rows = rows.Skip(0).Take(steps ).ToList();
            }

            if (state == 'B')
            {
                var minPosition = totalRows;
                rows = rows.Skip(minPosition);
            }
        

        return rows;
    }
}