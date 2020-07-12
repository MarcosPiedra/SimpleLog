﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Abstractions
{
    [Flags]
    public enum Level
    {
        All = 0x001,
        Debug = 0x002,
        Info = 0x004,
        Warn = 0x008,
        Error = 0x010,
        Fatal = 0x020,
    }

    public interface ILogger<T>
    {
        Task InitAsync();
        Task CloseAsync();
        void Write(string message, Level level);
        void Write(Exception ex);
    }
}
