using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day10Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 10);
        }

        [Benchmark]
        public string D10_P1() => Day10.Puzzle1(input);

        [Benchmark]
        public string D10_P2() => Day10.Puzzle2(input);
    }
}
