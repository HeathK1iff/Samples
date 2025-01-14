using Samples.Generics.Abstractions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.Queue.Commands;

internal class QueuePrintCommand : GenericCommandBase<Queue<int>>
{
    public QueuePrintCommand(Queue<int> list, IConsole console) : base(list, console)
    {
    }

    protected override void DoExecute(IConsole console, Queue<int> list)
    {
        console.WriteLine($"{string.Join(',', list.Select(item=>item.ToString()))}");
    }
}
