using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day17Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "17";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format(".#.{0}..#{0}###", Environment.NewLine);
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
            var result = AdventOfCode.Day17.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("271", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Act
            var result = AdventOfCode.Day17.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("112", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day17.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual("2064", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Act
            var result = AdventOfCode.Day17.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual("848", result);
        }
    }
}
