using SimpleLog.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLog.Sample
{
    public class ClassB : IInterfaceB
    {
        private readonly ILogger<ClassB> log;

        public ClassB(ILogger<ClassB> log)
        {
            this.log = log;
        }

        public void DoSomethingB()
        {
            try
            {
                throw new Exception("oh no!");
            }
            catch (Exception ex)
            {
                log.Write(ex);
            }
        }
    }
}
