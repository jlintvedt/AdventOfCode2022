# AdventOfCode2020

### Running benchmarks
Update reference [BenchmarkRunner.Run<Day**17**Benchmark>(config)](AdventOfCodeBenchmark/Program.cs).

Run without debugger: `ctrl+f5` in VS Code. This stores the benchmark in [results](AdventOfCodeBenchmark\BenchmarkDotNet.Artifacts\results) folder and the [Results](Results.json) file, also updates the table below.

## Runtimes
<!--ResultTableStart-->
|                                |         | Test @3.8GHz<sup>1</sup> | Benchmark<sup>2</sup> |
|--------------------------------|---------|-------------------------:|----------------------:|
| [Day01](AdventOfCode/Day01.cs) | Puzzle1 |                      1ms |                   0ns |
|                                | Puzzle2 |                          |                   0ns |
<!--ResultTableEnd-->

1) Desktop AMD Ryzen 9 3900X @3.8/4.6GHz. Visual Studio Test Explorer
2) Desktop AMD Ryzen 9 3900X @3.8/4.6GHz. Using [DotNetBenchmark](https://github.com/dotnet/BenchmarkDotNet).