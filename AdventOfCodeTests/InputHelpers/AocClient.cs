using System;
using System.Globalization;
using System.IO;
using System.Net;

namespace AdventOfCodeTests.InputHelpers
{
    public static class AocClient
    {
        private const string UriFormat = "https://adventofcode.com/{0}/day/{1}/input";

        private const string LastRequestEnvVar = "aoc_last_request";
        private const string SessionHeaderName = "session";
        private const string UserAgentValue = ".NET/6.0 (github.com/jlintvedt/AdventOfCode2022 via AocHttpClient.cs)";
        private const string UserSessionCookieFilename = "session_cookie.txt";

        public static string GetInput(int year, int day)
        {
            // Make sure requests are throttled
            var lastRequest = GetLastRequestTime();
            var nextAllowed = lastRequest.Add(TimeSpan.FromMinutes(1));
            var now = DateTime.Now;

            if (now < nextAllowed)
                throw new ProtocolViolationException("Do not send requests more often than once per minute.");

            SetLastRequestTime(now);

            // Get input from AoC
            var wc = new WebClient();
            var uri = new Uri(string.Format(UriFormat, year, day));
            wc.Headers.Add(HttpRequestHeader.UserAgent, UserAgentValue);
            wc.Headers.Add(HttpRequestHeader.Cookie, $"{SessionHeaderName}={GetSessionToken()}");
            return wc.DownloadString(uri).TrimEnd('\n').Replace("\n", Environment.NewLine);
        }

        private static void SetLastRequestTime(DateTime time)
        {
            Environment.SetEnvironmentVariable(
                variable: LastRequestEnvVar,
                value: time.ToString(CultureInfo.CurrentCulture),
                target: EnvironmentVariableTarget.User);
        }

        private static DateTime GetLastRequestTime()
        {
            var lastRequestString = Environment.GetEnvironmentVariable(
                variable: LastRequestEnvVar,
                target: EnvironmentVariableTarget.User);

            return !string.IsNullOrWhiteSpace(lastRequestString) && DateTime.TryParse(lastRequestString, out var time)
                ? time
                : DateTime.UnixEpoch;
        }

        private static string GetSessionToken()
        {
            if (string.IsNullOrEmpty(SessionToken.Token))
            {
                throw new MemberAccessException("Token not set in InputHelpers/SessionToken.cs");
            }

            return SessionToken.Token;
        }
    }
}