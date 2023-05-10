using System;
using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day03Tests
    {
        private string input_puzzle;
        private string input_example1;

        [TestInitialize]
        public void LoadInput()
        {
            input_puzzle = InputProvider.GetInput(2022, 3);
            input_example1 = string.Format("vJrwpWtwJgWrhcsFMMfFFhFp{0}jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL{0}PmmdzqPrVvPwwTWBwg{0}wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn{0}ttgJtRGJQctTZtZT{0}CrZsJsPPZsGzwwsLwLmpwMDw", Environment.NewLine);
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
            var result = AdventOfCode.Day03.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"157", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day03.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"8105", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day03.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual($"70", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day03.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"2363", result);
        }
    }
}
