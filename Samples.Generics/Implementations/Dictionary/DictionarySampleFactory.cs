using Samples.Generics.Abstractions;
using Samples.Generics.Abstractions.Commands;
using Samples.Generics.Entities;
using Samples.Generics.Implementations.Dictionary.Commands;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.Dictionary;

internal class DictionarySampleFactory : SampleFactoryBase
{
    private readonly Dictionary<string, Person> _personDict = new();

    protected override (ConsoleKey Key, string Description, Type CommandType)[] GetCommands()
    {
        return new[]
        {
           (ConsoleKey.D0, "0. Print", typeof(CollectionPrintKeyValuePairsCommand)),
           (ConsoleKey.D1, "1. Add", typeof(CollectionAddKeyValuePairCommand)),
           (ConsoleKey.D2, "2. TryToGet", typeof(DictionaryTryToGetCommand)),
           (ConsoleKey.D3, "3. [Key]", typeof(DictionaryIndexPropCommand)),
           (ConsoleKey.D4, "4. Remove", typeof(DictionaryRemoveKeyCommand))
        };
    }

    protected override CommandBase DoCreateCommand(Type commandType, IConsole console)
    {
        return Activator.CreateInstance(commandType, new object[] { _personDict, console }) as CommandBase;
    }
}


