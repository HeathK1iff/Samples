using Samples.Generics.Abstractions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.Queue.Commands;

internal class QueueDequeueCommand : GenericCommandBase<Queue<int>>
{
    public QueueDequeueCommand(Queue<int> list, IConsole console) : base(list, console)
    {
    }

    protected override void DoExecute(IConsole console, Queue<int> list)
    {
        console.WriteLine($"Value = { list.Dequeue() }");
    }
}
