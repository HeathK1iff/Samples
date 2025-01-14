using Samples.Security.Application.Abstractions;
using Samples.Security.Application.Extensions;
using Samples.Security.BussinesLayer.Entities;
using Samples.Security.BussinesLayer.Interfaces;
using System.Security.Principal;

namespace Samples.Security.Application.Implementations.Commands;

[Command("Login")]
internal class LoginCommand : CommandBase
{
    private readonly IAccountService _accountService;
    public LoginCommand(IAccountService accountService, IConsole console) : base(accountService, console)
    {
        _accountService = accountService;
    }

    protected override bool CanExecute()
    {
        return true;
    }

    protected override void DoExecute(IConsole console)
    {
        string userName = console.Ask("User:");
        string password = console.Ask("Password:");

        UserDto user = _accountService.Login(userName, password);

        if (user == null)
        {
            console.Status("Access denied");
            return;
        }

        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(user.LoginName),
            new string[] { user.Role.ToString() });

        console.Status("Access granted");
    }
}
