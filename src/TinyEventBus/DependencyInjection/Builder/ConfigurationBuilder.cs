using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using SimpleLog.Abstractions;
using SimpleLog.Appender;

namespace SimpleLog.DependencyInjection.Builder
{
    public class ConfigurationBuilder : IConfigurationBuilder
    {
        private List<Type> appenderTypes = new List<Type>();

        public ConfigurationBuilder()
        {
        }

        public void AddAppender<A>() where A : IAppender
        {
            AddIfNotExists(typeof(A));
        }

        public void AddConsole()
        {
            AddIfNotExists(typeof(ConsoleAppender));
        }

        public void AddTextFile()
        {
            AddIfNotExists(typeof(FileAppender));
        }

        private void AddIfNotExists(Type toAdd)
        {
            if (appenderTypes.Any(t => t.Equals(toAdd)))
                return;

            appenderTypes.Add(toAdd);
        }

        public IEnumerable<Type> GetAppenderTypes() => appenderTypes;
    }
}