using System;
using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
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
            input_puzzle = InputProvider.GetInput(2022, 15);
            input_example1 = string.Format("Sensor at x=2, y=18: closest beacon is at x=-2, y=15{0}Sensor at x=9, y=16: closest beacon is at x=10, y=16{0}Sensor at x=13, y=2: closest beacon is at x=15, y=3{0}Sensor at x=12, y=14: closest beacon is at x=10, y=16{0}Sensor at x=10, y=20: closest beacon is at x=10, y=16{0}Sensor at x=14, y=17: closest beacon is at x=10, y=16{0}Sensor at x=8, y=7: closest beacon is at x=2, y=10{0}Sensor at x=2, y=0: closest beacon is at x=2, y=10{0}Sensor at x=0, y=11: closest beacon is at x=2, y=10{0}Sensor at x=20, y=14: closest beacon is at x=25, y=17{0}Sensor at x=17, y=20: closest beacon is at x=21, y=22{0}Sensor at x=16, y=7: closest beacon is at x=15, y=3{0}Sensor at x=14, y=3: closest beacon is at x=15, y=3{0}Sensor at x=20, y=1: closest beacon is at x=15, y=3", Environment.NewLine);
            input_example2 = string.Format("example{0}2", Environment.NewLine);
        }

        [TestMethod]
        public void Begin_WarmUp()
        {
            // Force performing LoadInput() warm-up as part of this test
        }

        [TestMethod]
        public void Example_Puzzle1()
        {
            // Act
            // var result = AdventOfCode.Day15.Puzzle1(input_example1); // Can't use standard method as input conditions differ.
            var bez = new Day15.BeaconExclusionZone(input_example1);
            var result = bez.FindNumNonBeaconPositions(10).ToString();

            // Assert
            Assert.AreEqual($"26", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day15.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"6425133", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            //var result = AdventOfCode.Day15.Puzzle2(input_example2); // Can't use standard method as input conditions differ.
            var bez = new Day15.BeaconExclusionZone(input_example1);
            var result = bez.FindTuningFrequency(20).ToString();

            // Assert
            Assert.AreEqual($"56000011", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day15.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"10996191429555", result);
            // Not: 1075151795
        }
    }
}
