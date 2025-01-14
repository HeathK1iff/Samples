using Samples.Generics.Abstractions;
using Samples.Generics.Entities;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.Dictionary.Commands;

internal class DictionaryTryToGetCommand : GenericCommandBase<Dictionary<string, Person>>
{
    public DictionaryTryToGetCommand(Dictionary<string, Person> dict, IConsole console) : base(dict, console)
    {
    }

    protected override void DoExecute(IConsole console, Dictionary<string, Person> dict)
    {
        console.WriteLine("Method: bool TryGetValue(key, out object)");
        string key = console.Ask("Key: ");
        bool resultMethod = dict.TryGetValue(key, out Person person);
        console.WriteLine($"Result: {resultMethod}");
        console.WriteLine($"Out   : {person}");
    }
}
