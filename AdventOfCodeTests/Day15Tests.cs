using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day15Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "15";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("0,3,6");
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
            var result = AdventOfCode.Day15.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("852", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Act
            var result = AdventOfCode.Day15.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("436", result);
        }

        [TestMethod]
        public void Puzzle1_Examples()
        {
            // Act & Assert
            Assert.AreEqual("1", AdventOfCode.Day15.Puzzle1("1,3,2"));
            Assert.AreEqual("10", AdventOfCode.Day15.Puzzle1("2,1,3"));
            Assert.AreEqual("27", AdventOfCode.Day15.Puzzle1("1,2,3"));
            Assert.AreEqual("78", AdventOfCode.Day15.Puzzle1("2,3,1"));
            Assert.AreEqual("438", AdventOfCode.Day15.Puzzle1("3,2,1"));
            Assert.AreEqual("1836", AdventOfCode.Day15.Puzzle1("3,1,2"));
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day15.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"{input_puzzle}_Puzzle2", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Act
            var result = AdventOfCode.Day15.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual($"{input_example2}_Puzzle2", result);
        }
    }
}
