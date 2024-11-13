using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Schema;
using AdventOfCode2020.Common;

namespace AdventOfCode2020.Solutions.Day4;

public class Day4
{
    private readonly List<string> _requiredFields = new List<string>()
        { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

    public int ValidatePassportsPart1(string fileName)
    {
        var lines = ParseFile.GetBlockOfLines("Day4", fileName);
        var invalidPassports = 0;
        foreach (var passwordFile in lines)
        {
            var hasAllFields = _requiredFields.Select(x => passwordFile.Contains(x)).All(i => i == true);
            if (!hasAllFields)
            {
                invalidPassports++;
            }
        }

        return lines.Length - invalidPassports;
    }

    public int ValidatePassports2(string fileName)
    {
        // Not optimised in any way. Only for learning purposes.
        var lines = ParseFile.GetBlockOfLines("Day4", fileName);
        var parsedPassports = ParsePassports(lines);

        var validPassports = 0;
        foreach (var parsedPassport in parsedPassports)
        {
            var json = CreatePassportJson(parsedPassport);

            var passport = JsonSerializer.Deserialize<Passport>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            if (passport == null)
            {
                continue;
            }

            var (isValid, errors) = IsValidPassport(passport);

            if (isValid)
            {
                validPassports++;
            }
        }

        return validPassports;
    }

    private static List<string[]> ParsePassports(string[] lines)
    {
        var parsedPassports = lines.Select(x =>
        {
            var splittedText = x.Replace("\n", " ");
            var keyValueStrings = splittedText.Split(" ");
            return keyValueStrings;
        }).ToList();
        return parsedPassports;
    }

    private static string CreatePassportJson(string[] parsedPassport)
    {
        var json = "";

        for (var j = 0; j < parsedPassport.Count(); j++)
        {
            var keyValue = parsedPassport[j];
            var items = keyValue.Split(':');
            var isInt = items[0] is "byr" or "iyr" or "eyr";
            var value = isInt ? $"{int.Parse(items[1])}" : $"\"{items[1]}\"";
            if (j + 1 == parsedPassport.Length)
            {
                json += $"\"{items[0]}\":{value}";
            }
            else
            {
                json += $"\"{items[0]}\":{value},\n";
            }
        }

        json = $"{{{json}}}";
        return json;
    }

    public Tuple<bool, List<ValidationResult>> IsValidPassport(Passport passport)
    {
        var validationResults = new List<ValidationResult>();
        var isValid =
            Validator.TryValidateObject(passport, new ValidationContext(passport), validationResults, true);
        return new(isValid, validationResults);
    }

    private class ValidHeightAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)

        {
            if (value == null)
            {
                return false;
            }

            if (value.ToString().EndsWith("in"))
            {
                var height = int.Parse(value.ToString().Replace("in", ""));
                return height >= 59 && height <= 76;
            }

            if (value.ToString().EndsWith("cm"))
            {
                var height = int.Parse(value.ToString().Replace("cm", ""));
                return height >= 150 && height <= 193;
            }

            return false;
        }
    }

    private class ValidEyeColorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)

        {
            if (value == null)
            {
                return false;
            }

            var eyeColors = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            var eyeColorFound = value.ToString();
            return eyeColors.Contains(eyeColorFound);
        }
    }

    public class Passport
    {
        [Required, Range(1920, 2002)] public int Byr { get; set; }

        [Required, Range(2010, 2020)] public int Iyr { get; set; }
        [Required, Range(2020, 2030)] public int Eyr { get; set; }
        [Required, ValidHeight] public string Hgt { get; set; }
        [Required, ValidEyeColor] public string Ecl { get; set; }

        [Required, RegularExpression("^#[a-z0-9]{6}$")]
        public string Hcl { get; set; }

        [Required, RegularExpression("^[0-9]{9}$")]
        public string Pid { get; set; }

        public string? Cid { get; set; }
    }
}