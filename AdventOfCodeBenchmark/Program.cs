using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Running;
using AdventOfCodeTests.InputHelpers;
using System;

namespace AdventOfCodeBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var runBenchmark = true;

            if (runBenchmark)
                RunBenchmark();
            else
                RunCodeForProfiling();
        }

        private static void RunBenchmark()
        {
            var resultHandler = new ResultHandler();
            var config = ManualConfig.CreateEmpty()
                .AddColumnProvider(DefaultColumnProviders.Instance)
                .AddLogger(ConsoleLogger.Default)
                .AddExporter(MarkdownExporter.GitHub);

            var summary = BenchmarkRunner.Run<Day12Benchmark>(config);
            resultHandler.UpdateBenchmark(summary, writeToFile: true);

            resultHandler.UpdateResultsInReadme();
        }

        private static void RunCodeForProfiling()
        {
            var input_puzzle = InputProvider.GetInput(2022, 12);
            var result = AdventOfCode.Day12.Puzzle2(input_puzzle);

            Console.WriteLine($"Profiling result: {result}");
        }
    }
}
