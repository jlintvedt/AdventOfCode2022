using System;
using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day10Tests
    {
        private string input_puzzle;
        private string input_example1;

        [TestInitialize]
        public void LoadInput()
        {
            input_puzzle = InputProvider.GetInput(2022, 10);
            
            input_example1 = string.Format("addx 15{0}addx -11{0}addx 6{0}addx -3{0}addx 5{0}addx -1{0}addx -8{0}addx 13{0}addx 4{0}noop{0}addx -1{0}addx 5{0}addx -1{0}addx 5{0}addx -1{0}addx 5{0}addx -1{0}addx 5{0}addx -1{0}addx -35{0}addx 1{0}addx 24{0}addx -19{0}addx 1{0}addx 16{0}addx -11{0}noop{0}noop{0}addx 21{0}addx -15{0}noop{0}noop{0}addx -3{0}addx 9{0}addx 1{0}addx -3{0}addx 8{0}addx 1{0}addx 5{0}noop{0}noop{0}noop{0}noop{0}noop{0}addx -36{0}noop{0}addx 1{0}addx 7{0}noop{0}noop{0}noop{0}addx 2{0}addx 6{0}noop{0}noop{0}noop{0}noop{0}noop{0}addx 1{0}noop{0}noop{0}addx 7{0}addx 1{0}noop{0}addx -13{0}addx 13{0}addx 7{0}noop{0}addx 1{0}addx -33{0}noop{0}noop{0}noop{0}addx 2{0}noop{0}noop{0}noop{0}addx 8{0}noop{0}addx -1{0}addx 2{0}addx 1{0}noop{0}addx 17{0}addx -9{0}addx 1{0}addx 1{0}addx -3{0}addx 11{0}noop{0}noop{0}addx 1{0}noop{0}addx 1{0}noop{0}noop{0}addx -13{0}addx -19{0}addx 1{0}addx 3{0}addx 26{0}addx -30{0}addx 12{0}addx -1{0}addx 3{0}addx 1{0}noop{0}noop{0}noop{0}addx -9{0}addx 18{0}addx 1{0}addx 2{0}noop{0}noop{0}addx 9{0}noop{0}noop{0}noop{0}addx -1{0}addx 2{0}addx -37{0}addx 1{0}addx 3{0}noop{0}addx 15{0}addx -21{0}addx 22{0}addx -6{0}addx 1{0}noop{0}addx 2{0}addx 1{0}noop{0}addx -10{0}noop{0}noop{0}addx 20{0}addx 1{0}addx 2{0}addx 2{0}addx -6{0}addx -11{0}noop{0}noop{0}noop", Environment.NewLine);
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
            var result = AdventOfCode.Day10.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"13140", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day10.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"12840", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day10.Puzzle2(input_example1);

            // Assert
            Assert.AreEqual($"##..##..##..##..##..##..##..##..##..##..###...###...###...###...###...###...###.####....####....####....####....####....#####.....#####.....#####.....#####.....######......######......######......###########.......#######.......#######.....", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day10.Puzzle2(input_puzzle);

            // Assert -> ASCII art ZKJFBJFZ
            Assert.AreEqual($"####.#..#...##.####.###....##.####.####....#.#.#.....#.#....#..#....#.#.......#...#..##......#.###..###.....#.###....#...#...#.#.....#.#....#..#....#.#.....#...#....#.#..#..#.#....#..#.#..#.#....#....####.#..#..##..#....###...##..#....####.", result);
        }
    }
}
