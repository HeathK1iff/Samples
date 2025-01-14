using Samples.Generics.Abstractions;
using Samples.Generics.Entities;
using Samples.Generics.Extensions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.LinkedList.Commands;

internal class LinkedListAddAfterCommand : GenericCommandBase<LinkedList<Person>>
{
    public LinkedListAddAfterCommand(LinkedList<Person> list, IConsole console) : base(list, console)
    {
    }

    protected override void DoExecute(IConsole console, LinkedList<Person> list)
    {
        console.WriteLine("Method: void AddAfter(node, object)");

        Person person = console.AskPerson("Person:");

        console.WriteLine("Searching node...");
        LinkedListNode<Person> node = list.Find(person);

        if (node == null)
        {
            console.WriteLine("Node is not found");
            return;
        }

        list.AddAfter(node, console.AskPerson("Inserted Person"));
    }
}
