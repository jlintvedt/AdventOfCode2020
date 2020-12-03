using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day03Tests
    {
        private string input_puzzle;
        private string input_example1;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "03";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("..##.......{0}#...#...#..{0}.#....#..#.{0}..#.#...#.#{0}.#...##..#.{0}..#.##.....{0}.#.#.#....#{0}.#........#{0}#.##...#...{0}#...##....#{0}.#..#...#.#", Environment.NewLine);
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
            var result = AdventOfCode.Day03.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("191", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Act
            var result = AdventOfCode.Day03.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("7", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day03.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"{input_puzzle}_Puzzle2", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Act
            var result = AdventOfCode.Day03.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual($"{input_example1}_Puzzle2", result);
        }
    }
}
