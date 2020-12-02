using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day02Tests
    {
        private string input_puzzle;
        private string input_example1;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "02";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("1-3 a: abcde{0}1-3 b: cdefg{0}2-9 c: ccccccccc", Environment.NewLine);
        }

        [TestMethod]
        public void Puzzle0_WarmUp()
        {
            // Force performing LoadInput() warm-up as part of this test
            var pd = new AdventOfCode.Day02.PasswordDatabase(new string[] { "1-3 a: abcde" });
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day02.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("625", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Act
            var result = AdventOfCode.Day02.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day02.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual("391", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Act
            var result = AdventOfCode.Day02.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual("1", result);
        }

        // Password Database
        [TestMethod]
        public void Password_IsValid()
        {
            // Act & Assert
            Assert.IsTrue((new AdventOfCode.Day02.PasswordDatabase.Password("6-10 j: jjjjjjjjjj")).IsValid);
        }
    }
}
