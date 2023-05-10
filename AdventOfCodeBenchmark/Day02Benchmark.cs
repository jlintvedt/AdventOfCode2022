using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day02Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 2);
        }

        [Benchmark]
        public string D02_P1() => Day02.Puzzle1(input);

        [Benchmark]
        public string D02_P2() => Day02.Puzzle2(input);
    }
}
