using Samples.Generics.Entities;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Abstractions.Commands;

internal sealed class CollectionPrintKeyValuePairsCommand : GenericCommandBase<ICollection<KeyValuePair<string, Person>>>
{
    public CollectionPrintKeyValuePairsCommand(ICollection<KeyValuePair<string, Person>> list, IConsole console) : base(list, console)
    {
    }

    protected override void DoExecute(IConsole console, ICollection<KeyValuePair<string, Person>> list)
    {
        string[] pairs = list.Select(pair => $"{pair.Key} = {pair.Value}").ToArray();

        foreach (string pair in pairs)
        {
            console.WriteLine(pair);
        }
    }
}