using Samples.Generics.Abstractions;
using Samples.Generics.Entities;
using Samples.Generics.Extensions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.LinkedList.Commands;

internal class LinkedListRemoveCommand : GenericCommandBase<LinkedList<Person>>
{
    public LinkedListRemoveCommand(LinkedList<Person> list, IConsole console) : base(list, console)
    {
    }

    protected override void DoExecute(IConsole console, LinkedList<Person> list)
    {
        console.WriteLine("Method: void AfterNumber(node, object)");

        Person person = console.AskPerson("Person:");

        bool result = list.Remove(person);

        console.WriteLine($"Result: {result}");
    }
}
