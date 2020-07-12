using System;
using Xunit;
using TinyEventBus;
using System.Linq;
using Moq;
using System.Collections.Generic;
using System.Threading;

namespace TinyEventBus.UnitTest
{
    public class SimpleLog
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        public void Should_Be_A_Number_Queue_Correct(int num)
        {
            //var manager = new InMemorySubscriptionsManager() as ISubscriptionsManager;
            //var queues = new List<string>();

            //for (int i = 0; i < num; i++)
            //{
            //    queues.Add($"q{i}");
            //    SetAllEventHandlers(manager, i);
            //}

            //Assert.Equal(queues.AsEnumerable(), manager.GetConsumersQueues());
        }

        [Fact]
        public void Should_Remove_And_Throw_Of_Events()
        {
            //DoActionAndCheckEventsAndQueue(m => SetAllEventHandlers(m, 1),
            //                               m => m.RemoveConsumer(NewE<EventA>()));

            //DoActionAndCheckEventsAndQueue(m => SetAllEventHandlers(m, 1),
            //                               m => m.RemoveConsumer(NewE<EventB>()));

            //DoActionAndCheckEventsAndQueue(m => SetAllEventHandlers(m, 1),
            //                               m =>
            //                               {
            //                                   m.RemoveConsumer(NewE<EventA>(), NewEH<EventHandlerA>());
            //                                   m.RemoveConsumer(NewE<EventB>(), NewEH<EventHandlerB>());
            //                               });
        }

        [Fact]
        public void Should_Remove_And_Throw_Events_And_Queue()
        {
            //DoActionAndCheckEventsAndQueue(m =>
            //                               {
            //                                   SetAllEventHandlers(m, 1);
            //                                   SetEventHandlersA(m, 1);
            //                                   SetEventHandlersB(m, 2);
            //                               },
            //                               m =>
            //                               {
            //                                   m.RemoveConsumer("q1", NewE<EventA>());
            //                               });

            //DoActionAndCheckQueue(m =>
            //                      {
            //                          SetAllEventHandlers(m, 1);
            //                          SetEventHandlersA(m, 1);
            //                          SetEventHandlersB(m, 2);
            //                      },
            //                      m =>
            //                      {
            //                          m.RemoveConsumer("q1");
            //                      });
        }

        [Fact]
        public void Should_Be_Events_And_Handler_Registered()
        {
            //var manager = new InMemorySubscriptionsManager() as ISubscriptionsManager;
            //var managerComparer = new Mock<ISubscriptionsManager>();
            //var eventsAinQ1 = 0;

            //managerComparer.Setup(m => m.AddOrUpdateConsumer(It.IsIn("q1"), It.IsIn(NewE<EventA>()), It.IsAny<EventHandlerType>()))
            //               .Callback<string, EventType, EventHandlerType>((a, b, c) => eventsAinQ1++);

            //SetEventHandlersA(manager, 1);
            //SetEventHandlersA(managerComparer.Object, 1);
            //SetEventHandlersA(manager, 2);
            //SetEventHandlersA(managerComparer.Object, 2);
            //SetEventHandlersB(manager, 2);
            //SetEventHandlersB(managerComparer.Object, 2);

            //var x = manager.GetConsumersEvents("q1", "x");
            //Assert.Empty(x);

            //x = manager.GetConsumersEvents("q1", nameof(EventA));
            //Assert.Equal(2, eventsAinQ1);

            //var y = manager.GetConsumersEvents("q1");
            //Assert.Single(y);
        }

    }
}
