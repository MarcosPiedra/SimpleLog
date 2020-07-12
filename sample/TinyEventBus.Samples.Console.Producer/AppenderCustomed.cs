using SimpleLog.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Sample
{
    public class AppenderCustomed : IAppender
    {
        public Task CloseAsync() => Task.CompletedTask;

        public Task InitAsync() => Task.CompletedTask;

        public Task WriteAsync(string message)
        {
            Console.WriteLine($"{message} (from AppenderCustom)");
            return Task.CompletedTask; 
        }
    }
}
