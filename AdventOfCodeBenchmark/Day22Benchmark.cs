using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day22Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D22_Puzzle;
        }

        [Benchmark]
        public string D22_P1() => Day22.Puzzle1(input);

        [Benchmark]
        public string D22_P2() => Day22.Puzzle2(input);
    }
}
