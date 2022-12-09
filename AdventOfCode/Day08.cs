using System;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/8
    /// </summary>
    public class Day08
    {
        public class TreetopTreeHouse
        {
            private readonly int[][] trees;
            private readonly int rows;
            private readonly int cols;

            public TreetopTreeHouse(string input)
            {
                trees = Common.Common.ParseStringToJaggedIntArray(input, rowDelim: Environment.NewLine, columnDelim: null);

                rows = trees.Length;
                cols = trees[0].Length;
            }

            public int CountVisibleTrees()
            {
                var numVisible = 0;

                for (int r = 0; r < trees.Length; r++)
                {
                    var row = trees[r];
                    // Top / bottom row
                    if (r == 0 || r == trees.Length-1)
                    {
                        numVisible += row.Length;
                        continue;
                    }

                    // Other rows
                    for (int c = 0; c < row.Length; c++)
                    {
                        // Left- or right-most
                        if (c == 0 || c == row.Length-1)
                        {
                            numVisible++;
                            continue;
                        }
                        // Intertior tree
                        if (IsTreeVisible(r, c))
                        {
                            numVisible++;
                        }
                    }
                }

                return numVisible;
            }

            private bool IsTreeVisible(int row, int col)
            {
                foreach (var direction in new (int, int)[] { (1, 0), (-1, 0), (0, 1), (0, -1) })
                {
                    if (IsTreeVisibleInDirection(row, col, direction))
                        return true;
                }

                return false;
            }

            private bool IsTreeVisibleInDirection(int row, int col, (int r, int c) direction)
            {
                var height = trees[row][col];
                
                while (true)
                {
                    row += direction.r;
                    col += direction.c;
                    // Outside grid -> Tree is visible
                    if (row < 0 || row >= rows || col < 0 || col >= cols)
                        return true;

                    // Another tree of same or greater height -> Tree is not visible
                    if (trees[row][col] >= height)
                        return false;
                }

                throw new InvalidProgramException();
            }

            public int FindHighestScenicScore()
            {
                var bestScore = 0;

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        var score = FindScenicScore(r, c);
                        bestScore = score > bestScore ? score : bestScore;
                    }
                }

                return bestScore;
            }

            private int FindScenicScore(int row, int col)
            {
                
                var score = 1;
                foreach (var direction in new (int, int)[] { (1, 0), (-1, 0), (0, 1), (0, -1) })
                {
                    score *= FindViewDistance(row, col, direction);
                }

                return score;
            }

            private int FindViewDistance(int row, int col, (int r, int c) direction)
            {
                var height = trees[row][col];
                var dist = 0;

                while(true)
                {
                    row += direction.r;
                    col += direction.c;

                    // Outside grid
                    if (row < 0 || row >= rows || col < 0 || col >= cols)
                        break;
                    
                    dist++;

                    // Tree blocking sight
                    if (trees[row][col] >= height)
                        break;
                }

                return dist;
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var tth = new TreetopTreeHouse(input);
            return tth.CountVisibleTrees().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var tth = new TreetopTreeHouse(input);
            return tth.FindHighestScenicScore().ToString();
        }
    }
}
