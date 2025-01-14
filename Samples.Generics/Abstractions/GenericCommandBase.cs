using Samples.Generics.Interfaces;

namespace Samples.Generics.Abstractions;

internal abstract class GenericCommandBase<T> : CommandBase where T : class
{
    private readonly T _list;

    protected GenericCommandBase(T list, IConsole console) : base(console)
    {
        _list = list;
    }

    protected override void DoExecute(IConsole console)
    {
        DoExecute(console, _list);
    }

    protected abstract void DoExecute(IConsole console, T list);
}