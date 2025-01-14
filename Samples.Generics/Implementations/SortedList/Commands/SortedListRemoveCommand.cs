using Samples.Generics.Abstractions;
using Samples.Generics.Entities;
using Samples.Generics.Extensions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.SortedList.Commands;

internal class SortedListRemoveCommand : GenericCommandBase<SortedList<int, Person>>
{
    public SortedListRemoveCommand(SortedList<int, Person> sortedList, IConsole console) : base(sortedList, console)
    {
    }

    protected override void DoExecute(IConsole console, SortedList<int, Person> sortedList)
    {
        console.WriteLine("Method: bool Remove(int)");
        int key = console.AskNumberOrDefault("Key:");
        bool result = sortedList.Remove(key);
        console.WriteLine($"Result: {result}");
    }
}
