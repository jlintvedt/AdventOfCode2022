using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day11Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D11_Puzzle;
        }

        [Benchmark]
        public string D11_P1() => Day11.Puzzle1(input);

        [Benchmark]
        public string D11_P2() => Day11.Puzzle2(input);
    }
}
