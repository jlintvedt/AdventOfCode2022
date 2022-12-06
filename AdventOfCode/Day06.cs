using System;

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

            public int FindFirstMarker(int markerLength)
            {
                var window = new int[26];

                // Prepare window
                for (int i = 0; i < markerLength; i++)
                {
                    window[datastream[i] - 97]++;
                }

                // Seach through datastream
                for (int i = markerLength; i < datastream.Length; i++)
                {
                    // Add new char to window
                    window[datastream[i] - 97]++;

                    // Remove char leaving window
                    window[datastream[i - markerLength] - 97]--;

                    // Check if there are no more than 1 of each char in window
                    var found = true;
                    for (int j = 0; j < window.Length; j++)
                    {
                        if (window[j] > 1)
                        {
                            found = false;
                            break;
                        }
                    }

                    if (found)
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
            return tt.FindFirstMarker(4).ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var tt = new TuningTrouble(input);
            return tt.FindFirstMarker(14).ToString();
        }
    }
}
