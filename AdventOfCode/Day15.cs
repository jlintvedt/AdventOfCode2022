using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/15
    /// </summary>
    public class Day15
    {
        public class BeaconExclusionZone
        {
            private readonly List<Sensor> sensors = new List<Sensor>();

            public BeaconExclusionZone(string input)
            {
                foreach (var line in input.Split(Environment.NewLine))
                    sensors.Add(new Sensor(line));
            }

            public int FindNumNonBeaconPositions(int rowNum)
            {
                var blockecSpaces = new HashSet<int>();

                foreach (var sensor in sensors) 
                {
                    var range = Common.Common.Calculate.ManhattanDistance(sensor.pos, sensor.closestBeacon);
                    var width = range - (sensor.pos.y < rowNum ? rowNum - sensor.pos.y : sensor.pos.y - rowNum);

                    // If sensor has range on target row, block spaces where beacon can't be placed
                    if (width >= 0)
                    {
                        blockecSpaces.Add(sensor.pos.x);
                        for (int i = 1; i <= width; i++)
                        {
                            blockecSpaces.Add(sensor.pos.x + i);
                            blockecSpaces.Add(sensor.pos.x - i);
                        }
                    }
                }

                // Remove any confirmed beacons
                foreach (var sensor in sensors)
                    if (sensor.closestBeacon.y == rowNum)
                        blockecSpaces.Remove(sensor.closestBeacon.x);

                return blockecSpaces.Count;
            }

            public class Sensor
            {
                public (int x, int y) pos;
                public (int x, int y) closestBeacon;

                public Sensor(string input)
                {
                    var seg = input.Split(' ');
                    pos = (Int32.Parse(seg[2][2..].Split(',')[0]), Int32.Parse(seg[3][2..].Split(':')[0]));
                    closestBeacon = (Int32.Parse(seg[8][2..].Split(',')[0]), Int32.Parse(seg[9][2..]));
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var bez = new BeaconExclusionZone(input);
            return bez.FindNumNonBeaconPositions(2000000).ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
