using System;
using AdventOfCodeTests.InputHelpers;
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
            input_puzzle = InputProvider.GetInput(2022, 5);
            input_example1 = string.Format("    [D]    {0}[N] [C]    {0}[Z] [M] [P]{0} 1   2   3 {0}{0}move 1 from 2 to 1{0}move 3 from 1 to 3{0}move 2 from 2 to 1{0}move 1 from 1 to 2", Environment.NewLine);
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
            var result = AdventOfCode.Day05.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"CMZ", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day05.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"TGWSMRBPN", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day05.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual($"MCD", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day05.Puzzle2(input_puzzle);

            // Assertt
            Assert.AreEqual($"TZLTLWRNF", result);
        }
    }
}
