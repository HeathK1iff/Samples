using Samples.Generics.Abstractions;
using Samples.Generics.Abstractions.Commands;
using Samples.Generics.Entities;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.SortedDictionary;

internal class SortedDictionarySampleFactory : SampleFactoryBase
{
    private readonly SortedDictionary<string, Person> _sortedDict = new();

    protected override CommandBase DoCreateCommand(Type commandType, IConsole console)
    {
        return Activator.CreateInstance(commandType, new object[] { _sortedDict, console }) as CommandBase;
    }

    protected override (ConsoleKey Key, string Description, Type CommandType)[] GetCommands()
    {
        return new[]
        {
           (ConsoleKey.D0, "0. Print", typeof(CollectionPrintKeyValuePairsCommand)),
           (ConsoleKey.D1, "1. Add", typeof(CollectionAddKeyValuePairCommand)),
           (ConsoleKey.D2, "2. Remove", typeof(DictionaryRemoveKeyCommand))
        };
    }
}
