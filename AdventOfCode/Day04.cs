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
            private List<Passport> Passports;

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

            public int NumValidPassports()
            {
                var valid = 0;
                foreach (var pass in Passports)
                {
                    if (pass.IsValid(optionalCid:true))
                    {
                        valid++;
                    }
                }

                return valid;
            }
        }

        public class Passport
        {
            public string BirthYear;
            public string IssueYear;
            public string ExpirationYear;
            public string Height;
            public string HairColor;
            public string EyeColor;
            public string PassportId;
            public string CountryId;

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

            public bool IsValid(bool optionalCid = false)
            {
                if (BirthYear == null 
                    || IssueYear == null 
                    || ExpirationYear == null 
                    || Height == null 
                    || HairColor == null 
                    || EyeColor == null 
                    || PassportId == null 
                    || (!optionalCid && CountryId == null))
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
            return input + "_Puzzle2";
        }
    }
}
