using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/10
    /// </summary>
    public class Day10
    {
        public class CRT
        {
            private int cycle = 1;
            private int registry = 1;
            private Queue<(Operation operation, int value)> instructions = new Queue<(Operation, int)>();

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
                var x = 1;
                var signalStrength = 0;
                var inst = instructions.Dequeue();
                var waited = 0;

                for (int cycle = 1; ; cycle++)
                {
                    // Read signal strength at certain cycles
                    if ((cycle - 20) % 40 == 0)
                    {
                        signalStrength += cycle * x;
                    }

                    // Addx operation
                    if (inst.operation == Operation.addx)
                    {
                        if (++waited == 2)
                        {
                            x += inst.value;
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

                return signalStrength;
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
            return "Puzzle2";
        }
    }
}
