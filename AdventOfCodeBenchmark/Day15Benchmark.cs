using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day15Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 15);
        }

        [Benchmark]
        public string D15_P1() => Day15.Puzzle1(input);

        [Benchmark]
        public string D15_P2() => Day15.Puzzle2(input);
    }
}
