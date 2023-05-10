using System;
using System.IO;

namespace AdventOfCodeTests.InputHelpers
{
    public static class InputProvider
    {
        private const string RootDirectoryFormat = "AdventOfCode{0}";
        private const string TestDirectoryName = "AdventOfCodeTests";
        private const string InputDirectoryName = "Inputs";
        private const string FilenameFormat = "D{0:00}_Input.txt";

        public static string GetInput(int year, int day)
        {
            var path = GetAbsolutePath(year, day);

            // Try getting cached file.
            if (TryReadFile(path, out string content))
            {
                return content;
            }

            // Fetch from web
            try
            {
                content = AocClient.GetInput(year, day);
                WriteFile(path, content);
                return content;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static bool TryReadFile(string filepath, out string content)
        {
            content = null;
            try
            {
                content = File.ReadAllText(filepath);
                return !string.IsNullOrEmpty(content);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void WriteFile(string filepath, string content)
        {
            File.WriteAllText(filepath, content);
        }

        private static string GetAbsolutePath(int year, int day)
        {
            var binPath = Directory.GetCurrentDirectory();
            var rootDirName = string.Format(RootDirectoryFormat, year);
            var filename = string.Format(FilenameFormat, day);
            return Path.Combine(
                binPath[..binPath.IndexOf(rootDirName)],
                rootDirName,
                TestDirectoryName,
                InputDirectoryName,
                filename);
        }
    }
}
