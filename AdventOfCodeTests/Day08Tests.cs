using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day08Tests
    {
        private string input_puzzle;
        private string input_example1;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "08";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("nop +0{0}acc +1{0}jmp +4{0}acc +3{0}jmp -3{0}acc -99{0}acc +1{0}jmp -4{0}acc +6", Environment.NewLine);
        }

        [TestMethod]
        public void Puzzle0_WarmUp()
        {
            // Force performing LoadInput() warm-up as part of this test
            var gc = new AdventOfCode.Day08.GameConsole(input_example1);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day08.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("1563", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Act
            var result = AdventOfCode.Day08.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("5", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day08.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual("767", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Act
            var result = AdventOfCode.Day08.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual("8", result);
        }
    }
}
