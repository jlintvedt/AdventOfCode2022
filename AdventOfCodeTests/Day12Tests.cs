using System;
using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day12Tests
    {
        private string input_puzzle;
        private string input_example1;

        [TestInitialize]
        public void LoadInput()
        {
            input_puzzle = InputProvider.GetInput(2022, 12);
            input_example1 = string.Format("Sabqponm{0}abcryxxl{0}accszExk{0}acctuvwj{0}abdefghi", Environment.NewLine);
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
            var result = AdventOfCode.Day12.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"31", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day12.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"504", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day12.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual($"29", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day12.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"500", result);
        }
    }
}
