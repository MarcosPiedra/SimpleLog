using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Abstractions
{
    public interface IAppender
    {
        Task InitAsync();
        Task CloseAsync();
        Task WriteAsync(string message);
    }
}
