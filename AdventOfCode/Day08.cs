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
            private int[][] trees;
            private int rows, cols;

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
                var height = trees[row][col];
                var tallest = 0;
                // Horizontal
                for (int c = 0; c < cols + 1; c++)
                {
                    // Validate on self and end of row
                    if (c == col || c == cols)
                    {
                        if (tallest < height)
                            return true;
                        tallest = 0;
                        continue;
                    }

                    tallest = trees[row][c] > tallest ? trees[row][c] : tallest;
                }

                // Vertical
                for (int r = 0; r < rows + 1; r++)
                {
                    // Validate on self and end of col
                    if (r == row || r == rows)
                    {
                        if (tallest < height)
                            return true;
                        tallest = 0;
                        continue;
                    }

                    tallest = trees[r][col] > tallest ? trees[r][col] : tallest;
                }

                return false;
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
                    if (row < 0 || row >= rows || col < 0 || col >= cols)
                    {
                        break;
                    }

                    dist++;

                    if (trees[row][col] >= height)
                    {
                        break;
                    }
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
