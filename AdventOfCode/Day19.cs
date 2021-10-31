using System;
using System.Collections.Generic;
using AdventOfCode.Common;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/19
    /// </summary>
    public class Day19
    {
        public class MonsterMessages
        {
            readonly Dictionary<int, Rule> Rules;

            public MonsterMessages(string[] rawRules)
            {
                Rules = new Dictionary<int, Rule>();

                foreach (var rule in rawRules)
                {
                    ParseRule(rule);
                }

                var rule0 = Rules[0];
                rule0.GetDepths();

                var a = 1;
            }

            private Rule GetOrCreateRule(int number)
            {
                if (Rules.TryGetValue(number, out Rule rule))
                {
                    return rule;
                }

                rule = new Rule(number);
                Rules.Add(number, rule);
                return rule;
            }

            private void ParseRule(string rawRule)
            {
                var parts = rawRule.Split(": ");
                var number = int.Parse(parts[0]);
                var ruleSection = parts[1];

                var mainRule = GetOrCreateRule(number);

                if (ruleSection.Contains('"'))
                {
                    // Letter match rule
                    mainRule.SetValidLetter(ruleSection[1]);
                }
                else
                {
                    // Sub-rules
                    foreach (var set in ruleSection.Split(" | "))
                    {
                        parts = set.Split(' ');
                        var ruleA = GetOrCreateRule(int.Parse(parts[0]));
                        var ruleB = parts.Length == 2 ? GetOrCreateRule(int.Parse(parts[1])) : null;

                        mainRule.AddRuleSet(ruleA, ruleB);
                    }
                }
            }

            

            #region Rule
            private class Rule
            {
                public int Number;
                char Letter;
                Rule SubRuleA1, SubRuleA2, SubRuleB1, SubRuleB2;
                HashSet<int> Depths;

                public Rule(int number)
                {
                    Number = number;
                }

                public void SetValidLetter(char letter)
                {
                    Letter = letter;
                    Depths = new HashSet<int>() { 1 };
                }

                public void AddRuleSet(Rule rule1, Rule rule2 = null)
                {
                    if (SubRuleA1 == null)
                    {
                        SubRuleA1 = rule1;
                        SubRuleA2 = rule2;
                    } 
                    else
                    {
                        SubRuleB1 = rule1;
                        SubRuleB2 = rule2;
                    }
                }

                public bool IsValid (char[] message, out int numValid)
                {
                    numValid = 0;
                    // Rule checks only one letter
                    if (SubRuleA1 == null)
                    {
                        if (message[0] == Letter)
                        {
                            numValid = 1;
                            return true;
                        }
                        return false;
                    }
                    // Rule has sub-rules to check
                    return false;
                }

                public HashSet<int> GetDepths()
                {
                    if (Depths != null)
                    {
                        return Depths;
                    }

                    // Sub rules A
                    if (SubRuleA2 == null)
                    {
                        Depths = new HashSet<int>();
                        Depths.UnionWith(SubRuleA1.GetDepths());
                    } 
                    else
                    {
                        Common.Common.SumOfHashsetContent(SubRuleA1.GetDepths(), SubRuleA2.GetDepths());
                    }

                    // Sub rules B
                    if (SubRuleB1 != null)
                    {
                        var depths = SubRuleB2 == null ? SubRuleB1.GetDepths() : Common.Common.SumOfHashsetContent(SubRuleB1.GetDepths(), SubRuleB2.GetDepths());
                        Depths.UnionWith(depths);
                    }

                    return Depths;
                }

                public override string ToString()
                {
                    if (SubRuleA1 == null)
                    {
                        return $"{Number}: \"{Letter}\"";
                    }

                    return $"{Number}: SubRules";
                }
                #endregion

                public class RuleSet
                {
                    Rule RuleA, RuleB;

                    public RuleSet(Rule ruleA, Rule ruleB = null)
                    {
                        RuleA = ruleA;
                        RuleB = ruleB;
                    }
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var split = input.IndexOf(string.Format("{0}{0}", Environment.NewLine));
            var rawRules = input.Substring(0, split);
            var rawImages = input.Substring(split + 2);

            var mm = new MonsterMessages(rawRules.Split(Environment.NewLine));

            return input + "_Puzzle1";
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return input + "_Puzzle2";
        }
    }
}
