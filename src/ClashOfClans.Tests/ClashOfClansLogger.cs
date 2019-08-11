using ClashOfClans.Core;
using System;
using System.IO;

namespace ClashOfClans.Tests
{
    class ClashOfClansLogger : IClashOfClansLogger
    {
        private readonly string _logFile;

        public ClashOfClansLogger(string logPath)
        {
            Directory.CreateDirectory(logPath);

            var today = DateTime.Now.ToString("yyyyMMdd");
            _logFile = Path.Combine(logPath, $"{today}-CoC.log");

            // Daily log file that has only the last test execution results
            File.Delete(_logFile);
        }

        public void Log(string message)
        {
            File.AppendAllText(_logFile, message + Environment.NewLine);
        }
    }
}
