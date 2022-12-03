using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/3
    /// </summary>
    public class Day03
    {
        public class RucksackReorganization
        {
            private List<Rucksack> rucksacks= new List<Rucksack>();

            public RucksackReorganization(string input)
            {
                foreach (var items in input.Split(Environment.NewLine))
                {
                    rucksacks.Add(new Rucksack(items));
                }
            }

            public int FindSumOfPriorities()
            {
                var sum = 0;
                foreach (var r in rucksacks)
                {
                    sum += r.GetPriority();
                }

                return sum;
            }

            public class Rucksack
            {
                private HashSet<char> compartmentOne= new HashSet<char>();
                private HashSet<char> compartmentTwo = new HashSet<char>();
                private char error;

                public Rucksack(string input) 
                {
                    // Sort into compartments
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (i < input.Length/2)
                        {
                            compartmentOne.Add(input[i]);
                        }
                        else
                        {
                            compartmentTwo.Add(input[i]);
                        }
                    }

                    // Find error
                    foreach (var item in compartmentTwo)
                    {
                        if (compartmentOne.TryGetValue(item, out _))
                        {
                            error = item;
                        }
                    }
                }

                public int GetPriority()
                {
                    // Capital letter
                    if ((int)error < 97)
                    {
                        return (int)error - 64 + 26;
                    }

                    // Lower case letter
                    return (int)error - 96;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var rr = new RucksackReorganization(input);
            return rr.FindSumOfPriorities().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
