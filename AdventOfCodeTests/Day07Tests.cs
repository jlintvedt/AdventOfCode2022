using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day07Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            string day = "07";
            input_puzzle = Resources.Input.ResourceManager.GetObject($"D{day}_Puzzle").ToString();
            input_example1 = string.Format("$ cd /{0}$ ls{0}dir a{0}14848514 b.txt{0}8504156 c.dat{0}dir d{0}$ cd a{0}$ ls{0}dir e{0}29116 f{0}2557 g{0}62596 h.lst{0}$ cd e{0}$ ls{0}584 i{0}$ cd ..{0}$ cd ..{0}$ cd d{0}$ ls{0}4060174 j{0}8033020 d.log{0}5626152 d.ext{0}7214296 k", Environment.NewLine);
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
            var result = AdventOfCode.Day07.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"95437", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day07.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"1783610", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day07.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual($"Puzzle2", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day07.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"Puzzle2", result);
        }
    }
}
