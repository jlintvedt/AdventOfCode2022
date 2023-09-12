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
            private readonly HashSet<(int x, int y)> occupiedSpaces = new HashSet<(int x, int y)> ();
            private readonly Stack<(int x, int y)> fallHistory = new Stack<(int x, int y)> ();
            private int maxDepth = 0;
            private bool endlessVoid = true;

            public RegolithReservoir(string input)
            {
                foreach (var line in input.Split(Environment.NewLine))
                    ParseRockShape(line);
            }

            public int FindRestingSandCount(bool endlessVoid = true)
            {
                this.endlessVoid = endlessVoid;
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
                            occupiedSpaces.Add((start.x, y));

                        maxDepth = yMax > maxDepth ? yMax : maxDepth;
                    }
                    // Horizontal
                    else
                    {
                        var x = start.x < end.x ? start.x : end.x;
                        var xMax = start.x > end.x ? start.x : end.x;

                        for (; x <= xMax; x++)
                            occupiedSpaces.Add((x, start.y));

                        maxDepth = start.y > maxDepth ? start.y : maxDepth;
                    }

                    start = end;
                }
            }

            private bool IsOccupied((int x, int y) pos)
            {
                if (!endlessVoid && pos.y >= (maxDepth + 2))
                    return true;

                return occupiedSpaces.Contains(pos);
            }

            private int FillWithSand()
            {
                int numSands = 0;
                fallHistory.Push((500, 0));

                while (fallHistory.Count > 0 && AddSand())
                    numSands++;

                return numSands;
            }

            private bool AddSand()
            {
                var last = fallHistory.Peek();
                var pos = (last.x, last.y);

                while (true)
                {
                    // Check down
                    if(!IsOccupied((pos.x, pos.y + 1)))
                    {
                        if (pos.y + 1 >= maxDepth && endlessVoid)
                            return false; // Fell into the void
                        else
                            fallHistory.Push((pos.x, ++pos.y));
                    }
                    // Check down-left
                    else if (!IsOccupied((pos.x-1, pos.y + 1)))
                        fallHistory.Push((--pos.x, ++pos.y));
                    // Check down-right
                    else if (!IsOccupied((pos.x + 1, pos.y + 1)))
                        fallHistory.Push((++pos.x, ++pos.y));
                    // No possible paths, put to rest
                    else
                    {
                        occupiedSpaces.Add(pos);
                        fallHistory.Pop();
                        return true;
                    }
                }
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
            var rr = new RegolithReservoir(input);
            return rr.FindRestingSandCount(endlessVoid: false).ToString();
        }
    }
}
