using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day12Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "12";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("F10{0}N3{0}F7{0}R90{0}F11", Environment.NewLine);
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
            var result = AdventOfCode.Day12.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual("1032", result);
        }

        [TestMethod]
        public void Puzzle1_Example()
        {
            // Act
            var result = AdventOfCode.Day12.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual("25", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day12.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual("156735", result);
        }

        [TestMethod]
        public void Puzzle2_Example()
        {
            // Act
            var result = AdventOfCode.Day12.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual("286", result);
        }

        // == == == == == Ferry == == == == ==
        [TestMethod]
        public void Ferry_ExecuteInstructions()
        {
            // Arrange
            var ferry = new AdventOfCode.Day12.Ferry("N3");
            Dictionary<char, AdventOfCode.Day12.Ferry.Direction> direction = new Dictionary<char, AdventOfCode.Day12.Ferry.Direction>()
            {
                {'N', AdventOfCode.Day12.Ferry.Direction.north }, {'E', AdventOfCode.Day12.Ferry.Direction.east }, {'S', AdventOfCode.Day12.Ferry.Direction.south }, {'W', AdventOfCode.Day12.Ferry.Direction.west }
            };

            // Act & Assert
            Assert.AreEqual((0, 0), ferry.pos);
        }

        [TestMethod]
        public void Ferry_ExecuteInstructionsWaypointMode_Example()
        {
            // Arrange
            var ferry = new AdventOfCode.Day12.Ferry("N3", waypointMode: true);

            // Act & Assert
            Assert.IsTrue(CheckFerryStatus(ferry, (0, 0)));
            Assert.IsTrue(CheckFerryStatus(ferry, waypoint: (10, -1)));

            ferry.ExecuteRawInstruction("F10");
            Assert.IsTrue(CheckFerryStatus(ferry, pos: (100, -10)));

            ferry.ExecuteRawInstruction("N3");
            Assert.IsTrue(CheckFerryStatus(ferry, waypoint: (10, -4)));

            ferry.ExecuteRawInstruction("F7");
            Assert.IsTrue(CheckFerryStatus(ferry, pos: (170, -38)));

            ferry.ExecuteRawInstruction("R90");
            Assert.IsTrue(CheckFerryStatus(ferry, waypoint: (4, 10)));

            ferry.ExecuteRawInstruction("F11");
            Assert.IsTrue(CheckFerryStatus(ferry, pos: (214, 72)));
        }

        [TestMethod]
        public void Ferry_ExecuteInstructionsWaypointMode_RotateWaypoint()
        {
            // Arrange
            var ferry = new AdventOfCode.Day12.Ferry("N3", waypointMode: true);
            var waypoints = new Dictionary<string, (int, int)>()
            {
                {"NE", (10,-1) }, {"SE", (1,10) },{"SW", (-10,1) },{"NW", (-1,-10) }
            };

            // Act & Assert
            Assert.IsTrue(CheckFerryStatus(ferry, (0, 0)));
            Assert.IsTrue(CheckFerryStatus(ferry, waypoint: waypoints["NE"]));

            ferry.ExecuteRawInstruction("R90");
            Assert.IsTrue(CheckFerryStatus(ferry, waypoint: waypoints["SE"]));
            
            ferry.ExecuteRawInstruction("R180");
            Assert.IsTrue(CheckFerryStatus(ferry, waypoint: waypoints["NW"]));

            ferry.ExecuteRawInstruction("R270");
            Assert.IsTrue(CheckFerryStatus(ferry, waypoint: waypoints["SW"]));

            ferry.ExecuteRawInstruction("L90");
            Assert.IsTrue(CheckFerryStatus(ferry, waypoint: waypoints["SE"]));

            ferry.ExecuteRawInstruction("L90");
            Assert.IsTrue(CheckFerryStatus(ferry, waypoint: waypoints["NE"]));

            ferry.ExecuteRawInstruction("L90");
            Assert.IsTrue(CheckFerryStatus(ferry, waypoint: waypoints["NW"]));

        }

        private bool CheckFerryStatus(AdventOfCode.Day12.Ferry ferry, (int, int)? pos=null, (int,int)?waypoint=null, AdventOfCode.Day12.Ferry.Direction? dir=null)
        {
            if (pos != null && ferry.pos != pos)
            {
                return false;
            }
            if (waypoint != null && ferry.waypoint != waypoint)
            {
                return false;
            }
            if (dir != null && ferry.Orientation != dir)
            {
                return false;
            }
            return true;
        }
    }
}
