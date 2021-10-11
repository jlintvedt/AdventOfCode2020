using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day18Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;
        private string input_example3;
        private string input_example4;
        private string input_example5;
        private string input_example6;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "18";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("1 + 2 * 3 + 4 * 5 + 6", Environment.NewLine);
            input_example2 = string.Format("1 + (2 * 3) + (4 * (5 + 6))", Environment.NewLine);
            input_example3 = string.Format("2 * 3 + (4 * 5)", Environment.NewLine);
            input_example4 = string.Format("5 + (8 * 3 + 9 + 3 * 4 * 3)", Environment.NewLine);
            input_example5 = string.Format("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", Environment.NewLine);
            input_example6 = string.Format("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", Environment.NewLine);
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
            var result = AdventOfCode.Day18.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("280014646144", result);
        }

        [TestMethod]
        public void Example_Puzzle1()
        {
            // Act & Assert
            Assert.AreEqual("71", AdventOfCode.Day18.Puzzle1(input_example1));
            Assert.AreEqual("51", AdventOfCode.Day18.Puzzle1(input_example2));
            Assert.AreEqual("26", AdventOfCode.Day18.Puzzle1(input_example3));
            Assert.AreEqual("437", AdventOfCode.Day18.Puzzle1(input_example4));
            Assert.AreEqual("12240", AdventOfCode.Day18.Puzzle1(input_example5));
            Assert.AreEqual("13632", AdventOfCode.Day18.Puzzle1(input_example6));
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day18.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"{input_puzzle}_Puzzle2", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day18.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual($"{input_example2}_Puzzle2", result);
        }
    }
}
