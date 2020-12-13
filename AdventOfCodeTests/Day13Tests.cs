using System;
using AdventOfCodeTests.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day13Tests
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
            string day = "13";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("939{0}7,13,x,x,59,x,31,19", Environment.NewLine);
            input_example2 = string.Format("0{0}17,x,13,19", Environment.NewLine);
            input_example3 = string.Format("0{0}67,7,59,61", Environment.NewLine);
            input_example4 = string.Format("0{0}67,x,7,59,61", Environment.NewLine);
            input_example5 = string.Format("0{0}67,7,x,59,61", Environment.NewLine);
            input_example6 = string.Format("0{0}1789,37,47,1889", Environment.NewLine);
        }

        [TestMethod]
        public void Puzzle0_WarmUp()
        {
            // Force performing LoadInput() warm-up as part of this test
            var ss = new AdventOfCode.Day13.ShuttleSearch(input_example1);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day13.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("171", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Act
            var result = AdventOfCode.Day13.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("295", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day13.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual("539746751134958", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Arrange 
            string result;

            // Act & Assert
            result = AdventOfCode.Day13.Puzzle2(input_example1);
            Assert.AreEqual("1068781", result);

            result = AdventOfCode.Day13.Puzzle2(input_example2);
            Assert.AreEqual("3417", result);

            result = AdventOfCode.Day13.Puzzle2(input_example3);
            Assert.AreEqual("754018", result);

            result = AdventOfCode.Day13.Puzzle2(input_example4);
            Assert.AreEqual("779210", result);

            result = AdventOfCode.Day13.Puzzle2(input_example5);
            Assert.AreEqual("1261476", result);

            result = AdventOfCode.Day13.Puzzle2(input_example6);
            Assert.AreEqual("1202161486", result);
        }
    }
}
