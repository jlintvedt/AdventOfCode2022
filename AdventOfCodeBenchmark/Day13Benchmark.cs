using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day13Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 13);
        }

        [Benchmark]
        public string D13_P1() => Day13.Puzzle1(input);

        [Benchmark]
        public string D13_P2() => Day13.Puzzle2(input);
    }
}
