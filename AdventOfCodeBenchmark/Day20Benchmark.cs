using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day20Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 20);
        }

        [Benchmark]
        public string D20_P1() => Day20.Puzzle1(input);

        [Benchmark]
        public string D20_P2() => Day20.Puzzle2(input);
    }
}
