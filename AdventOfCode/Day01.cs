using System;
using System.Collections.Generic;
using System.Linq;

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
                    if (string.IsNullOrEmpty(items[i]))
                    {
                        elfs.Add(new Elf(items[start..i]));
                        start = i + 1;
                    }
                }

                elfs.Add(new Elf(items[start..]));
            }

            public int FindMostCaloriesCarriedByAnElf()
            {
                var most = 0;
                foreach (var elf in elfs)
                {
                    most = elf.TotalCalories > most ? elf.TotalCalories : most;
                }

                return most;
            }

            public int FindCaloriesCarriesByTopThreeElfs()
            {
                return elfs.OrderByDescending(e => e.TotalCalories).Take(3).Select(e => e.TotalCalories).Sum();
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
            return ct.FindMostCaloriesCarriedByAnElf().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var ct = new CaloriesTracker(input);
            return ct.FindCaloriesCarriesByTopThreeElfs().ToString();
        }
    }
}
