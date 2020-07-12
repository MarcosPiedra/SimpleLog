using SimpleLog.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Appender
{
    public class ConsoleAppender : IAppender
    {
        public Task CloseAsync() => Task.CompletedTask;

        public Task InitAsync() => Task.CompletedTask;

        public Task WriteAsync(string message)
        {
            Console.WriteLine(message);
            return Task.CompletedTask;
        }
    }
}
