using Samples.Generics.Abstractions;
using Samples.Generics.Implementations.Queue.Commands;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.Queue;

internal class QueueSampleFactory : SampleFactoryBase
{
    private readonly Queue<int> _equeue = new();
    protected override CommandBase DoCreateCommand(Type commandType, IConsole console)
    {
        return Activator.CreateInstance(commandType, new object[] { _equeue, console }) as CommandBase;
    }

    protected override (ConsoleKey Key, string Description, Type CommandType)[] GetCommands()
    {
        return new[]
       {
           (ConsoleKey.D0, "0. Print", typeof(QueuePrintCommand)),
           (ConsoleKey.D1, "1. Enqueue", typeof(QueueEnqueueCommand)),
           (ConsoleKey.D2, "2. Dequeue", typeof(QueueDequeueCommand)),
        };
    }
}
