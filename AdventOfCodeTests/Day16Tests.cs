using System;
using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day16Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            input_puzzle = InputProvider.GetInput(2022, 16);
            input_example1 = string.Format("Valve AA has flow rate=0; tunnels lead to valves DD, II, BB{0}Valve BB has flow rate=13; tunnels lead to valves CC, AA{0}Valve CC has flow rate=2; tunnels lead to valves DD, BB{0}Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE{0}Valve EE has flow rate=3; tunnels lead to valves FF, DD{0}Valve FF has flow rate=0; tunnels lead to valves EE, GG{0}Valve GG has flow rate=0; tunnels lead to valves FF, HH{0}Valve HH has flow rate=22; tunnel leads to valve GG{0}Valve II has flow rate=0; tunnels lead to valves AA, JJ{0}Valve JJ has flow rate=21; tunnel leads to valve II", Environment.NewLine);
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
            var result = AdventOfCode.Day16.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"1651", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day16.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"1751", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day16.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual($"Puzzle2", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day16.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"Puzzle2", result);
        }
    }
}
