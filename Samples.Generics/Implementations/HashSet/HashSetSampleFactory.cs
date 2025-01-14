using Samples.Generics.Abstractions;
using Samples.Generics.Implementations.HashSet.Commands;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.HashSet;

internal class HashSetSampleFactory : SampleFactoryBase
{
    private readonly HashSet<int> _hashSet = new();

    protected override CommandBase DoCreateCommand(Type commandType, IConsole console)
    {
        ThrowIfInvalidType(commandType);

        return Activator.CreateInstance(commandType, new object[] { _hashSet, console }) as CommandBase;
    }

    private void ThrowIfInvalidType(Type type)
    {
        if (!type.IsSubclassOf(typeof(GenericCommandBase<HashSet<int>>)))
        {
            throw new ArgumentException($"Invalid command type: {nameof(type)}");
        }
    }

    protected override (ConsoleKey Key, string Description, Type CommandType)[] GetCommands()
    {
        return new[]
        {
           (ConsoleKey.D0, "0. Print", typeof(HashSetPrintCommand)),
           (ConsoleKey.D1, "1. Add", typeof(HashSetAddCommand)),
           (ConsoleKey.D2, "2. IsSuperset", typeof(HashSetIsSupersetOfCommand)),
           (ConsoleKey.D3, "3. IsSubset", typeof(HashSetIsSubsetCommand)),
        };
    }
}
