using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
                return RecFindPotentialPressure(currentValve, new Stack<string>(), 30);
            }

            public int RecFindPotentialPressure(Valve current, Stack<string> visited, int timeRemaining)
            {
                visited.Push(current.name);
                var pressureRealeased = 0;
                foreach (var valve in current.distances)
                {
                    if (visited.Contains(valve.Key))
                        continue;

                    var time = timeRemaining - valve.Value.dist - 1;
                    if ((time) <= 0)
                        continue;

                    var pressure = time * valve.Value.flowRate;
                    pressure += RecFindPotentialPressure(valves[valve.Key], visited, time);

                    if (pressure > pressureRealeased)
                        pressureRealeased = pressure;
                }

                visited.Pop();
                return pressureRealeased;
            }

            public class Valve
            {
                public readonly string name;
                public readonly int flowRate;
                public bool open = false;
                public List<Valve> adjacentValves = new List<Valve>();
                public Dictionary<string, (int dist, int flowRate)> distances = new Dictionary<string, (int dist, int flowRate)>();

                public Valve(string name, int flowRate)
                {
                    this.name = name;
                    this.flowRate = flowRate;
                }

                public void CalculateDistances()
                {
                    RecFindShortestDistance(this, 0);

                    // Remove zero-flow valves
                    var zeroValves = new List<string>();
                    foreach (var v in distances)
                        if (v.Value.flowRate == 0)
                            zeroValves.Add(v.Key);
                    foreach (var v in zeroValves)
                        distances.Remove(v);
                }

                private void RecFindShortestDistance(Valve current, int distance)
                {
                    // Check if visited previously by shorter path
                    if (distances.TryGetValue(current.name, out var value))
                        if (value.dist <= distance)
                            return;
                        else
                            distances[current.name] = (distance, current.flowRate);
                    else
                        distances.Add(current.name, (distance, current.flowRate));

                    // Remove 0-valves
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
