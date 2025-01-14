using Samples.Generics.Abstractions;
using Samples.Generics.Entities;
using Samples.Generics.Implementations.SortedList.Commands;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.SortedList;

internal class SortedListSampleFactory : SampleFactoryBase
{
    private readonly SortedList<int, Person> _sortedList = new();

    protected override CommandBase DoCreateCommand(Type commandType, IConsole console)
    {
        return Activator.CreateInstance(commandType, new object[] { _sortedList, console }) as CommandBase;
    }

    protected override (ConsoleKey Key, string Description, Type CommandType)[] GetCommands()
    {
        return new[]
        {
           (ConsoleKey.D0, "0. Print", typeof(SortedListPrintCommand)),
           (ConsoleKey.D1, "1. Add", typeof(SortedListAddCommand)),
           (ConsoleKey.D2, "2. Remove", typeof(SortedListRemoveCommand))
        };
    }
}
