using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day25Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D25_Puzzle;
        }

        [Benchmark]
        public string D25_P1() => Day25.Puzzle1(input);

        [Benchmark]
        public string D25_P2() => Day25.Puzzle2(input);
    }
}
