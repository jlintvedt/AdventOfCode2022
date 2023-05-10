using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day22Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 22);
        }

        [Benchmark]
        public string D22_P1() => Day22.Puzzle1(input);

        [Benchmark]
        public string D22_P2() => Day22.Puzzle2(input);
    }
}
