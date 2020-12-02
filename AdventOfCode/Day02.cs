using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// Template class
    /// https://adventofcode.com/2020/day/2
    /// </summary>
    public class Day02
    {
        public class PasswordDatabase
        {
            public List<Password> Passwords;

            public PasswordDatabase(string[] passwordAndPolicies)
            {
                Passwords = new List<Password>();
                foreach (var pp in passwordAndPolicies)
                {
                    Passwords.Add(new Password(pp));
                }
            }

            public int CountValidPasswords()
            {
                int count = 0;
                foreach (var pw in Passwords)
                {
                    if (pw.IsValid)
                    {
                        count++;
                    }
                }

                return count;
            }

            public class Password
            {
                public bool IsValid;
                public string String;

                public Password(string input)
                {
                    // Extract password string
                    var parts = input.Split(":");
                    String = parts[1].Trim();
                    // Extract Policy
                    parts = parts[0].Split(" ");
                    char policyChar = parts[1].ToCharArray()[0];

                    parts = parts[0].Split("-");
                    var policyMin = Int32.Parse(parts[0]);
                    var policyMax = Int32.Parse(parts[1]);

                    // Validate password
                    int count = String.Split(policyChar).Length - 1;
                    IsValid = policyMin <= count && count <= policyMax ? true : false;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var passwordAndPolicies = input.Split(Environment.NewLine);
            var pd = new PasswordDatabase(passwordAndPolicies);
            return pd.CountValidPasswords().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return input + "_Puzzle2";
        }
    }
}
