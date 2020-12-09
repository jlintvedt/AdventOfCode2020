using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day09Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "09";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("35{0}20{0}15{0}25{0}47{0}40{0}62{0}55{0}65{0}95{0}102{0}117{0}150{0}182{0}127{0}219{0}299{0}277{0}309{0}576", Environment.NewLine);
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
            var result = AdventOfCode.Day09.Puzzle1(input_puzzle);
            
            // Assert
            Assert.AreEqual("41682220", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Arrange - Must test directly on class as it uses another preamble length
            var xc = new AdventOfCode.Day09.XmasCypher(input_example1, 5);
            var result = xc.FindFirstWeakness().ToString();

            // Assert
            Assert.AreEqual("127", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day09.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"{input_puzzle}_Puzzle2", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Act
            var result = AdventOfCode.Day09.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual($"{input_example2}_Puzzle2", result);
        }
    }
}
