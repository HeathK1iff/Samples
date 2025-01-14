using Samples.Generics.Abstractions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.Stack.Commands;

internal class StackPrintCommand : GenericCommandBase<Stack<int>>
{
    public StackPrintCommand(Stack<int> list, IConsole console) : base(list, console)
    {
    }

    protected override void DoExecute(IConsole console, Stack<int> list)
    {
        console.WriteLine($"{string.Join(',', list.Select(item => item.ToString()))}");
    }
}
