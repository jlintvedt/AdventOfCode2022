using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day11Benchmark
    {
        string input;

        [Params(10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 11);
        }

        [Benchmark]
        public string D11_P1() => Day11.Puzzle1(input);

        [Benchmark]
        public string D11_P2() => Day11.Puzzle2(input);
    }
}
