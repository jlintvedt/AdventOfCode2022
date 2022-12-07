using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/7
    /// </summary>
    public class Day07
    {
        public class Device
        {
            private FileSystem fs;

            public Device(string input)
            {
                fs = new FileSystem();

                var cmdOutputPairings = input.Split("$");
                for (int i = 1; i < cmdOutputPairings.Length; i++)
                {
                    fs.ExecuteCmdOutputPairing(cmdOutputPairings[i]);
                }

                fs.ExecuteCmdOutputPairing("ls");
            }

            public long FindSizeSumOfAllDirectories(int maxSize)
            {
                long size = 0;
                fs.rootDirectory.AddSizeOfDirectoriesRec(maxSize, ref size);
                return size;
            }
        }

        public class FileSystem
        {
            public readonly Directory rootDirectory;
            private Directory currentDirectory;

            public FileSystem()
            {
                rootDirectory = new Directory("/");
                currentDirectory = rootDirectory;
            }

            public void ExecuteCmdOutputPairing(string pairing)
            {
                var lines = pairing.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                var cmd = lines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                // Change Directory
                if (cmd[0] == "cd")
                {
                    switch (cmd[1])
                    {
                        case "/":
                            currentDirectory = rootDirectory;
                            break;
                        case "..":
                            currentDirectory = currentDirectory.ParentDirectory;
                            break;
                        default:
                            currentDirectory = currentDirectory.GetSubDirectory(cmd[1]);
                            break;
                    }
                }
                // List
                else if (cmd[0] == "ls")
                {
                    for (int i = 1; i < lines.Length; i++)
                    {
                        currentDirectory.AddDirectoryOrFile(lines[i]);
                    }
                }
                else
                {
                    throw new InvalidProgramException($"Unknown cmd [{cmd}]");
                }

            }


            public class Directory
            {
                public string Name;
                public Directory ParentDirectory;
                private Dictionary<string, Directory> directories = new Dictionary<string, Directory>();
                private List<File> files = new List<File>();
                private long _size = -1;

                public long Size
                {
                    get
                    {
                        if (_size < 0)
                        {
                            _size = 0;
                            foreach (var file in files)
                            {
                                _size += file.Size;
                            }

                            foreach (var dir in directories)
                            {
                                _size += dir.Value.Size;
                            }
                        }

                        return _size;
                    }
                }

                public Directory(string name, Directory parentDirectory = null)
                {
                    Name = name;
                    ParentDirectory = parentDirectory;
                }

                public void AddDirectoryOrFile(string line)
                {
                    var args = line.Split(" ");
                    // Sub-directory
                    if (args[0] == "dir")
                    {
                        var name = args[1];
                        directories.Add(name, new Directory(name, this));
                    } 
                    // File
                    else
                    {
                        var size = long.Parse(args[0]);
                        var name = args[1];
                        files.Add(new File(name, size));
                    }
                }

                public Directory GetSubDirectory(string name)
                {
                    if (directories.TryGetValue(name, out Directory sub))
                    {
                        return sub;
                    }

                    throw new InvalidProgramException();
                }

                public void AddSizeOfDirectoriesRec (int maxSize, ref long sumSize)
                {
                    if (Size <= maxSize)
                    {
                        sumSize += Size;
                    }

                    foreach (var (_, dir) in directories)
                    {
                        dir.AddSizeOfDirectoriesRec(maxSize, ref sumSize);
                    }
                }
            }

            public class File
            {
                public string Name;
                public long Size;

                public File(string name, long size)
                {
                    Name = name;
                    Size = size;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var dev = new Device(input);
            return dev.FindSizeSumOfAllDirectories(100000).ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
