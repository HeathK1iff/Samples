using Samples.Generics.Interfaces;

namespace Samples.Generics.Abstractions;

internal abstract class CommandBase
{
    private readonly IConsole _console;
    protected CommandBase(IConsole console)
    {
        _console = console;
    }

    public void Execute()
    {
        try
        {
            DoExecute(_console);
        }
        catch (Exception ex)
        {
            _console.WriteLine("Exception:" + ex.ToString());
        }
    }

    protected abstract void DoExecute(IConsole console);
}


