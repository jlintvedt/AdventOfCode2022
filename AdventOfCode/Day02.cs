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

            public RockPaperScissor(string input, bool secondColumnIsShape)
            {
                foreach (var row in input.Split(Environment.NewLine))
                {
                    rounds.Add(new Round(row, secondColumnIsShape));
                }
            }

            public int CalculateTotalScore()
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
                private Outcome outcome;
                public int Score;

                public Round(string input, bool secondIsShape)
                {
                    // Second column contains player shape (Puzzle1)
                    if (secondIsShape)
                    {
                        opponentShape = GetShape(input[0]);
                        playerShape = GetShape(input[2]);
                        outcome = DetermineOutcome(opponentShape, playerShape);
                    }
                    // Second column contains outcome (Puzzle2)
                    else
                    {
                        opponentShape = GetShape(input[0]);
                        outcome = GetOutcome(input[2]);
                        playerShape = DetermineShape(opponentShape, outcome);
                    }

                    Score = (int)outcome + (int)playerShape;
                }

                private static Shape GetShape(char symbol)
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

                private static Outcome GetOutcome(char symbol)
                {
                    switch (symbol)
                    {
                        case 'X':
                            return Outcome.Lose;
                        case 'Y':
                            return Outcome.Draw;
                        case 'Z':
                            return Outcome.Win;
                        default:
                            throw new ArgumentException();
                    }
                }

                private static Outcome DetermineOutcome(Shape opponent, Shape player)
                {
                    // Win
                    if ((opponent == Shape.Rock && player == Shape.Paper) ||
                        (opponent == Shape.Paper && player == Shape.Scissor) ||
                        (opponent == Shape.Scissor && player == Shape.Rock))
                    {
                        return Outcome.Win;
                    }
                    // Lose
                    if ((opponent == Shape.Rock && player == Shape.Scissor) ||
                        (opponent == Shape.Paper && player == Shape.Rock) ||
                        (opponent == Shape.Scissor && player == Shape.Paper))
                    {
                        return Outcome.Lose;
                    }
                    // Draw
                    return Outcome.Draw;
                }

                private static Shape DetermineShape(Shape opponent, Outcome outcome)
                {
                    // Rock
                    if ((opponent == Shape.Rock && outcome == Outcome.Draw) ||
                        (opponent == Shape.Paper && outcome == Outcome.Lose) ||
                        (opponent == Shape.Scissor && outcome == Outcome.Win))
                    {
                        return Shape.Rock;
                    }
                    // Paper
                    if ((opponent == Shape.Rock && outcome == Outcome.Win) ||
                        (opponent == Shape.Paper && outcome == Outcome.Draw) ||
                        (opponent == Shape.Scissor && outcome == Outcome.Lose))
                    {
                        return Shape.Paper;
                    }
                    // Scissor
                    return Shape.Scissor;
                }
            }
        }

        public enum Shape
        {
            Rock = 1,
            Paper = 2,
            Scissor = 3,
        }

        public enum Outcome
        {
            Lose = 0,
            Draw = 3,
            Win = 6,
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var rps = new RockPaperScissor(input, secondColumnIsShape: true);
            return rps.CalculateTotalScore().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var rps = new RockPaperScissor(input, secondColumnIsShape: false);
            return rps.CalculateTotalScore().ToString();
        }
    }
}
