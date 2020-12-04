using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day04Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;
        private string input_example3;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "04";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("ecl:gry pid:860033327 eyr:2020 hcl:#fffffd{0}byr:1937 iyr:2017 cid:147 hgt:183cm{0}{0}iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884{0}hcl:#cfa07d byr:1929{0}{0}hcl:#ae17e1 iyr:2013{0}eyr:2024{0}ecl:brn pid:760753108 byr:1931{0}hgt:179cm{0}{0}hcl:#cfa07d eyr:2025 pid:166559648{0}iyr:2011 ecl:brn hgt:59in", Environment.NewLine);
            input_example2 = string.Format("eyr:1972 cid:100{0}hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926{0}{0}iyr:2019{0}hcl:#602927 eyr:1967 hgt:170cm{0}ecl:grn pid:012533040 byr:1946{0}{0}hcl:dab227 iyr:2012{0}ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277{0}{0}hgt:59cm ecl:zzz{0}eyr:2038 hcl:74454a iyr:2023{0}pid:3556412378 byr:2007", Environment.NewLine);
            input_example3 = string.Format("pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980{0}hcl:#623a2f{0}{0}eyr:2029 ecl:blu cid:129 byr:1989{0}iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm{0}{0}hcl:#888785{0}hgt:164cm byr:2001 iyr:2015 cid:88{0}pid:545766238 ecl:hzl{0}eyr:2022{0}{0}iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719", Environment.NewLine);
        }

        [TestMethod]
        public void Puzzle0_WarmUp()
        {
            // Force performing LoadInput() warm-up as part of this test
            var ps = new AdventOfCode.Day04.PassportScanner(input_example1);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day04.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("210", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Act
            var result = AdventOfCode.Day04.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day04.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual("131", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Act
            var noValid = AdventOfCode.Day04.Puzzle2(input_example2);
            var allValid = AdventOfCode.Day04.Puzzle2(input_example3);

            // Assert
            Assert.AreEqual("0", noValid);
            Assert.AreEqual("4", allValid);
        }
    }
}
