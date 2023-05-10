using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day19Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(2022, 19);
        }

        [Benchmark]
        public string D19_P1() => Day19.Puzzle1(input);

        [Benchmark]
        public string D19_P2() => Day19.Puzzle2(input);
    }
}
