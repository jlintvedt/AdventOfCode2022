using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/10
    /// </summary>
    public class Day10
    {
        public class CRT
        {
            private readonly Queue<(Operation operation, int value)> instructions = new Queue<(Operation, int)>();
            private int cycle = 1;
            private int registry = 1;

            public CRT(string input) 
            {
                foreach (var line in input.Split(Environment.NewLine))
                {
                    var parts = line.Split(' ');
                    if (parts.Length == 1)
                    {
                        instructions.Enqueue((Operation.noop, 0));
                    } 
                    else
                    {
                        instructions.Enqueue((Operation.addx, Int32.Parse(parts[1])));
                    }
                }
            }

            public int CalculateSignalStrength()
            {
                var signalStrength = 0;
                var cycleExedcuter = ExecuteCycle().GetEnumerator();
                while (cycleExedcuter.MoveNext())
                {
                    // Read signal strength at certain cycles
                    if ((cycle - 20) % 40 == 0)
                    {
                        signalStrength += cycle * registry;
                    }
                }
                return signalStrength;
            }

            public string DrawScreenImage()
            {
                var cycleExedcuter = ExecuteCycle().GetEnumerator();
                var screen = new StringBuilder(new String('.', 240));
                while (cycleExedcuter.MoveNext())
                {
                    var pos = cycle - 1;
                    var rowPos = pos % 40;
                    var sprite = registry % 40;
                    if (rowPos == sprite - 1 || rowPos == sprite || rowPos == sprite + 1)
                    {
                        screen[pos] = '#';
                    }
                } 
                return screen.ToString();
            }

            private IEnumerable<bool> ExecuteCycle()
            {
                var inst = instructions.Dequeue();
                var waited = 0;

                for (cycle = 1; ; cycle++)
                {
                    // Has more instructions to process -> yield before performing steps.
                    yield return true;

                    // Addx operation
                    if (inst.operation == Operation.addx)
                    {
                        if (++waited == 2)
                        {
                            registry += inst.value;
                        }
                    }

                    // If current instruction is done, check for next
                    if (inst.operation == Operation.noop || waited == 2)
                    {
                        if (!instructions.TryDequeue(out inst))
                        {
                            break;
                        }
                        waited = 0;
                    }
                }

                yield return false;
            }

            private enum Operation
            {
                noop,
                addx
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var crt = new CRT(input);
            return crt.CalculateSignalStrength().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var crt = new CRT(input);
            return crt.DrawScreenImage();
        }
    }
}
