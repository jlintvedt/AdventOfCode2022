using System;
using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day08Tests
    {
        private string input_puzzle;
        private string input_example1;

        [TestInitialize]
        public void LoadInput()
        {
            input_puzzle = InputProvider.GetInput(2022, 8);
            input_example1 = string.Format("30373{0}25512{0}65332{0}33549{0}35390", Environment.NewLine);
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
            var result = AdventOfCode.Day08.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"21", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day08.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"1794", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day08.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual($"8", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day08.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"199272", result);
        }
    }
}
