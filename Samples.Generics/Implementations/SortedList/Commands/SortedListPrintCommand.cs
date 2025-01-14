using Samples.Generics.Abstractions;
using Samples.Generics.Entities;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.SortedList.Commands;

internal class SortedListPrintCommand : GenericCommandBase<SortedList<int, Person>>
{
    public SortedListPrintCommand(SortedList<int, Person> sortedList, IConsole console) : base(sortedList, console)
    {
        
    }

    protected override void DoExecute(IConsole console, SortedList<int, Person> sortedList)
    {
        string[] items = sortedList.Select(pair => $"{pair.Key} = {pair.Value}").ToArray();
        Console.WriteLine($"{string.Join(',', items)}");
    }
}
