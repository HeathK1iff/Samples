using Samples.Generics.Abstractions;
using Samples.Generics.Entities;
using Samples.Generics.Extensions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.Dictionary.Commands;

internal class DictionaryIndexPropCommand : GenericCommandBase<Dictionary<string, Person>>
{
    public DictionaryIndexPropCommand(Dictionary<string, Person> dict, IConsole console) : base(dict, console)
    {
    }

    protected override void DoExecute(IConsole console, Dictionary<string, Person> dict)
    {
        console.WriteLine("Method: [key]");
        string key = console.Ask("Key: ");
        try
        {
            Person person = dict[key];
            console.WriteLine($"Out   : {person}");
        }
        catch (Exception ex)
        {
            console.WriteException(ex);
        }
    }
}
