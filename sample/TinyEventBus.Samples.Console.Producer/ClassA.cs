using SimpleLog.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLog.Sample
{
    public class ClassA : IInterfaceA
    {
        private readonly ILogger<ClassA> log;

        public ClassA(ILogger<ClassA> log)
        {
            this.log = log;
        }

        public void DoSomethingA()
        {
            this.log.Write("Message Info from DoSomethingA", Level.Info);
            this.log.Write("Message Warn from DoSomethingA", Level.Warn);
            this.log.Write("Message Error from DoSomethingA", Level.Error);
            this.log.Write("Message Debug from DoSomethingA", Level.Debug);
        }
    }
}
