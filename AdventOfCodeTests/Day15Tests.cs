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
        private string input_example3;
        private string input_example4;
        private string input_example5;
        private string input_example6;
        private string input_example7;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "15";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("0,3,6");
            input_example2 = string.Format("1,3,2");
            input_example3 = string.Format("2,1,3");
            input_example4 = string.Format("1,2,3");
            input_example5 = string.Format("2,3,1");
            input_example6 = string.Format("3,2,1");
            input_example7 = string.Format("3,1,2");
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
            // Act & Assert
            Assert.AreEqual("436", AdventOfCode.Day15.Puzzle1(input_example1));
            Assert.AreEqual("1", AdventOfCode.Day15.Puzzle1(input_example2));
            Assert.AreEqual("10", AdventOfCode.Day15.Puzzle1(input_example3));
            Assert.AreEqual("27", AdventOfCode.Day15.Puzzle1(input_example4));
            Assert.AreEqual("78", AdventOfCode.Day15.Puzzle1(input_example5));
            Assert.AreEqual("438", AdventOfCode.Day15.Puzzle1(input_example6));
            Assert.AreEqual("1836", AdventOfCode.Day15.Puzzle1(input_example7));
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day15.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual("6007666", result);
        }

        [Ignore]
        [TestMethod]
        public void Puzzle2_Example()
        {
            Assert.AreEqual("175594", AdventOfCode.Day15.Puzzle2(input_example1));
            Assert.AreEqual("2578", AdventOfCode.Day15.Puzzle2(input_example2));
            Assert.AreEqual("3544142", AdventOfCode.Day15.Puzzle2(input_example3));
            Assert.AreEqual("261214", AdventOfCode.Day15.Puzzle2(input_example4));
            Assert.AreEqual("6895259", AdventOfCode.Day15.Puzzle2(input_example5));
            Assert.AreEqual("18", AdventOfCode.Day15.Puzzle2(input_example6));
            Assert.AreEqual("362", AdventOfCode.Day15.Puzzle2(input_example7));
        }
    }
}
