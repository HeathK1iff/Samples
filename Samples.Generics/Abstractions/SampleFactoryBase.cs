using Samples.Generics.Interfaces;

namespace Samples.Generics.Abstractions;

internal abstract class SampleFactoryBase
{
    public CommandBase CreateCommand(ConsoleKey key, IConsole console)
    {
        if (!HasCommand(key))
            throw new ArgumentOutOfRangeException(nameof(key));

        var commandTuple = GetCommands().First(item => item.Key.Equals(key));

        return DoCreateCommand(commandTuple.CommandType, console);
    }

    protected bool HasCommand(ConsoleKey key)
    {
        return GetCommands().Any(f => f.Key.Equals(key));
    }

    public (ConsoleKey Key, string Description)[] GetPromts()
    {
        return GetCommands().Select(c => (c.Key, c.Description)).ToArray();
    }
    protected abstract CommandBase DoCreateCommand(Type commandType, IConsole console);

    protected abstract (ConsoleKey Key, string Description, Type CommandType)[] GetCommands();
}


