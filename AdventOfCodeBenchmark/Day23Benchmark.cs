using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day23Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D23_Puzzle;
        }

        [Benchmark]
        public string D23_P1() => Day23.Puzzle1(input);

        [Benchmark]
        public string D23_P2() => Day23.Puzzle2(input);
    }
}
