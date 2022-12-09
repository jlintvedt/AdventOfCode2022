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
            private readonly Knot head;
            private readonly Knot tail;
            private readonly List<Knot> knots = new List<Knot>();
            private readonly List<(char dir, int dist)> instructions = new List<(char dir, int dist)> ();
            private readonly HashSet<(int, int)> visited = new HashSet<(int, int)> ();

            public Rope(string input, int numKnots)
            {
                // Prepare knots
                for (int i = 0; i < numKnots; i++)
                {
                    knots.Add(new Knot());
                }
                head = knots[0];
                tail = knots[^1];

                // Parse instructions
                foreach (var line in input.Split(Environment.NewLine))
                {
                    var parts = line.Split(' ');
                    instructions.Add((parts[0][0], int.Parse(parts[1])));
                }
            }

            public int FindNumSpacesVisitedByTail()
            {
                visited.Add(tail.Pos);

                foreach (var (dir, dist) in instructions)
                {
                    switch (dir)
                    {
                        case 'U':
                            MoveHeadAndUpdateAllKnots((0, 1), dist); break;
                        case 'D':
                            MoveHeadAndUpdateAllKnots((0, -1), dist); break;
                        case 'L':
                            MoveHeadAndUpdateAllKnots((-1, 0), dist); break;
                        case 'R':
                            MoveHeadAndUpdateAllKnots((1, 0), dist); break;
                        default:
                            throw new ArgumentException();
                    }
                }

                return visited.Count;
            }

            private bool MoveHeadAndUpdateAllKnots((int x, int y) dir, int dist)
            {
                bool moved = true;
                for (int i = 0; i < dist; i++)
                {
                    // Move head
                    head.Move(dir);

                    // Update all other knots
                    for (int k = 1; k < knots.Count; k++)
                    {
                        moved = knots[k].UpdatePosition(knots[k - 1].Pos);
                        if (!moved)
                            break;
                    }

                    visited.Add(tail.Pos);
                }
                return true;
            }

            private class Knot
            {
                public int X = 0;
                public int Y = 0;
                public (int, int) Pos => (X, Y);

                public void Move((int x, int y) dir)
                {
                    X += dir.x;
                    Y += dir.y;
                }

                public bool UpdatePosition((int x, int y) other)
                {
                    var diffX = other.x - X;
                    var diffY = other.y - Y;

                    var stepX = diffX == 0 ? 0 : (diffX < 0 ? -1 : 1);
                    var stepY = diffY == 0 ? 0 : (diffY < 0 ? -1 : 1);

                    if (diffX < -1 || diffX > 1 || diffY < -1 || diffY > 1)
                    {
                        X += stepX;
                        Y += stepY;
                        return true;
                    }
                    return false;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var rope = new Rope(input, 2);
            return rope.FindNumSpacesVisitedByTail().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var rope = new Rope(input, 10);
            return rope.FindNumSpacesVisitedByTail().ToString();
        }
    }
}
