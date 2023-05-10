using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day08Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 8);
        }

        [Benchmark]
        public string D08_P1() => Day08.Puzzle1(input);

        [Benchmark]
        public string D08_P2() => Day08.Puzzle2(input);
    }
}
