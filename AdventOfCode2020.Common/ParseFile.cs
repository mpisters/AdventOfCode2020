namespace AdventOfCode2020.Common;

public static class ParseFile
{
    public static string[] GetLines(string folderName, string fileName)
    {
        var folderPath = $"/{folderName}/";
        var path = Path.Combine(Environment.CurrentDirectory + folderPath, fileName);
        return File.ReadAllLines(path);
    }

    public static string[] GetBlockOfLines(string folderName, string fileName)
    {
        var folderPath = $"/{folderName}/";
        var path = Path.Combine(Environment.CurrentDirectory + folderPath, fileName);
        var file = File.ReadAllText(path);
        var inputLines = file.Split(new string[] { "\n\n" },
            StringSplitOptions.RemoveEmptyEntries);
        return inputLines;
    }
}