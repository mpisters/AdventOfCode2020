namespace AdventOfCode2020.Common;

public static class ParseFile
{
    public static string[] GetLines(string folderName, string fileName)
    {
        var folderPath = $"/{folderName}/";
        var path = Path.Combine(Environment.CurrentDirectory + folderPath, fileName); 
        return File.ReadAllLines(path);
    }
}