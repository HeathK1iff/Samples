using Samples.Security.Application.Abstractions;
using Samples.Security.Application.Exceptions;
using Samples.Security.Application.Extensions;
using Samples.Security.Application.Interfaces;

namespace Samples.Security.Application.Implementations;

internal class CommandInvoker : ICommandInvoker
{
    private readonly IConsole _console;
    private readonly ICommandFactory _commandFactory;
    public CommandInvoker(IConsole console,
        ICommandFactory commandFactory)
    {
        _commandFactory = commandFactory;
        _console = console;
    }

    public void Run()
    {
        do
        {
            string input = _console.Ask(">");

            if (IsQuit(input))
            {
                break;
            }

            try
            {
                CommandBase command = _commandFactory.CreateCommand(input);

                if (command == null)
                {
                    _console.Say($"Command({input}) not found.\n");
                    continue;
                }

                command.Execute();
            }
            catch (InvalidUserException ex)
            {
                _console.Exception(ex);
            }
            catch (AuthorizationException ex)
            {
                _console.Exception(ex);
            }

        } while (true);
    }

    public bool IsQuit(string input)
    {
        return input.Equals("Q", StringComparison.InvariantCultureIgnoreCase);
    }
}
