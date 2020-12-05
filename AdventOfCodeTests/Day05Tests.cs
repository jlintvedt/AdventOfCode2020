using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day05Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "05";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("BFFFBBFRRR{0}FFFBBBFRRR{0}BBFFBBFRLL", Environment.NewLine);
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
            var result = AdventOfCode.Day05.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("888", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Act
            var result = AdventOfCode.Day05.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("820", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day05.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"{input_puzzle}_Puzzle2", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Act
            var result = AdventOfCode.Day05.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual($"{input_example2}_Puzzle2", result);
        }

        // BoardingPass
        [TestMethod]
        public void BoardingPass_CorrectSeat()
        {
            // Arrange
            var seat1 = "FBFBBFFRLR";
            var seat2 = "BFFFBBFRRR";
            var seat3 = "FFFBBBFRRR";
            var seat4 = "BBFFBBFRLL";

            // Act & assert
            var bp = new AdventOfCode.Day05.BoardingPass(seat1);
            Assert.AreEqual(44, bp.row);
            Assert.AreEqual(5, bp.column);
            Assert.AreEqual(357, bp.seatId);

            bp = new AdventOfCode.Day05.BoardingPass(seat2);
            Assert.AreEqual(70, bp.row);
            Assert.AreEqual(7, bp.column);
            Assert.AreEqual(567, bp.seatId);

            bp = new AdventOfCode.Day05.BoardingPass(seat3);
            Assert.AreEqual(14, bp.row);
            Assert.AreEqual(7, bp.column);
            Assert.AreEqual(119, bp.seatId);

            bp = new AdventOfCode.Day05.BoardingPass(seat4);
            Assert.AreEqual(102, bp.row);
            Assert.AreEqual(4, bp.column);
            Assert.AreEqual(820, bp.seatId);
        }
    }
}
