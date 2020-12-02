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
            public int NumValidPasswords;

            public PasswordDatabase(string[] passwordAndPolicies, bool isToboggan=false)
            {
                Passwords = new List<Password>();
                foreach (var pp in passwordAndPolicies)
                {
                    var pw = new Password(pp, isToboggan);
                    Passwords.Add(pw);
                    if (pw.IsValid)
                    {
                        NumValidPasswords++;
                    }
                }
            }

            public class Password
            {
                public string String;
                public bool IsValid;

                public Password(string input, bool isToboggan=false)
                {
                    // Extract password string
                    var parts = input.Split(new char[] { '-', ' ', ':' });
                    String = parts[4];

                    // Validate password
                    IsValid = isToboggan ? GetIsValidToboggan(parts) : GetIsValidOld(parts);
                }

                public bool GetIsValidOld(string[] policyParts)
                {
                    // Parse Policy
                    char policyChar = policyParts[2].ToCharArray()[0];
                    var policyMin = Int32.Parse(policyParts[0]);
                    var policyMax = Int32.Parse(policyParts[1]);

                    // Validate password
                    int count = String.Split(policyChar).Length - 1;
                    return policyMin <= count && count <= policyMax ? true : false;
                }

                public bool GetIsValidToboggan(string[] policyParts)
                {
                    // Parse Policy
                    char policyChar = policyParts[2].ToCharArray()[0];
                    var indexOne = Int32.Parse(policyParts[0]) - 1;
                    var indexTwo = Int32.Parse(policyParts[1]) - 1;

                    // Validate password
                    var matchOne = String[indexOne] == policyChar;
                    var matchTwo = String[indexTwo] == policyChar;
                    return matchOne ^ matchTwo;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var passwordAndPolicies = input.Split(Environment.NewLine);
            var pd = new PasswordDatabase(passwordAndPolicies);
            return pd.NumValidPasswords.ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var passwordAndPolicies = input.Split(Environment.NewLine);
            var pd = new PasswordDatabase(passwordAndPolicies, isToboggan:true);
            return pd.NumValidPasswords.ToString();
        }
    }
}
