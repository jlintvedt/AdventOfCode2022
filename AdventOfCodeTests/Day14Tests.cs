using System;
using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day14Tests
    {
        private string input_puzzle;
        private string input_example1;

        [TestInitialize]
        public void LoadInput()
        {
            input_puzzle = InputProvider.GetInput(2022, 14);
            input_example1 = string.Format("498,4 -> 498,6 -> 496,6{0}503,4 -> 502,4 -> 502,9 -> 494,9", Environment.NewLine);
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
            var result = AdventOfCode.Day14.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"24", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day14.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"873", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day14.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual($"93", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day14.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"24813", result);
        }
    }
}
