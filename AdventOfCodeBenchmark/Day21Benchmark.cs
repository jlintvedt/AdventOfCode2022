﻿using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day21Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D21_Puzzle;
        }

        [Benchmark]
        public string D21_P1() => Day21.Puzzle1(input);

        [Benchmark]
        public string D21_P2() => Day21.Puzzle2(input);
    }
}
