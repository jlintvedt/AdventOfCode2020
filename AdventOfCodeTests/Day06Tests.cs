using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day06Tests
    {
        private string input_puzzle;
        private string input_example1;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "06";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("abc{0}{0}a{0}b{0}c{0}{0}ab{0}ac{0}{0}a{0}a{0}a{0}a{0}{0}b", Environment.NewLine);
        }

        [TestMethod]
        public void Puzzle0_WarmUp()
        {
            // Force performing LoadInput() warm-up as part of this test
            var cdf = new AdventOfCode.Day06.CustomsDeclarationForm(new string[] { "a", "b", "c" });
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day06.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("6903", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Act
            var result = AdventOfCode.Day06.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("11", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day06.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual("3493", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Act
            var result = AdventOfCode.Day06.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual("6", result);
        }
    }
}
