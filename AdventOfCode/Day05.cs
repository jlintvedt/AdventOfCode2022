using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/5
    /// </summary>
    public class Day05
    {
        public class SupplyStacks
        {
            private List<Stack> stacks = new List<Stack>();
            private readonly List<(int count, int from, int to)> instructions = new List<(int count, int from, int to)>();

            public SupplyStacks(string input)
            {
                var segments = input.Split(new string[] { string.Format("{0}{0}", Environment.NewLine) }, StringSplitOptions.None);

                // Parse stacks
                var creates = segments[0].Split(Environment.NewLine);
                var stackNumbers = creates[creates.Length-1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < stackNumbers.Length; i++)
                {
                    stacks.Add(new Stack());
                }

                for (int i = creates.Length-2; i >= 0; i--)
                {
                    var row = creates[i];
                    for (int j = 0; j < stacks.Count; j++)
                    {
                        stacks[j].AddCreate(row[1+j*4]);
                    }
                }

                // Parse instructions
                foreach (var row in segments[1].Split(Environment.NewLine))
                {
                    var inst = row.Split(" ");
                    instructions.Add((int.Parse(inst[1]), int.Parse(inst[3]) - 1, int.Parse(inst[5]) - 1));
                }
            }

            public string RearrangeAndFindSequence(bool moveSingle = true)
            {
                // Rearrange
                foreach (var inst in instructions)
                {
                    if (moveSingle)
                        stacks[inst.from].MoveToOtherStack(stacks[inst.to], inst.count);
                    else
                        stacks[inst.from].MoveToOtherStackKeepingOrdering(stacks[inst.to], inst.count);
                }

                // Find sequence
                var sequence = "";
                foreach (var stack in stacks)
                {
                    sequence += stack.TopCreate;
                }

                return sequence;
            }

            private class Stack
            {
                private Stack<char> creates = new Stack<char>();

                public char TopCreate { get => creates.Peek(); }

                public void AddCreate(char input)
                {
                    if (input != ' ')
                        creates.Push(input);
                }

                public void MoveToOtherStack(Stack other, int count)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (creates.TryPop(out char create))
                        {
                            other.AddCreate(create);
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                    }
                }

                public void MoveToOtherStackKeepingOrdering(Stack other, int count)
                {
                    var tmp = new Stack<char>();
                    for (int i = 0; i < count; i++)
                    {
                        if (creates.TryPop(out char create))
                        {
                            tmp.Push(create);
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                    }

                    while (tmp.TryPop(out char create))
                    {
                        other.AddCreate(create);
                    }
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var ss = new SupplyStacks(input);
            return ss.RearrangeAndFindSequence();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var ss = new SupplyStacks(input);
            return ss.RearrangeAndFindSequence(moveSingle: false);
        }
    }
}
