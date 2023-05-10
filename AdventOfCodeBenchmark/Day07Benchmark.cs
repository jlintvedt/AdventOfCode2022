using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day07Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 7);
        }

        [Benchmark]
        public string D07_P1() => Day07.Puzzle1(input);

        [Benchmark]
        public string D07_P2() => Day07.Puzzle2(input);
    }
}
