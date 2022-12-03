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
            private List<Rucksack> rucksacks = new List<Rucksack>();

            public RucksackReorganization(string input)
            {
                foreach (var items in input.Split(Environment.NewLine))
                {
                    rucksacks.Add(new Rucksack(items));
                }
            }

            public int FindSumOfErrorPriorities()
            {
                var sum = 0;
                foreach (var r in rucksacks)
                {
                    sum += r.errorPriority;
                }

                return sum;
            }

            public int FindSumOfGroupPriorities()
            {
                var sum = 0;
                for (int i = 0; i < rucksacks.Count; i+=3)
                {
                    sum += FindGroupPriority(rucksacks.GetRange(i, 3));
                }

                return sum;
            }

            private int FindGroupPriority(List<Rucksack> sacks)
            {
                var items = new int[sacks[0].items.Length];
                for (int i = 0; i < items.Length; i++)
                {
                    foreach (var r in sacks)
                    {
                        if (r.items[i] && ++items[i] > 2)
                        {
                            return i;
                        }
                    }
                }

                return 0;
            }

            public class Rucksack
            {
                public bool[] items = new bool[26+26+1];
                public  int errorPriority;

                public Rucksack(string input) 
                {
                    // Find items and error
                    var compartmentOne = new HashSet<char>();

                    for (int i = 0; i < input.Length; i++)
                    {
                        var priority = GetPriority(input[i]);
                        items[priority] = true;

                        //Compartment One
                        if (i < input.Length / 2)
                        {
                            compartmentOne.Add(input[i]);
                        }
                        // Compartment two
                        else
                        {
                            if (compartmentOne.Contains(input[i]))
                            {
                                errorPriority = priority;
                            }
                        }

                    }
                }

                private int GetPriority(char item)
                {
                    // Capital letter
                    if ((int)item < 97)
                    {
                        return (int)item - 64 + 26;
                    }

                    // Lower case letter
                    return (int)item - 96;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var rr = new RucksackReorganization(input);
            return rr.FindSumOfErrorPriorities().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var rr = new RucksackReorganization(input);
            return rr.FindSumOfGroupPriorities().ToString();
        }
    }
}
