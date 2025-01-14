using Samples.Generics.Abstractions;
using Samples.Generics.Entities;
using Samples.Generics.Extensions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.LinkedList.Commands;

internal class LinkedListAddFirstCommand : GenericCommandBase<LinkedList<Person>>
{
    public LinkedListAddFirstCommand(LinkedList<Person> list, IConsole console) : base(list, console)
    {
    }

    protected override void DoExecute(IConsole console, LinkedList<Person> list)
    {
        console.WriteLine("Method: void AddFirst(object)");

        list.AddFirst(console.AskPerson("Person:"));
    }
}
