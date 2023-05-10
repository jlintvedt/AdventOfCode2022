using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day06Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 6);
        }

        [Benchmark]
        public string D06_P1() => Day06.Puzzle1(input);

        [Benchmark]
        public string D06_P2() => Day06.Puzzle2(input);
    }
}
