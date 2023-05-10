using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day17Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 17);
        }

        [Benchmark]
        public string D17_P1() => Day17.Puzzle1(input);

        [Benchmark]
        public string D17_P2() => Day17.Puzzle2(input);
    }
}
