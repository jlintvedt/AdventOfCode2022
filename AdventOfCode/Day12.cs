using System;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/12
    /// </summary>
    public class Day12
    {
        public class HillClimbingAlgorithm
        {
            private readonly (int x, int y) startPos, EndPos;
            private readonly int width, height;

            private readonly char[,] HeightMap;
            private readonly int[,] shortestDistance;
            private readonly (int x, int y)[] directions = { (1, 0), (0, 1), (-1, 0), (0, -1) };

            private readonly bool trackShortestPathToSummit;
            private int shortestDistToSummit;

            public HillClimbingAlgorithm(string input, bool trackShortestPathToSummit = false)
            {
                var lines = input.Split(Environment.NewLine);
                height = lines.Length;
                width = lines[0].Length;
                HeightMap = new char[width, height];
                shortestDistance = new int[width, height];
                shortestDistToSummit = height * width;
                this.trackShortestPathToSummit = trackShortestPathToSummit;

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

                        shortestDistance[x, y] = int.MaxValue;
                    }
                }
            }

            public int FindStepsInShortestRoute()
            {
                //WalkTheMapRecursively(startPos, 'a', 0); // Removed to clean up code, but 7-10% faster (check prev. commits)
                WalkDownhillRecursively(EndPos, 'z', 0);

                return shortestDistance[startPos.x, startPos.y];
            }

            public int FindStepsInShortestRouteForHiking()
            {
                WalkDownhillRecursively(EndPos, 'z', 0);

                return shortestDistToSummit;
            }

            public void WalkDownhillRecursively((int x, int y) pos, char elevation, int pathLength)
            {
                // Check if a shorter route has been found
                if (shortestDistance[pos.x, pos.y] <= pathLength)
                    return;

                // New shortest route to pos
                shortestDistance[pos.x, pos.y] = pathLength;

                if (trackShortestPathToSummit && elevation == 'a' && pathLength < shortestDistToSummit)
                    shortestDistToSummit = pathLength;

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
            var hca = new HillClimbingAlgorithm(input, trackShortestPathToSummit: true);
            return hca.FindStepsInShortestRouteForHiking().ToString();
        }
    }
}
