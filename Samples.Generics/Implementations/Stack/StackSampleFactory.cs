using Samples.Generics.Abstractions;
using Samples.Generics.Entities;
using Samples.Generics.Implementations.Stack.Commands;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.Stack;

internal class StackSampleFactory : SampleFactoryBase
{
    private readonly Stack<int> _stack = new();
    protected override CommandBase DoCreateCommand(Type commandType, IConsole console)
    {
        return Activator.CreateInstance(commandType, new object[] { _stack, console }) as CommandBase;
    }

    protected override (ConsoleKey Key, string Description, Type CommandType)[] GetCommands()
    {
        return new[]
        {
           (ConsoleKey.D0, "0. Print", typeof(StackPrintCommand)),
           (ConsoleKey.D1, "1. Push", typeof(StackPushCommand)),
           (ConsoleKey.D2, "2. Pop", typeof(StackPopCommand)),
           (ConsoleKey.D3, "3. Peek", typeof(StackPeekCommand))
        };
    }
}
