using Samples.Generics.Entities;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Abstractions.Commands;

internal class DictionaryRemoveKeyCommand : GenericCommandBase<IDictionary<string, Person>>
{
    public DictionaryRemoveKeyCommand(IDictionary<string, Person> list, IConsole console) : base(list, console)
    {
    }

    protected override void DoExecute(IConsole console, IDictionary<string, Person> list)
    {
        console.WriteLine("Method: bool Remove(int)");
        string key = console.Ask("Key:");
        bool result = list.Remove(key);
        console.WriteLine($"Result: {result}");
    }
}
