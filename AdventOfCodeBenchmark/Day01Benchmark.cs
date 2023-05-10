using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day01Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 1);
        }

        [Benchmark]
        public string D01_P1() => Day01.Puzzle1(input);

        [Benchmark]
        public string D01_P2() => Day01.Puzzle2(input);
    }
}
