using System;
using Xunit;
using TinyEventBus;
using System.Linq;
using Moq;
using System.Collections.Generic;
using System.Threading;
using SimpleLog.Abstractions;
using System.Reflection.Metadata;
using Microsoft.Extensions.Logging;
using sl = SimpleLog;
using System.Threading.Tasks;
using System.Text;

namespace TinyEventBus.UnitTest
{
    public class SimpleLog
    {
        [Fact]
        public void Should_Call_All_Methods_In_Appender()
        {
            var stub = new Mock<IAppender>();
            var wasInitiated = false;
            var wasEnded = false;

            var wordToWrite = "oh yeah!";
            var sb = new StringBuilder();

            stub.Setup(a => a.InitAsync()).Callback(() => { wasInitiated = true; });
            stub.Setup(a => a.CloseAsync()).Callback(() => wasEnded = true);
            stub.Setup(a => a.WriteAsync(It.IsAny<string>())).Callback<string>((m) => sb.AppendLine(m)).Returns(Task.CompletedTask);

            var log = new sl.Logger<SimpleLog>("X".Select(s => stub.Object).AsEnumerable());

            log.InitAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            log.Write(wordToWrite, Level.Debug);
            log.CloseAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            Assert.True(wasInitiated);
            Assert.True(wasEnded);
            Assert.Contains(wordToWrite, sb.ToString());
        }
    }
}
