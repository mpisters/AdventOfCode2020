using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Schema;
using AdventOfCode2020.Common;

namespace AdventOfCode2020.Solutions.Day4;

public class Day4
{
    public int ValidatePassportsPart1(string fileName)
    {
        var lines = ParseFile.GetBlockOfLines("Day4", fileName);
        var checkedFields = new List<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
        var invalidPassports = 0;
        foreach (var passwordFile in lines)
        {
            var hasAllFields = checkedFields.Select(x => passwordFile.Contains(x)).All(i => i == true);
            if (!hasAllFields)
            {
                invalidPassports++;
            }
        }

        return lines.Length - invalidPassports;
    }

    public int ValidatePassports2(string fileName)
    {
        var lines = ParseFile.GetBlockOfLines("Day4", fileName);
        
        var passportWithFields = lines.Select(x =>
        {
            var splittedText = x.Replace("\n", " ");
            var keyValueStrings = splittedText.Split(" ");
            return keyValueStrings;
        }).ToList();
        var validPassports = 0;
        for (var i = 0; i < passportWithFields.Count; i++)
        {
            var json = "";
            var passportWithField = passportWithFields[i];
            for (var j = 0; j < passportWithField.Count(); j++)
            {
                var keyValue = passportWithField[j];
                var items = keyValue.Split(':');
                var isInt = items[0] is "byr" or "iyr" or "eyr";
                var value = isInt ? $"{int.Parse(items[1])}" : $"\"{items[1]}\"";
                if (j + 1 == passportWithField.Length)
                {
                    json += $"\"{items[0]}\":{value}";
                }
                else
                {
                    json += $"\"{items[0]}\":{value},\n";
                }
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            
            json = $"{{{json}}}";
            var passport =  JsonSerializer.Deserialize<Passport>(json, options);

            if (passport == null )
            {
                continue;
            }
            var validationContext = new ValidationContext(passport);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(passport, validationContext, validationResults, true);
            if (isValid == true )
            {
                validPassports++;
            }
            
        }
        return validPassports;
    }

    public class ValidHeightAttribute : ValidationAttribute
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
    
    public class ValidEyeColorAttribute : ValidationAttribute
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
    public record Passport(
        [Required, Range(1920, 2002)] int Byr,
        [Required, Range(2010, 2020)] int Iyr,
        [Required, Range(2020, 2030)] int Eyr,
        [Required, ValidHeight] string Hgt,
        [Required, ValidEyeColor] string Ecl,
        [Required, RegularExpression("^#[a-z0-9]{6}$")] string Hcl,
        [Required, RegularExpression("^[0-9]{9}$")] string Pid, 
        string Cid);
}