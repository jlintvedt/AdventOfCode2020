using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day11Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "11";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("L.LL.LL.LL{0}LLLLLLL.LL{0}L.L.L..L..{0}LLLL.LL.LL{0}L.LL.LL.LL{0}L.LLLLL.LL{0}..L.L.....{0}LLLLLLLLLL{0}L.LLLLLL.L{0}L.LLLLL.LL", Environment.NewLine);
            input_example2 = string.Format("example{0}2", Environment.NewLine);
        }

        [TestMethod]
        public void Puzzle0_WarmUp()
        {
            // Force performing LoadInput() warm-up as part of this test
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day11.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("2319", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Act
            var result = AdventOfCode.Day11.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("37", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day11.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"{input_puzzle}_Puzzle2", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Act
            var result = AdventOfCode.Day11.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual($"{input_example2}_Puzzle2", result);
        }
    }
}
