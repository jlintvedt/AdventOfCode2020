using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day19Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "19";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format(@"0: 4 1 5{0}1: 2 3 | 3 2{0}2: 4 4 | 5 5{0}3: 4 5 | 5 4{0}4: ""a""{0}5: ""b""{0}{0}ababbb{0}bababa{0}abbbab{0}aaabbb{0}aaaabbb", Environment.NewLine);
            input_example2 = string.Format("example{0}2", Environment.NewLine);
        }

        [TestMethod]
        public void Begin_WarmUp()
        {
            // Force performing LoadInput() warm-up as part of this test
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day19.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"{input_puzzle}_Puzzle1", result);
        }

        [TestMethod]
        public void Example_Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day19.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"{input_example1}_Puzzle1", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day19.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"{input_puzzle}_Puzzle2", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day19.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual($"{input_example2}_Puzzle2", result);
        }
    }
}
