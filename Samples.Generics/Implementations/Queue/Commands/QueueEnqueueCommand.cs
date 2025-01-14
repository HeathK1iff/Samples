using Samples.Generics.Abstractions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.Queue.Commands;

internal class QueueEnqueueCommand : GenericCommandBase<Queue<int>>
{
    public QueueEnqueueCommand(Queue<int> list, IConsole console) : base(list, console)
    {
    }

    protected override void DoExecute(IConsole console, Queue<int> list)
    {
        if (int.TryParse(console.Ask("Value: "), out int val))
        {
            list.Enqueue(val);
        }
        console.WriteLine("Incorrect value");
    }
}
