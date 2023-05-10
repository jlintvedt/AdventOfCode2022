using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day18Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 18);
        }

        [Benchmark]
        public string D18_P1() => Day18.Puzzle1(input);

        [Benchmark]
        public string D18_P2() => Day18.Puzzle2(input);
    }
}
