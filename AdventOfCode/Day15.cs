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

            public int FindNumNonBeaconPositions(int rowNum = 2000000)
            {
                var blockecSpaces = new HashSet<int>();

                foreach (var sensor in sensors) 
                {
                    var width = sensor.range - (sensor.pos.y < rowNum ? rowNum - sensor.pos.y : sensor.pos.y - rowNum);

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

            public long FindTuningFrequency(int searchArea = 4000000)
            {
                var possibleSpaces = new HashSet<(int x, int y)>();

                // Find all possible locations along the boundry of the sensor ranges
                foreach (var sensor in sensors)
                {
                    var (x, y) = sensor.pos;
                    var range = sensor.range + 1;
                    for (int i = 0; i < range ; i++)
                    {
                        // NW
                        AddIfWithinSearchArea(possibleSpaces, (x - range + i, y - i), searchArea);
                        // NE
                        AddIfWithinSearchArea(possibleSpaces, (x + i, y - range + i), searchArea);
                        // SE
                        AddIfWithinSearchArea(possibleSpaces, (x + range - i, y + i), searchArea);
                        // SW
                        AddIfWithinSearchArea(possibleSpaces, (x - i, y + range - i), searchArea);
                    }
                }

                // Find the position which is not within any sensor range
                foreach (var pos in possibleSpaces)
                {
                    var found = true;
                    foreach (var sensor in sensors)
                    {
                        var dist = Common.Common.Calculate.ManhattanDistance(pos, sensor.pos);
                        if (dist <= sensor.range)
                        {
                            found = false;
                            break;
                        }
                    }

                    if (found)
                        return (long)4000000 * pos.x + pos.y;
                }

                throw new Exception("Could not find any spots for the beacon");
            }

            private void AddIfWithinSearchArea(HashSet<(int, int)> spaces, (int x, int y) pos, int searchArea)
            {
                if (pos.x >= 0 && pos.x <= searchArea && pos.y >= 0 && pos.y <= searchArea)
                    spaces.Add(pos);
            }

            public class Sensor
            {
                public (int x, int y) pos;
                public (int x, int y) closestBeacon;
                public int range;

                public Sensor(string input)
                {
                    var seg = input.Split(' ');
                    pos = (Int32.Parse(seg[2][2..].Split(',')[0]), Int32.Parse(seg[3][2..].Split(':')[0]));
                    closestBeacon = (Int32.Parse(seg[8][2..].Split(',')[0]), Int32.Parse(seg[9][2..]));
                    range = Common.Common.Calculate.ManhattanDistance(pos, closestBeacon);
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var bez = new BeaconExclusionZone(input);
            return bez.FindNumNonBeaconPositions().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var bez = new BeaconExclusionZone(input);
            return bez.FindTuningFrequency().ToString();
        }
    }
}
