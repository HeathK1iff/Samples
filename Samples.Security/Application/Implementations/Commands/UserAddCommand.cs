using Samples.Security.Application.Abstractions;
using Samples.Security.BussinesLayer.Entities;
using Samples.Security.BussinesLayer.Implementations;
using Samples.Security.BussinesLayer.Interfaces;
using Samples.Security.DataAccess.Entity;

namespace Samples.Security.Application.Implementations.Commands;

[Command("add-user")]
internal class UserAddCommand : CommandBase
{
    private readonly IUsersService _usersService;
    public UserAddCommand(IAccountService accountService,
        IUsersService usersService,
        IConsole console) : base(accountService, console)
    {
        _usersService = usersService;
    }

    protected override void DoExecute(IConsole console)
    {
        var user = new UserDto()
        {
            LoginName = console.Ask("Login: "),
            FirstName = console.Ask("First Name: "),
            LastName = console.Ask("Last Name: "),
            Email = console.Ask("Email: "),
            Password = console.Ask("Password: "),
            Role = GetRole(console, "Role: "),
        };

        _usersService.CreateUser(user);
    }

    protected override UserRole[] GetAcceptedUserRole()
    {
        return new UserRole[] { UserRole.Administrator };
    }

    private UserRole GetRole(IConsole console, string promt)
    {
        return Enum.TryParse(console.Ask(promt), out UserRole role) ? role : UserRole.User;
    }
}
