using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/9
    /// </summary>
    public class Day09
    {
        public class Rope
        {
            private (int x, int y) head = (0, 0);
            private (int x, int y) tail = (0, 0);
            private readonly List<(char dir, int dist)> instructions = new List<(char dir, int dist)> ();
            private HashSet<(int, int)> visited;

            public Rope(string input)
            {
                foreach (var line in input.Split(Environment.NewLine))
                {
                    var parts = line.Split(' ');
                    instructions.Add((parts[0][0], int.Parse(parts[1])));
                }
            }

            public int FindNumSpacesVisitedByTail()
            {
                visited = new HashSet<(int, int)>{ tail };
                foreach (var (dir, dist) in instructions)
                {
                    switch (dir)
                    {
                        case 'U':
                            MoveUp(dist); break;
                        case 'D':
                            MoveDown(dist); break;
                        case 'L':
                            MoveLeft(dist); break;
                        case 'R':
                            MoveRight(dist); break;
                        default:
                            throw new ArgumentException();
                    }
                }

                return visited.Count;
            }

            private void MoveUp(int dist)
            {
                for (int i = 0; i < dist; i++)
                {
                    head.y++;
                    if (tail.y < head.y - 1)
                    {
                        tail = (head.x, head.y - 1);
                        visited.Add(tail);
                    }
                }
            }

            private void MoveDown(int dist)
            {
                for (int i = 0; i < dist; i++)
                {
                    head.y--;
                    if (tail.y > head.y + 1)
                    {
                        tail = (head.x, head.y + 1);
                        visited.Add(tail);
                    }
                }
            }

            private void MoveLeft(int dist)
            {
                for (int i = 0; i < dist; i++)
                {
                    head.x--;
                    if (tail.x > head.x + 1)
                    {
                        tail = (head.x + 1, head.y);
                        visited.Add(tail);
                    }
                }
            }

            private void MoveRight(int dist)
            {
                for (int i = 0; i < dist; i++)
                {
                    head.x++;
                    if (tail.x < head.x - 1)
                    {
                        tail = (head.x - 1, head.y);
                        visited.Add(tail);
                    }
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var rope = new Rope(input);
            return rope.FindNumSpacesVisitedByTail().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
