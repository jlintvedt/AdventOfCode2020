using AdventOfCode.Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AdventOfCodeTests
{
    [TestClass]
    public class CommonTests
    {
        [TestMethod]
        public void ParseStringToIntArray_NonDelimitedString()
        {
            // Arrange
            var input = "1234321";
            var expected = new int[] { 1, 2, 3, 4, 3, 2, 1 };

            // Act
            var output = Common.ParseStringToIntArray(input);

            // Assert
            CollectionAssert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ParseStringToIntArray_SpaceDelimitedString()
        {
            // Arrange
            var input = "1 2 3 4 3 2 1";
            var expected = new int[] { 1, 2, 3, 4, 3, 2, 1 };

            // Act
            var output = Common.ParseStringToIntArray(input, " ");

            // Assert
            CollectionAssert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ParseStringToIntArray_NewlineDelimitedString()
        {
            // Arrange
            var input = "1 2 3 4 3 2 1".Replace(" ", Environment.NewLine);
            var expected = new int[] { 1, 2, 3, 4, 3, 2, 1 };

            // Act
            var output = Common.ParseStringToIntArray(input, Environment.NewLine);

            // Assert
            CollectionAssert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ParseStringToLongArray()
        {
            // Arrange
            var input_spaceDelim = "1 2 3 4 3 2 1";
            var input_newlineDelim = "1 2 3 4 3 2 1".Replace(" ", Environment.NewLine);
            var expected = new long[] { 1, 2, 3, 4, 3, 2, 1 };
            var expected_long = new long[] { long.MinValue, ((long)int.MaxValue+(long)10), long.MaxValue };
            var input_long = string.Format("{1}{0}{2}{0}{3}", Environment.NewLine, expected_long[0], expected_long[1], expected_long[2]);

            // Act && Assert
            CollectionAssert.AreEqual(expected, Common.ParseStringToLongArray(input_spaceDelim, " "));
            CollectionAssert.AreEqual(expected, Common.ParseStringToLongArray(input_newlineDelim, Environment.NewLine));
            CollectionAssert.AreEqual(expected_long, Common.ParseStringToLongArray(input_long, Environment.NewLine));
        }

        [TestMethod]
        public void ParseStringToJaggedIntArray_CommaAndSpaceDelim()
        {
            // Arrange
            var input = "1 2 3,4 5 6,7 8 9";
            var expected = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            };

            // Act
            var output = Common.ParseStringToJaggedIntArray(input, ",", " ");

            // Assert
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], output[i]);
            }
        }

        [TestMethod]
        public void ParseStringToJaggedIntArray_NewlineAndTabDelim()
        {
            // Arrange
            var input = string.Format("1{1}2{1}3{0}4{1}5{1}6{0}7{1}8{1}9", Environment.NewLine, "\t");
            var expected = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            };

            // Act
            var output = Common.ParseStringToJaggedIntArray(input, Environment.NewLine, "\t");

            // Assert
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], output[i]);
            }
        }

        [TestMethod]
        public void ParseStringToJaggedStringArray_NewlineAndCommaDelim()
        {
            // Arrange
            var input = string.Format("1{1}2{1}3{0}4{1}5{1}6{0}7{1}8{1}9", Environment.NewLine, ",");
            var expected = new string[][]
            {
                new string[] { "1", "2", "3" },
                new string[] { "4", "5", "6" },
                new string[] { "7", "8", "9" }
            };

            // Act
            var output = Common.ParseStringToJaggedStringArray(input, Environment.NewLine, ",");

            // Assert
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], output[i]);
            }
        }

        [TestMethod]
        public void ConvertHexStringToBitArray_ValidInput()
        {
            // Arrange
            var expected_a = new int[] { 1, 0, 1, 0 };
            var expected_abc = new int[] { 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 0 };
            var expected_09af = new int[] { 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1 };

            // Act & Assert
            CollectionAssert.AreEqual(expected_a, Common.ConvertHexStringToBitArray("a"));
            CollectionAssert.AreEqual(expected_abc, Common.ConvertHexStringToBitArray("abc"));
            CollectionAssert.AreEqual(expected_09af, Common.ConvertHexStringToBitArray("09af"));
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException))]
        public void ConvertHexStringToBitArray_InvalidInput()
        {
            // Act
            Common.ConvertHexStringToBitArray("x");
        }

        [TestMethod]
        public void IntToArray_ValidInput()
        {
            // Arrange
            var input = 123456;
            var expected = new int[] { 1, 2, 3, 4, 5, 6 };

            // Act
            var result = Common.IntToTokenizedArray(input);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IntToArray_InvalidInput()
        {
            // Arrange
            Action actTooLow = () => Common.IntToTokenizedArray(12345);
            Action actTooHigh = () => Common.IntToTokenizedArray(1234567);

            // Act & Assert
            actTooLow.Should().Throw<ArgumentException>();
            actTooHigh.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void IntArrayToInt_ValidInput()
        {
            // Arrange
            var input = new int[6] { 1, 2, 3, 4, 5, 6 };
            var expected = 123456;

            // Act
            var result = Common.IntArrayToInt(input);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IntArrayToInt_InvalidInput()
        {
            // Arrange
            Action actTooShort = () => Common.IntArrayToInt(new int[5] { 1, 2, 3, 4, 5 });
            Action actTooLong = () => Common.IntArrayToInt(new int[7] { 1, 2, 3, 4, 5, 6, 7 });

            // Act & Assert
            actTooShort.Should().Throw<ArgumentException>();
            actTooLong.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void TwoDimIntArrayToString()
        {
            //Arrange
            var oneRow = new int[,] { { 1, 2, 3 } };
            var twoByTwo = new int[,] { { 1, 2 }, { 3, 4 } };
            var oneColumn = new int[,] { { 1 }, { 2 }, { 3 }, { 4 },{ 5 } };

            // Act & Assert
            Assert.AreEqual("123", Common.TwoDimIntArrayToString(oneRow));
            Assert.AreEqual("1234", Common.TwoDimIntArrayToString(twoByTwo));
            Assert.AreEqual("12345", Common.TwoDimIntArrayToString(oneColumn));
        }

        [TestMethod]
        public void StringIsIntInRange()
        {
            //Arrange
            var min = 150;
            var max = 190;
            var invalid = new string[] { null, "notInt" };
            var toSmall = new string[] { "1", "149" };
            var inRange = new string[] { "150", "170", "190" };
            var toLarge = new string[] { "191", "200" };

            // Act & Assert
            foreach (var val in invalid)
            {
                Assert.IsFalse(Common.StringIsIntInRange(val, min, max));
            }
            foreach (var val in toSmall)
            {
                Assert.IsFalse(Common.StringIsIntInRange(val, min, max));
            }
            foreach (var val in inRange)
            {
                Assert.IsTrue(Common.StringIsIntInRange(val, min, max));
            }
            foreach (var val in toLarge)
            {
                Assert.IsFalse(Common.StringIsIntInRange(val, min, max));
            }
        }

        [TestMethod]
        public void SumOfHashsetContent_CorrectExecution()
        {
            // Arrange
            var setA1 = new HashSet<int>() { 1, 2, 3 };
            var setA2 = new HashSet<int>() { 10 };
            var expectedA = new HashSet<int>() { 11, 12, 13 };
            
            var setB1 = new HashSet<int>() { 1, 2, 3 };
            var setB2 = new HashSet<int>() { 10, 20 };
            var expectedB = new HashSet<int>() { 11, 12, 13, 21, 22, 23 };

            var setC1 = new HashSet<int>() { 1, 2, 3 };
            var setC2 = new HashSet<int>() { 1, 2, 3 };
            var expectedC = new HashSet<int>() { 2, 3, 4, 5, 6 };

            // Act and Assert
            var result = Common.SumOfHashsetContent(setA1, setA2);
            Assert.IsTrue(expectedA.SetEquals(result));

            result = Common.SumOfHashsetContent(setB1, setB2);
            Assert.IsTrue(expectedB.SetEquals(result));

            result = Common.SumOfHashsetContent(setC1, setC2);
            Assert.IsTrue(expectedC.SetEquals(result));
        }
    }
}
