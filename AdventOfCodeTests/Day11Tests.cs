using System;
using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day11Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            input_puzzle = InputProvider.GetInput(2022, 11);
            input_example1 = string.Format("Monkey 0:{0}  Starting items: 79, 98{0}  Operation: new = old * 19{0}  Test: divisible by 23{0}    If true: throw to monkey 2{0}    If false: throw to monkey 3{0}{0}Monkey 1:{0}  Starting items: 54, 65, 75, 74{0}  Operation: new = old + 6{0}  Test: divisible by 19{0}    If true: throw to monkey 2{0}    If false: throw to monkey 0{0}{0}Monkey 2:{0}  Starting items: 79, 60, 97{0}  Operation: new = old * old{0}  Test: divisible by 13{0}    If true: throw to monkey 1{0}    If false: throw to monkey 3{0}{0}Monkey 3:{0}  Starting items: 74{0}  Operation: new = old + 3{0}  Test: divisible by 17{0}    If true: throw to monkey 0{0}    If false: throw to monkey 1", Environment.NewLine);
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
            var result = AdventOfCode.Day11.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"10605", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day11.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"108240", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day11.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual($"Puzzle2", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day11.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"Puzzle2", result);
        }
    }
}
