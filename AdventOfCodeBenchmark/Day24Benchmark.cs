using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day24Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D24_Puzzle;
        }

        [Benchmark]
        public string D24_P1() => Day24.Puzzle1(input);

        [Benchmark]
        public string D24_P2() => Day24.Puzzle2(input);
    }
}
