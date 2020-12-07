using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day07Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "07";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("light red bags contain 1 bright white bag, 2 muted yellow bags.{0}dark orange bags contain 3 bright white bags, 4 muted yellow bags.{0}bright white bags contain 1 shiny gold bag.{0}muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.{0}shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.{0}dark olive bags contain 3 faded blue bags, 4 dotted black bags.{0}vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.{0}faded blue bags contain no other bags.{0}dotted black bags contain no other bags.", Environment.NewLine);
            input_example2 = string.Format("shiny gold bags contain 2 dark red bags.{0}dark red bags contain 2 dark orange bags.{0}dark orange bags contain 2 dark yellow bags.{0}dark yellow bags contain 2 dark green bags.{0}dark green bags contain 2 dark blue bags.{0}dark blue bags contain 2 dark violet bags.{0}dark violet bags contain no other bags.", Environment.NewLine);
        }

        [TestMethod]
        public void Puzzle0_WarmUp()
        {
            // Force performing LoadInput() warm-up as part of this test
            var bp = new AdventOfCode.Day07.BaggageProcessing(input_example1.Split(Environment.NewLine));
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day07.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("229", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Act
            var result = AdventOfCode.Day07.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day07.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual("6683", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Act
            var result = AdventOfCode.Day07.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual("126", result);
        }
    }
}
