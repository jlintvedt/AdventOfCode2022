using System;
using System.Dynamic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/6
    /// </summary>
    public class Day06
    {
        public class TuningTrouble
        {
            private string datastream;

            public TuningTrouble(string input)
            {
                datastream = input;
            }

            public int FindFirstEndOfStartOfPacketMarker()
            {
                for (int i = 3; i < datastream.Length; i++)
                {
                    if ((datastream[i] != datastream[i - 1]) &&
                        (datastream[i] != datastream[i - 2]) &&
                        (datastream[i] != datastream[i - 3]) &&
                        (datastream[i - 1] != datastream[i - 2]) &&
                        (datastream[i - 1] != datastream[i - 3]) &&
                        (datastream[i - 2] != datastream[i - 3]))
                    {
                        return i + 1;
                    }
                }

                throw new InvalidOperationException();
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var tt = new TuningTrouble(input);
            return tt.FindFirstEndOfStartOfPacketMarker().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
