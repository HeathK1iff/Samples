using Samples.Generics.Abstractions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.Stack.Commands;

internal class StackPushCommand : GenericCommandBase<Stack<int>>
{
    public StackPushCommand(Stack<int> list, IConsole console) : base(list, console)
    {
    }

    protected override void DoExecute(IConsole console, Stack<int> list)
    {
        console.WriteLine("Method: void Push(Number)");

        if (int.TryParse(console.Ask("Value: "), out int val))
        {
            list.Push(val);            
            return;
        }
        console.WriteLine("Incorrect value");
    }
}
