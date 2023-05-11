using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/12
    /// </summary>
    public class Day12
    {
        public class HillClimbingAlgorithm
        {
            private readonly char[,] HeightMap;
            private readonly (int x, int y) startPos, EndPos;
            private readonly int width, height;

            private readonly Dictionary<(int x, int y), int> shortestDistance = new Dictionary<(int x, int y), int>();
            private readonly List<(int x, int y)> directions = new List<(int x, int y)>() { (1, 0), (0, 1), (-1, 0), (0, -1) };

            public HillClimbingAlgorithm(string input)
            {
                var lines = input.Split(Environment.NewLine);
                height = lines.Length;
                width = lines[0].Length;
                HeightMap = new char[width, height];

                // Parse height map
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        var elevation = lines[y][x];
                        if (elevation == 'S')
                        {
                            HeightMap[x, y] = 'a';
                            startPos = (x, y);
                        }
                        else if (elevation == 'E')
                        {
                            HeightMap[x, y] = 'z';
                            EndPos = (x, y);
                        }
                        else
                        {
                            HeightMap[x, y] = elevation;
                        }
                    }
                }
            }

            public int FindStepsInShortestRoute()
            {
                WalkTheMapRecursively(startPos, 'a', 0); // Note: Could technically use WalkDownhillRecursively, but it's ~10% slower

                return shortestDistance[EndPos];
            }

            public int FindStepsInShortestRouteForHiking()
            {
                WalkDownhillRecursively(EndPos, 'z', 0);

                var shortest = HeightMap.Length;
                foreach (var (pos, dist) in shortestDistance)
                {
                    if (HeightMap[pos.x,pos.y] == 'a' && dist < shortest)
                        shortest = dist;
                }

                return shortest;
            }

            public void WalkTheMapRecursively((int x, int y) pos, char elevation, int pathLength)
            {
                // Check if a shorter route has been found
                if (shortestDistance.TryGetValue(pos, out int shortest) && pathLength >= shortest)
                {
                    return;
                }

                // New shortest route to pos
                shortestDistance[pos] = pathLength;

                // Walk to neighbours
                foreach (var dir in directions)
                {
                    var nextPos = (x: pos.x + dir.x, y: pos.y + dir.y);
                    if (nextPos.x < 0 || nextPos.x >= width || nextPos.y < 0 || nextPos.y >= height)
                        continue;

                    var nextElevation = HeightMap[nextPos.x, nextPos.y];

                    // Max elevation increase is 1
                    if (nextElevation - elevation > 1)
                        continue;

                    WalkTheMapRecursively(nextPos, nextElevation, pathLength + 1);
                }
            }

            public void WalkDownhillRecursively((int x, int y) pos, char elevation, int pathLength)
            {
                // Check if a shorter route has been found
                if (shortestDistance.TryGetValue(pos, out int shortest) && pathLength >= shortest)
                {
                    return;
                }

                // New shortest route to pos
                shortestDistance[pos] = pathLength;

                // Walk to neighbours
                foreach (var dir in directions)
                {
                    var nextPos = (x: pos.x + dir.x, y: pos.y + dir.y);
                    if (nextPos.x < 0 || nextPos.x >= width || nextPos.y < 0 || nextPos.y >= height)
                        continue;

                    var nextElevation = HeightMap[nextPos.x, nextPos.y];

                    // Max elevation decrease is 1 (but can climb up any elevation)
                    if (elevation - nextElevation > 1)
                        continue;

                    WalkDownhillRecursively(nextPos, nextElevation, pathLength + 1);
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var hca = new HillClimbingAlgorithm(input);
            return hca.FindStepsInShortestRoute().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var hca = new HillClimbingAlgorithm(input);
            return hca.FindStepsInShortestRouteForHiking().ToString();
        }
    }
}
