using Samples.Generics.Abstractions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.Stack.Commands;

internal class StackPopCommand : GenericCommandBase<Stack<int>>
{
    public StackPopCommand(Stack<int> list, IConsole console) : base(list, console)
    {
    }

    protected override void DoExecute(IConsole console, Stack<int> list)
    {
        console.WriteLine("Method: int Pop()");
        console.WriteLine($"Extract value {list.Pop()}");
    }
}
