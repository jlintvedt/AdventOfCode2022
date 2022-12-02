using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/02
    /// </summary>
    public class Day02
    {
        public class RockPaperScissor
        {
            private List<Round> rounds= new List<Round>();

            public RockPaperScissor(string input)
            {
                foreach (var row in input.Split(Environment.NewLine))
                {
                    rounds.Add(new Round(row));
                }
            }

            public int CalculateScoreFollowingGuide()
            {
                var sum = 0;
                foreach (var round in rounds)
                {
                    sum += round.Score;
                }
                return sum;
            }

            private class Round
            {
                private Shape opponentShape;
                private Shape playerShape;
                public int Score;

                public Round(string input)
                {
                    opponentShape = GetShape(input[0]);
                    playerShape = GetShape(input[2]);

                    Score = RoundScore() + (int)playerShape;
                }

                private Shape GetShape(char symbol)
                {
                    switch (symbol)
                    {
                        case 'A':
                        case 'X':
                            return Shape.Rock;
                        case 'B':
                        case 'Y':
                            return Shape.Paper;
                        case 'C':
                        case 'Z':
                            return Shape.Scissor;
                        default:
                            throw new ArgumentException();
                    }
                }

                private int RoundScore()
                {
                    // Win
                    if ((opponentShape == Shape.Rock && playerShape == Shape.Paper) ||
                        (opponentShape == Shape.Paper && playerShape == Shape.Scissor) ||
                        (opponentShape == Shape.Scissor && playerShape == Shape.Rock))
                    {
                        return 6;
                    }
                    // Loss
                    if ((opponentShape == Shape.Rock && playerShape == Shape.Scissor) ||
                        (opponentShape == Shape.Paper && playerShape == Shape.Rock) ||
                        (opponentShape == Shape.Scissor && playerShape == Shape.Paper))
                    {
                        return 0;
                    }
                    // Draw
                    return 3;
                }
            }
        }

        public enum Shape
        {
            Rock = 1,
            Paper = 2,
            Scissor = 3,
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var rps = new RockPaperScissor(input);
            return rps.CalculateScoreFollowingGuide().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
