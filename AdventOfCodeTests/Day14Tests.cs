using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day14Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "14";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X{0}mem[8] = 11{0}mem[7] = 101{0}mem[8] = 0", Environment.NewLine);
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
            var result = AdventOfCode.Day14.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("5055782549997", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Act
            var result = AdventOfCode.Day14.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("165", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day14.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"{input_puzzle}_Puzzle2", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Act
            var result = AdventOfCode.Day14.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual($"{input_example2}_Puzzle2", result);
        }

        // == == == == == Puzzle 1 == == == == ==
        [TestMethod]
        public void DockingProgram_TestInput()
        {
            // Arrange
            var dp = new AdventOfCode.Day14.DockingProgram("");

            // Act & Assert
            dp.ExecuteRawInstruction("mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            dp.ExecuteRawInstruction("mem[1] = 4294967295");
            Assert.AreEqual(uint.MaxValue, dp.Memory[1]);
            dp.ExecuteRawInstruction("mem[2] = 0");
            Assert.AreEqual(uint.MinValue, dp.Memory[2]);

            dp.ExecuteRawInstruction("mask = 111111111111111111111111111111111111");
            dp.ExecuteRawInstruction("mem[1] = 4294967295");
            Assert.AreEqual((ulong)68719476735, dp.Memory[1]);
            dp.ExecuteRawInstruction("mem[2] = 0");
            Assert.AreEqual((ulong)68719476735, dp.Memory[2]);
        }
    }
}
