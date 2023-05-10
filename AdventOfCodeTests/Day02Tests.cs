using System;
using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            input_puzzle = InputProvider.GetInput(2022, 2);
            input_example1 = string.Format("A Y{0}B X{0}C Z", Environment.NewLine);
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
            var result = AdventOfCode.Day02.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"15", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day02.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"13675", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day02.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual($"12", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day02.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"14184", result);
        }
    }
}
