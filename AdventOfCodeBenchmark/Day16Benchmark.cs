using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day16Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 16);
        }

        [Benchmark]
        public string D16_P1() => Day16.Puzzle1(input);

        [Benchmark]
        public string D16_P2() => Day16.Puzzle2(input);
    }
}
