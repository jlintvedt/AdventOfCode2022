using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/4
    /// </summary>
    public class Day04
    {
        public class CampCleanup
        {
            private List<CleanupCrew> crews = new List<CleanupCrew>();

            public CampCleanup(string input)
            {
                foreach (var line in input.Split(Environment.NewLine))
                {
                    crews.Add(new CleanupCrew(line));
                }
            }

            public int FindNumberOfCrewsWithCompleteOverlap()
            {
                var num = 0;
                foreach (var crew in crews)
                {
                    num = crew.CheckIfFullOverlapExists() ? num + 1 : num;
                }

                return num;
            }

            public int FindNumberOfCrewsWithPartialOverlap()
            {
                var num = 0;
                foreach (var crew in crews)
                {
                    num = crew.CheckIfPartialOverlapExists() ? num + 1 : num;
                }

                return num;
            }


            private class CleanupCrew
            {
                public (int start, int stop) SectionA;
                public (int start, int stop) SectionB;

                public CleanupCrew(string input)
                {
                    var seg = input.Split(new char[] {',', '-'});
                    SectionA = (int.Parse(seg[0]), int.Parse(seg[1]));
                    SectionB = (int.Parse(seg[2]), int.Parse(seg[3]));
                }

                public bool CheckIfFullOverlapExists()
                {
                    if ((SectionA.start <= SectionB.start && SectionA.stop >= SectionB.stop) ||
                        (SectionB.start <= SectionA.start && SectionB.stop >= SectionA.stop))
                    {
                        return true;
                    }

                    return false;
                }

                public bool CheckIfPartialOverlapExists()
                {
                    if ((SectionA.start <= SectionB.start && SectionA.stop >= SectionB.start) ||
                        (SectionB.start <= SectionA.start && SectionB.stop >= SectionA.start))
                    {
                        return true;
                    }

                    return false;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var cc = new CampCleanup(input);
            return cc.FindNumberOfCrewsWithCompleteOverlap().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var cc = new CampCleanup(input);
            return cc.FindNumberOfCrewsWithPartialOverlap().ToString();
        }
    }
}
