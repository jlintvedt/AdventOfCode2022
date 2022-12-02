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
            private List<int> caloriesCarried = new List<int>();
            
            public CaloriesTracker(string input)
            {
                var items = input.Split(Environment.NewLine);

                var start = 0;

                // Add bundles
                for (int i = 0; i < items.Length; i++)
                {
                    if (string.IsNullOrEmpty(items[i]))
                    {
                        caloriesCarried.Add(CalculateBundleCalories(items[start..i]));
                        start = i + 1;
                    }
                }

                // Last bundle
                caloriesCarried.Add(CalculateBundleCalories(items[start..]));

                // Sort descending
                caloriesCarried.Sort();
                caloriesCarried.Reverse();
            }

            private int CalculateBundleCalories(string[] bundle)
            {
                var sum = 0;
                foreach (var item in bundle)
                {
                    sum += int.Parse(item);
                }

                return sum;
            }

            public int FindMostCaloriesCarriedByAnElf()
            {
                return caloriesCarried[0];
            }

            public int FindCaloriesCarriesByTopThreeElfs()
            {
                return caloriesCarried[0] + caloriesCarried[1] + caloriesCarried[2];
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
