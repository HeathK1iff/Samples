using Samples.Generics.Abstractions;
using Samples.Generics.Entities;
using Samples.Generics.Extensions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.SortedList.Commands;

internal class SortedListAddCommand : GenericCommandBase<SortedList<int, Person>>
{
    public SortedListAddCommand(SortedList<int, Person> sortedList, IConsole console) : base(sortedList, console)
    {
    }

    protected override void DoExecute(IConsole console, SortedList<int, Person> sortedList)
    {
        console.WriteLine("Method: void Add(int, Person)");
        int key = console.AskNumberOrDefault("Key: ");
        Person person = console.AskPerson("Person:");

        sortedList.Add(key, person);
    }
}
