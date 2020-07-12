using SimpleLog.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Appender
{
    public class FileAppender : IAppender
    {
        string _workingDir = "";
        string _dateFormat = "dd-MM-yyyy";
        string _lastPath = "";

        public FileAppender()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var root = Directory.GetDirectoryRoot(baseDir);
            _workingDir = Path.Combine(root, "SimpleLogs");
            if (!Directory.Exists(_workingDir))
                Directory.CreateDirectory(_workingDir);
        }

        public Task CloseAsync() => Task.CompletedTask;
        public async Task InitAsync()
        {
            _lastPath = GetCurrentPath();
            if (!File.Exists(_lastPath))
                await File.WriteAllTextAsync(_lastPath, "");
        }

        public async Task WriteAsync(string message)
        {
            if (!_lastPath.Equals(GetCurrentPath()))
            {
                await InitAsync();
            }
            await File.AppendAllTextAsync(GetCurrentPath(), message);
        }

        private string GetCurrentPath()
        {
            var name = DateTime.Now.ToString(_dateFormat);
            return Path.Combine(_workingDir, $"Log_{name}.txt");
        }
    }
}
