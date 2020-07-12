using Microsoft.Extensions.Configuration;
using SimpleLog.Abstractions;
using System.Reflection;

namespace SimpleLog.DependencyInjection.Builder
{
    public interface IConfigurationBuilder
    {
        void AddConsole();
        void AddTextFile();
        void AddAppender<A>() where A : IAppender;
    }
}