using SimpleLog.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleLog
{
    public class Logger<T> : ILogger<T>
    {
        private readonly IEnumerable<IAppender> _appenders;
        string _lineFormat = "hh:mm:ss.ffff";
        Type _type;

        Task _loggerTask;
        ManualResetEventSlim _msgAdded = new ManualResetEventSlim(false);
        ConcurrentQueue<Task> _appendersTasks = new ConcurrentQueue<Task>();
        CancellationTokenSource _tokenSource = new CancellationTokenSource();

        public Logger(IEnumerable<IAppender> appenders)
        {
            _appenders = appenders;
            _type = typeof(T);

            if (_appenders.Count() == 0)
                return;

            _loggerTask = Task.Run(async () =>
            {
                while (!_tokenSource.IsCancellationRequested)
                {
                    _msgAdded.WaitHandle.WaitOne();
                    _msgAdded.Reset();

                    var taskList = new List<Task>();
                    while (_appendersTasks.Count > 0)
                    {
                        _appendersTasks.TryDequeue(out Task task);
                        taskList.Add(task);
                    }
                    await Task.WhenAll(taskList.ToArray());
                }
            });
        }

        private void InternalWrite(string message)
        {
            var msg = new StringBuilder();
            msg.Append(_type.Name);
            msg.Append(" ");
            msg.Append(DateTime.Now.ToString(_lineFormat));
            msg.Append(" ");
            msg.Append(msg);
            msg.Append(" ");
            msg.AppendLine(message);

            EnqueueMessage(msg.ToString());
        }

        public void Write(string message, Level level)
        {
            var msg = new StringBuilder();
            msg.Append(GetLevelName(level));
            msg.Append(" ");
            msg.Append(message);
            InternalWrite(msg.ToString());
        }

        public void Write(Exception ex)
        {
            var msg = new StringBuilder();
            msg.AppendLine("-- Ini ex.");
            msg.AppendLine(ex.Message);
            msg.AppendLine(ex.StackTrace);
            msg.AppendLine("-- Fin ex.");
            InternalWrite(msg.ToString());
        }

        private void EnqueueMessage(string message)
        {
            foreach (var listener in _appenders)
            {
                _appendersTasks.Enqueue(listener.WriteAsync(message));
            }
            _msgAdded.Set();
        }

        private string GetLevelName(Level level) => level.ToString().PadRight(7, ' ');

        public async Task InitAsync()
        {
            await Task.WhenAll(_appenders.Select(a => a.InitAsync()));
            Write("/*************** Log Started  ***************/", Level.Info);
        }

        public async Task CloseAsync()
        {
            Write("/*************** Log Finished ***************/", Level.Info);
            _tokenSource.Cancel();
            await Task.WhenAll(new Task[] { _loggerTask });
            await Task.WhenAll(_appenders.Select(async l => await l.CloseAsync()));
        }
    }
}