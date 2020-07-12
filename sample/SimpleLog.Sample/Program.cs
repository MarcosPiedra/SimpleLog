using Autofac;
using SimpleLog.DependencyInjection.Autofac;
using System;
using System.Threading.Tasks;

namespace SimpleLog.Sample
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.AddSimpleLog(c =>
            {
                c.AddConsole();
                c.AddTextFile();
                c.AddAppender<AppenderCustomed>();
            });
            builder.RegisterType<ClassA>().As<IInterfaceA>();
            builder.RegisterType<ClassB>().As<IInterfaceB>();
            var container = builder.Build();

            using (var lifetime = container.BeginLifetimeScope())
            {
                var instanceA = lifetime.Resolve<IInterfaceA>();
                var instanceB = lifetime.Resolve<IInterfaceB>();

                instanceA.DoSomethingA();
                instanceB.DoSomethingB();
            }

            return Task.CompletedTask;
        }
    }
}
