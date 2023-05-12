using System;
using AdventOfCodeTests.InputHelpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day13Tests
    {
        private string input_puzzle;
        private string input_example1;
        private string input_example2;

        [TestInitialize]
        public void LoadInput()
        {
            input_puzzle = InputProvider.GetInput(2022, 13);
            input_example1 = string.Format("[1,1,3,1,1]{0}[1,1,5,1,1]{0}{0}[[1],[2,3,4]]{0}[[1],4]{0}{0}[9]{0}[[8,7,6]]{0}{0}[[4,4],4,4]{0}[[4,4],4,4,4]{0}{0}[7,7,7,7]{0}[7,7,7]{0}{0}[]{0}[3]{0}{0}[[[]]]{0}[[]]{0}{0}[1,[2,[3,[4,[5,6,7]]]],8,9]{0}[1,[2,[3,[4,[5,6,0]]]],8,9]", Environment.NewLine);
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
            var result = AdventOfCode.Day13.Puzzle1(input_example1);

            // Assert
            Assert.AreEqual($"13", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day13.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"5852", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day13.Puzzle2(input_example2);

            // Assert
            Assert.AreEqual($"Puzzle2", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day13.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"Puzzle2", result);
        }

        // Packet tests
        [TestMethod]
        public void PacketConstructor_SimpleList()
        {
            // Arrange
            var input = "[1,2,3,4,5]";

            // Act
            var p = new AdventOfCode.Day13.DistressSignal.Packet(input);

            // Assert
            p.value.Type.Should().Be(AdventOfCode.Day13.DistressSignal.Packet.Vtype.list);
            p.value.ListValues.Count.Should().Be(5);
            p.value.ListValues[0].Type.Should().Be(AdventOfCode.Day13.DistressSignal.Packet.Vtype.integer);
            p.value.ListValues[0].IntegerValue.Should().Be(1);
            p.value.ListValues[4].Type.Should().Be(AdventOfCode.Day13.DistressSignal.Packet.Vtype.integer);
            p.value.ListValues[4].IntegerValue.Should().Be(5);
        }

        // Packet tests
        [TestMethod]
        public void PacketConstructor_NestedList()
        {
            // Arrange
            var input = "[[1],[2,3,4]]";

            // Act
            var p = new AdventOfCode.Day13.DistressSignal.Packet(input);

            // Assert
            p.value.Type.Should().Be(AdventOfCode.Day13.DistressSignal.Packet.Vtype.list);
            p.value.ListValues.Count.Should().Be(2);

            // Sub-list 1
            p.value.ListValues[0].Type.Should().Be(AdventOfCode.Day13.DistressSignal.Packet.Vtype.list);
            p.value.ListValues[0].ListValues.Count.Should().Be(1);

            p.value.ListValues[0].ListValues[0].Type.Should().Be(AdventOfCode.Day13.DistressSignal.Packet.Vtype.integer);
            p.value.ListValues[0].ListValues[0].IntegerValue.Should().Be(1);

            // Sub-list 2
            p.value.ListValues[1].Type.Should().Be(AdventOfCode.Day13.DistressSignal.Packet.Vtype.list);
            p.value.ListValues[1].ListValues.Count.Should().Be(3);

            p.value.ListValues[1].ListValues[0].Type.Should().Be(AdventOfCode.Day13.DistressSignal.Packet.Vtype.integer);
            p.value.ListValues[1].ListValues[0].IntegerValue.Should().Be(2);
            p.value.ListValues[1].ListValues[1].Type.Should().Be(AdventOfCode.Day13.DistressSignal.Packet.Vtype.integer);
            p.value.ListValues[1].ListValues[1].IntegerValue.Should().Be(3);
            p.value.ListValues[1].ListValues[2].Type.Should().Be(AdventOfCode.Day13.DistressSignal.Packet.Vtype.integer);
            p.value.ListValues[1].ListValues[2].IntegerValue.Should().Be(4);
        }

        [TestMethod]
        public void PacketConstructor_EmptyList()
        {
            // Arrange
            var input = "[]";

            // Act
            var p = new AdventOfCode.Day13.DistressSignal.Packet(input);

            // Assert
            p.value.Type.Should().Be(AdventOfCode.Day13.DistressSignal.Packet.Vtype.list);
            p.value.ListValues.Count.Should().Be(0);
        }

        [TestMethod]
        public void PacketConstructor_ValidateExampleInput()
        {
            // Arrange
            var examples = input_example1.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            // Act & Assert
            foreach (var input in examples)
            {
                var expected = input.Replace(",", ", ").Replace("[", " [").Replace("]", "] ");
                var p = new AdventOfCode.Day13.DistressSignal.Packet(input);
                p.value.ToString().Should().Be(expected);
            }
        }

        [TestMethod]
        public void PacketConstructor_ValidatePuzzleInput()
        {
            // Arrange
            var examples = input_puzzle.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            // Act & Assert
            foreach (var input in examples)
            {
                var expected = input.Replace(",", ", ").Replace("[", " [").Replace("]", "] ");
                var p = new AdventOfCode.Day13.DistressSignal.Packet(input);
                p.value.ToString().Should().Be(expected);
            }
        }
    }
}
