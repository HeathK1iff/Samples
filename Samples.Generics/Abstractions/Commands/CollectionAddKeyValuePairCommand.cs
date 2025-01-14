using Samples.Generics.Entities;
using Samples.Generics.Extensions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Abstractions.Commands;

internal sealed class CollectionAddKeyValuePairCommand : GenericCommandBase<ICollection<KeyValuePair<string, Person>>>
{
    public CollectionAddKeyValuePairCommand(ICollection<KeyValuePair<string, Person>> list, IConsole console) : base(list, console)
    {
    }

    protected override void DoExecute(IConsole console, ICollection<KeyValuePair<string, Person>> list)
    {
        console.WriteLine("Method: void Add(Key, Value)");
        string key = console.Ask("Key: ");
        Person person = new()
        {
            FirstName = console.Ask("First Name :"),
            LastName = console.Ask("Last Name  :")
        };

        list.Add(new KeyValuePair<string, Person>(key, person));
    }
}
