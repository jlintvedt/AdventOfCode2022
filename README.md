# AdventOfCode2022

### Running benchmarks
Update reference [BenchmarkRunner.Run<Day**17**Benchmark>(config)](AdventOfCodeBenchmark/Program.cs).

Run without debugger: `ctrl+f5` in VS Code. This stores the benchmark in [results](AdventOfCodeBenchmark\BenchmarkDotNet.Artifacts\results) folder and the [Results](Results.json) file, also updates the table below.

## Runtimes
<!--ResultTableStart-->
|                                |         | Test @3.8GHz<sup>1</sup> | Benchmark<sup>2</sup> |
|--------------------------------|---------|-------------------------:|----------------------:|
| [Day01](AdventOfCode/Day01.cs) | Puzzle1 |                     <1ms |                  93μs |
|                                | Puzzle2 |                     <1ms |                  94μs |
| [Day02](AdventOfCode/Day02.cs) | Puzzle1 |                     <1ms |                 131μs |
|                                | Puzzle2 |                     <1ms |                 125μs |
| [Day03](AdventOfCode/Day03.cs) | Puzzle1 |                     <1ms |                 268μs |
|                                | Puzzle2 |                     <1ms |                 341μs |
| [Day04](AdventOfCode/Day04.cs) | Puzzle1 |                     <1ms |                 205μs |
|                                | Puzzle2 |                     <1ms |                 205μs |
| [Day05](AdventOfCode/Day05.cs) | Puzzle1 |                     <1ms |                 154μs |
|                                | Puzzle2 |                     <1ms |                 176μs |
| [Day06](AdventOfCode/Day06.cs) | Puzzle1 |                     <1ms |                  15μs |
|                                | Puzzle2 |                     <1ms |                  14μs |
| [Day07](AdventOfCode/Day07.cs) | Puzzle1 |                     <1ms |                 298μs |
|                                | Puzzle2 |                     <1ms |                 301μs |
| [Day08](AdventOfCode/Day08.cs) | Puzzle1 |                      1ms |                 696μs |
|                                | Puzzle2 |                      1ms |                 791μs |
| [Day09](AdventOfCode/Day09.cs) | Puzzle1 |                      1ms |                 653μs |
|                                | Puzzle2 |                      2ms |                 697μs |
| [Day10](AdventOfCode/Day10.cs) | Puzzle1 |                     <1ms |                  14μs |
|                                | Puzzle2 |                     <1ms |                  14μs |
| [Day11](AdventOfCode/Day11.cs) | Puzzle1 |                      1ms |                  62μs |
|                                | Puzzle2 |                     74ms |                  30ms |
<!--ResultTableEnd-->

1) Desktop AMD Ryzen 9 3900X @3.8/4.6GHz. Visual Studio Test Explorer
2) Desktop AMD Ryzen 9 3900X @3.8/4.6GHz. Using [DotNetBenchmark](https://github.com/dotnet/BenchmarkDotNet).