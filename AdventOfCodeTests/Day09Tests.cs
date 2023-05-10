using System;
using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day09Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            input_puzzle = InputProvider.GetInput(2022, 9);
            input_example1 = string.Format("R 4{0}U 4{0}L 3{0}D 1{0}R 4{0}D 1{0}L 5{0}R 2", Environment.NewLine);
            input_example2 = string.Format("R 5{0}U 8{0}L 8{0}D 3{0}R 17{0}D 10{0}L 25{0}U 20", Environment.NewLine);
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
            var result = AdventOfCode.Day09.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"13", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day09.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"6406", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act & Assert
            var result = AdventOfCode.Day09.Puzzle2(input_example1);
            Assert.AreEqual($"1", result);

            result = AdventOfCode.Day09.Puzzle2(input_example2);
            Assert.AreEqual($"36", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day09.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"2643", result);
        }
    }
}
