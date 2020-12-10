using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day10Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "10";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("16{0}10{0}15{0}5{0}1{0}11{0}7{0}19{0}6{0}12{0}4", Environment.NewLine);
            input_example2 = string.Format("28{0}33{0}18{0}42{0}31{0}14{0}46{0}20{0}48{0}47{0}24{0}23{0}49{0}45{0}19{0}38{0}39{0}11{0}1{0}32{0}25{0}35{0}8{0}17{0}7{0}9{0}4{0}2{0}34{0}10{0}3", Environment.NewLine);
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
            var result = AdventOfCode.Day10.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("1914", result);
        }

        [TestMethod]
        public void Puzzle1_Example1()
        {
            // Act
            var result = AdventOfCode.Day10.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("35", result);
        }

        [TestMethod]
        public void Puzzle1_Example2()
        {
            // Act
            var result = AdventOfCode.Day10.Puzzle1(input_example2);

            // Assert
            Assert.AreEqual("220", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day10.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual("9256148959232", result);
        }

        [TestMethod]
        public void Puzzle2_Example1()
        {
            // Act
            var result = AdventOfCode.Day10.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual("8", result);
        }

        [TestMethod]
        public void Puzzle2_Example2()
        {
            // Act
            var result = AdventOfCode.Day10.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual("19208", result);
        }
    }
}
