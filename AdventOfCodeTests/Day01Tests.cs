using System;
using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day01Tests
    {
        private string input_puzzle;
        private string input_example1;

        [TestInitialize]
        public void LoadInput()
        {
            input_puzzle = InputProvider.GetInput(2022, 1);
            input_example1 = string.Format("1000{0}2000{0}3000{0}{0}4000{0}{0}5000{0}6000{0}{0}7000{0}8000{0}9000{0}{0}10000", Environment.NewLine);
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
            var result = AdventOfCode.Day01.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"24000", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day01.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"67622", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day01.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual($"45000", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day01.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"201491", result);
        }
    }
}
