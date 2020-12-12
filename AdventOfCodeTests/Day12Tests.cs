using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day12Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "12";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("F10{0}N3{0}F7{0}R90{0}F11", Environment.NewLine);
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
            var result = AdventOfCode.Day12.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("1032", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Act
            var result = AdventOfCode.Day12.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("25", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day12.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"{input_puzzle}_Puzzle2", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Act
            var result = AdventOfCode.Day12.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual($"{input_example2}_Puzzle2", result);
        }

        // == == == == == Ferry == == == == ==
        [TestMethod]
        public void Ferry_ExecuteInstructions()
        {
            // Arrange
            var ferry = new AdventOfCode.Day12.Ferry("N3");

            // Act & Assert
            Assert.AreEqual((0, 0), ferry.pos);
        }
    }
}
