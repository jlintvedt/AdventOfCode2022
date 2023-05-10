using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day21Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 21);
        }

        [Benchmark]
        public string D21_P1() => Day21.Puzzle1(input);

        [Benchmark]
        public string D21_P2() => Day21.Puzzle2(input);
    }
}
