using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/14
    /// </summary>
    public class Day14
    {
        public class RegolithReservoir
        {
            private readonly Dictionary<(int x, int y), Content> Cave = new Dictionary<(int x, int y), Content> ();
            private int maxDepth = 0;

            public RegolithReservoir(string input)
            {
                foreach (var line in input.Split(Environment.NewLine))
                {
                    ParseRockShape(line);
                }
            }

            public int FindRestingSandCount()
            {
                return FillWithSand();
            }

            private void ParseRockShape(string input)
            {
                var paths = input.Split(" -> ");

                var start = Common.Common.ParseStringToIntTuple(paths[0], ',');
                for (int i = 1; i < paths.Length; i++)
                {
                    var end = Common.Common.ParseStringToIntTuple(paths[i], ',');

                    // Vertical
                    if (start.x == end.x)
                    {
                        var y = start.y < end.y ? start.y : end.y;
                        var yMax = start.y > end.y ? start.y : end.y;

                        for (; y <= yMax; y++)
                            Cave[(start.x, y)] = Content.rock;

                        maxDepth = yMax > maxDepth ? yMax : maxDepth;
                    }
                    // Horizontal
                    else
                    {
                        var x = start.x < end.x ? start.x : end.x;
                        var xMax = start.x > end.x ? start.x : end.x;

                        for (; x <= xMax; x++)
                            Cave[(x, start.y)] = Content.rock;

                        maxDepth = start.y > maxDepth ? start.y : maxDepth;
                    }

                    start = end;
                }
            }

            private int FillWithSand()
            {
                int numSands = 0;

                while (AddSand())
                {
                    numSands++;
                }

                return numSands;
            }

            private bool AddSand()
            {
                (int x, int y) pos = (500, 0);

                while (true)
                {
                    // Check down
                    if(!Cave.ContainsKey((pos.x, pos.y + 1)))
                    {
                        if (pos.y++ >= maxDepth)
                        {
                            // Fell into the void
                            return false;
                        }
                    }
                    // Check down-left
                    else if (!Cave.ContainsKey((pos.x-1, pos.y + 1)))
                    {
                        pos.x--;
                        pos.y++;
                    }
                    // Check down-right
                    else if (!Cave.ContainsKey((pos.x + 1, pos.y + 1)))
                    {
                        pos.x++;
                        pos.y++;
                    }
                    // No possible paths, put to rest
                    else
                    {
                        Cave[pos] = Content.sand;
                        return true;
                    }
                }
            }

            private enum Content
            {
                air,
                rock,
                sand
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var rr = new RegolithReservoir(input);
            return rr.FindRestingSandCount().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
