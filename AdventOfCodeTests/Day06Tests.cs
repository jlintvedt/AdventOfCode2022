using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day06Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;
        private string input_example3;
        private string input_example4;
        private string input_example5;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "06";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("mjqjpqmgbljsphdztnvjfqwrcgsmlb");
            input_example2 = string.Format("bvwbjplbgvbhsrlpgdmjqwftvncz");
            input_example3 = string.Format("nppdvjthqldpwncqszvftbrmjlhg");
            input_example4 = string.Format("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
            input_example5 = string.Format("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
        }

        [TestMethod]
        public void Begin_WarmUp()
        {
            // Force performing LoadInput() warm-up as part of this test
        }

        [TestMethod]
        public void Example_Puzzle1()
        {
            // Act & Assert
            var result = AdventOfCode.Day06.Puzzle1(input_example1);
            Assert.AreEqual($"7", result);

            result = AdventOfCode.Day06.Puzzle1(input_example2);
            Assert.AreEqual($"5", result);

            result = AdventOfCode.Day06.Puzzle1(input_example3);
            Assert.AreEqual($"6", result);

            result = AdventOfCode.Day06.Puzzle1(input_example4);
            Assert.AreEqual($"10", result);

            result = AdventOfCode.Day06.Puzzle1(input_example5);
            Assert.AreEqual($"11", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day06.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"1794", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day06.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual($"Puzzle2", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day06.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"Puzzle2", result);
        }
    }
}
