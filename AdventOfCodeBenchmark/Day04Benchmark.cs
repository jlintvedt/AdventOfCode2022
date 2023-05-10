using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day04Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 4);
        }

        [Benchmark]
        public string D04_P1() => Day04.Puzzle1(input);

        [Benchmark]
        public string D04_P2() => Day04.Puzzle2(input);
    }
}
