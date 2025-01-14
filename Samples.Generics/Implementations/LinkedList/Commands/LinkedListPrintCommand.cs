using Samples.Generics.Abstractions;
using Samples.Generics.Entities;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.LinkedList.Commands;

internal class LinkedListPrintCommand : GenericCommandBase<LinkedList<Person>>
{
    public LinkedListPrintCommand(LinkedList<Person> list, IConsole console) : base(list, console)
    {
    }

    protected override void DoExecute(IConsole console, LinkedList<Person> list)
    {
        LinkedListNode<Person> node = list.First;

        if (node == null)
        {
            return;
        }

        do
        {
            console.WriteLine(node.Value.ToString());

        } while (node.Next != null);
     }
}
