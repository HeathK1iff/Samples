using Samples.Generics.Abstractions;
using Samples.Generics.Entities;
using Samples.Generics.Implementations.LinkedList.Commands;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.LinkedList;

internal class LinkedListSampleFactory : SampleFactoryBase
{
    private readonly LinkedList<Person> _list = new();

    protected override CommandBase DoCreateCommand(Type commandType, IConsole console)
    {
        return Activator.CreateInstance(commandType, new object[] { _list, console }) as CommandBase;
    }

    protected override (ConsoleKey Key, string Description, Type CommandType)[] GetCommands()
    {
        return new[]
        {
           (ConsoleKey.D0, "0. Print", typeof(LinkedListPrintCommand)),
           (ConsoleKey.D1, "1. AddAfter", typeof(LinkedListAddAfterCommand)),
           (ConsoleKey.D2, "2. Remove", typeof(LinkedListRemoveCommand)),
           (ConsoleKey.D3, "3. AddFirst", typeof(LinkedListAddFirstCommand))
        };
    }
}
