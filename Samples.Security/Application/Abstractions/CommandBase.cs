using Samples.Security.Application.Exceptions;
using Samples.Security.BussinesLayer.Interfaces;
using Samples.Security.DataAccess.Entity;

namespace Samples.Security.Application.Abstractions;

internal abstract class CommandBase
{
    private readonly IAccountService _accountService;
    private readonly IConsole _console;

    protected CommandBase(IAccountService accountService, IConsole console)
    {
        _console = console;
        _accountService = accountService;
    }

    public void Execute()
    {
        if (CanExecute())
        {
            DoExecute(_console);
        }
    }

    protected virtual UserRole[] GetAcceptedUserRole()
    {
        return new UserRole[] { UserRole.User };
    }

    protected virtual bool CanExecute()
    {
        if (!_accountService.IsAutorized(GetAcceptedUserRole()))
        {
            throw new AuthorizationException();
        }

        return true;
    }

    protected abstract void DoExecute(IConsole console);
}
