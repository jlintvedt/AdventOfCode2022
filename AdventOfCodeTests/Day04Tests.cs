using System;
using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day04Tests
    {
        private string input_puzzle;
        private string input_example1;

        [TestInitialize]
        public void LoadInput()
        {
            input_puzzle = InputProvider.GetInput(2022, 4);
            input_example1 = string.Format("2-4,6-8{0}2-3,4-5{0}5-7,7-9{0}2-8,3-7{0}6-6,4-6{0}2-6,4-8", Environment.NewLine);
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
            var result = AdventOfCode.Day04.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"2", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day04.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"528", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day04.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual($"4", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day04.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"881", result);
        }
    }
}
