using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/16
    /// </summary>
    public class Day16
    {
        public class ProboscideaVolcanium
        {
            private readonly Dictionary<string, Valve> valves = new Dictionary<string, Valve>();
            private Valve currentValve;

            public ProboscideaVolcanium(string input) 
            {
                var lines = input.Split(Environment.NewLine);
                foreach (var line in lines)
                {
                    var name = line[6..8];
                    valves.Add(name, new Valve(name, int.Parse(line[23..(line.IndexOf(';'))])));
                }

                foreach (var line in lines)
                {
                    var valve = valves[line[6..8]];
                    var adjecent = line[(line.IndexOf(' ', 45) + 1)..].Split(", ");
                    foreach (var a in adjecent)
                        valve.adjacentValves.Add(valves[a]);
                }

                foreach (var valve in valves)
                    valve.Value.CalculateDistances();

                currentValve = valves["AA"];
            }

            public int FindMostPressureToRelease()
            {
                return RecFindPotentialPressure(currentValve, 30);
            }

            public int RecFindPotentialPressure(Valve current, int timeRemaining)
            {
                current.open = true;
                var pressureRealeased = 0;
                foreach (var (valve, dist) in current.distances)
                {
                    if (valve.open)
                        continue;

                    var time = timeRemaining - dist - 1;
                    if ((time) <= 0)
                        continue;

                    var pressure = time * valve.flowRate;
                    pressure += RecFindPotentialPressure(valve, time);

                    if (pressure > pressureRealeased)
                        pressureRealeased = pressure;
                }

                current.open = false;
                return pressureRealeased;
            }

            public class Valve
            {
                public readonly string name;
                public readonly int flowRate;
                public bool open = false;
                public List<Valve> adjacentValves = new List<Valve>();
                public Dictionary<Valve, int> distances = new Dictionary<Valve, int>();

                public Valve(string name, int flowRate)
                {
                    this.name = name;
                    this.flowRate = flowRate;
                }

                public void CalculateDistances()
                {
                    RecFindShortestDistance(this, 0);

                    // Remove zero-flow valves
                    var zeroValves = new List<Valve>();
                    foreach (var v in distances)
                        if (v.Key.flowRate == 0)
                            zeroValves.Add(v.Key);
                    foreach (var v in zeroValves)
                        distances.Remove(v);
                }

                private void RecFindShortestDistance(Valve current, int distance)
                {
                    // Check if visited previously by shorter path
                    if (distances.TryGetValue(current, out var dist))
                        if (dist <= distance)
                            return;
                        else
                            distances[current] = distance;
                    else
                        distances.Add(current, distance);

                    foreach (var a in current.adjacentValves)
                        RecFindShortestDistance(a, distance + 1);
                }

                public override string ToString()
                {
                    var state = open ? "open" : "closed";
                    return $"{name} {state}   FlowRate[{flowRate}]   Adjecent[{string.Join(",", adjacentValves.Select(v => v.name))}]";
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {

            var pv = new ProboscideaVolcanium(input);
            return pv.FindMostPressureToRelease().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
