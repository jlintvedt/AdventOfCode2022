using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/01
    /// </summary>
    public class Day01
    {
        public class CaloriesTracker
        {
            private readonly List<Elf> elfs = new List<Elf>();
            
            public CaloriesTracker(string input)
            {
                var items = input.Split(Environment.NewLine);

                var start = 0;
                for (int i = 0; i < items.Length; i++)
                {
                    if (string.IsNullOrEmpty(items[i]) || i == items.Length-1)
                    {
                        elfs.Add(new Elf(items[start..i]));
                        start = i+1;
                    }
                }
            }

            public int FindMostValoriesCarriedByAnElf()
            {
                var most = 0;
                foreach (var elf in elfs)
                {
                    most = elf.TotalCalories > most ? elf.TotalCalories : most;
                }

                return most;
            }

            private class Elf
            {
                public List<int> FoodCalories = new List<int>();
                public int TotalCalories = 0;

                public Elf(string[] items)
                {
                    foreach (var item in items)
                    {
                        var calories = int.Parse(item);
                        FoodCalories.Add(calories);
                        TotalCalories += calories;
                    }
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var ct = new CaloriesTracker(input);
            return ct.FindMostValoriesCarriedByAnElf().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
