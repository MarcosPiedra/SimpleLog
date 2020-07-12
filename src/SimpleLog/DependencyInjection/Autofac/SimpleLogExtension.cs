using Autofac;
using SimpleLog.Abstractions;
using SimpleLog.DependencyInjection.Builder;
using System;
using System.Threading.Tasks;

namespace SimpleLog.DependencyInjection.Autofac
{
    public static class SimpleLogExtension
    {
        public static void AddSimpleLog(this ContainerBuilder builder, Action<IConfigurationBuilder> configure)
        {
            var configuration = new ConfigurationBuilder();

            configure(configuration);

            builder.RegisterGeneric(typeof(Logger<>))
                   .As(typeof(ILogger<>))
                   .InstancePerDependency()
                   .OnActivated(async d =>
                   {
                       var method = d.Instance.GetType().GetMethod("InitAsync");
                       var task = (Task)method.Invoke(d.Instance, new object[] { });
                       await task;
                   })
                   .OnRelease(async l =>
                   {
                       var method = l.GetType().GetMethod("CloseAsync");
                       var task = (Task)method.Invoke(l, new object[] { });
                       await task;
                   });

            foreach (var appenderType in configuration.GetAppenderTypes())
            {
                builder.RegisterType(appenderType)
                       .As<IAppender>();
            }
        }
    }
}
