using Samples.Generics.Abstractions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.Stack.Commands;

internal class StackPeekCommand : GenericCommandBase<Stack<int>>
{
    public StackPeekCommand(Stack<int> list, IConsole console) : base(list, console)
    {
    }

    protected override void DoExecute(IConsole console, Stack<int> list)
    {
        console.WriteLine("Method: T Peek()");
        console.WriteLine($"Result = {list.Peek()}");
    }
}
