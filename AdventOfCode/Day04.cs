using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/4
    /// </summary>
    public class Day04
    {
        public class PassportScanner
        {
            private readonly List<Passport> Passports;

            public PassportScanner(string rawInput)
            {
                Passports = new List<Passport>();

                var rawPass = rawInput.Split(string.Format("{0}{0}", Environment.NewLine));
                foreach (var pass in rawPass)
                {
                    var fields = (pass.Replace(Environment.NewLine, " ")).Split(' ');
                    Passports.Add(new Passport(fields));
                }
            }

            public int NumValidPassports(bool strict = false)
            {
                var valid = 0;
                foreach (var pass in Passports)
                {
                    if ((!strict && pass.IsValidSimple()) || strict && pass.IsValidStrict())
                    {
                        valid++;
                    }
                }

                return valid;
            }
        }

        public class Passport
        {
            public readonly string BirthYear;
            public readonly string IssueYear;
            public readonly string ExpirationYear;
            public readonly string Height;
            public readonly string HairColor;
            public readonly string EyeColor;
            public readonly string PassportId;
            public readonly string CountryId;

            public Passport(string[] fields)
            {
                foreach (var field in fields)
                {
                    var parts = field.Split(':');
                    switch (parts[0])
                    {
                        case "byr":
                            BirthYear = parts[1];
                            break;
                        case "iyr":
                            IssueYear = parts[1];
                            break;
                        case "eyr":
                            ExpirationYear = parts[1];
                            break;
                        case "hgt":
                            Height = parts[1];
                            break;
                        case "hcl":
                            HairColor = parts[1];
                            break;
                        case "ecl":
                            EyeColor = parts[1];
                            break;
                        case "pid":
                            PassportId = parts[1];
                            break;
                        case "cid":
                            CountryId = parts[1];
                            break;
                        default:
                            throw new ArgumentException($"Unknown password field [{parts[0]}]");
                    }
                }
            }

            public bool IsValidSimple()
            {
                if (BirthYear == null 
                    || IssueYear == null 
                    || ExpirationYear == null 
                    || Height == null 
                    || HairColor == null 
                    || EyeColor == null 
                    || PassportId == null )
                {
                    return false;
                }

                return true;
            }

            public bool IsValidStrict()
            {
                if (!IsValidSimple())
                {
                    return false;
                }

                // Years
                if (!Common.Common.StringIsIntInRange(BirthYear, 1920, 2002))
                {
                    return false;
                }
                if (!Common.Common.StringIsIntInRange(IssueYear, 2010, 2020))
                {
                    return false;
                }
                if (!Common.Common.StringIsIntInRange(ExpirationYear, 2020, 2030))
                {
                    return false;
                }
                // Height
                var ending = Height.Substring(Height.Length - 2);
                if (ending == "cm")
                {
                    if (!Common.Common.StringIsIntInRange(Height.Substring(0, Height.Length - 2), 150, 193))
                    {
                        return false;
                    }
                }
                else if (ending == "in")
                {
                    if (!Common.Common.StringIsIntInRange(Height.Substring(0, Height.Length - 2), 59, 76))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                // Hair Color
                if (HairColor.Length != 7 
                    || HairColor[0] != '#'
                    || !Int32.TryParse(HairColor.Substring(1), System.Globalization.NumberStyles.HexNumber, null, out _))
                {
                    return false;
                }
                // Eye Color 
                if (!new HashSet<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(EyeColor))
                {
                    return false;
                }
                // Passport ID
                if (PassportId.Length != 9 || !Int32.TryParse(PassportId, out _))
                {
                    return false;
                }

                return true;
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var ps = new PassportScanner(input);
            var valid = ps.NumValidPassports();
            return valid.ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var ps = new PassportScanner(input);
            var valid = ps.NumValidPassports(strict:true);
            return valid.ToString();
        }
    }
}
