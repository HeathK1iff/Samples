using Samples.Generics.Abstractions;
using Samples.Generics.Entities;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.Dictionary.Commands;

internal class DictionaryAddCommand : GenericCommandBase<Dictionary<string, Person>>
{
    public DictionaryAddCommand(Dictionary<string, Person> dict, IConsole console) : base(dict, console)
    {
    }

    protected override void DoExecute(IConsole console, Dictionary<string, Person> dict)
    {
        console.WriteLine("Method: void Add(Key, Value)");
        string key = console.Ask("Key: ");
        Person person = new()
        {
            FirstName = console.Ask("First Name :"),
            LastName = console.Ask("Last Name  :")
        };

        dict.Add(key, person);
    }
}
