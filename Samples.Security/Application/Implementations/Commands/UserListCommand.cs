using Samples.Security.Application.Abstractions;
using Samples.Security.BussinesLayer.Implementations;
using Samples.Security.BussinesLayer.Interfaces;
using Samples.Security.DataAccess.Entity;

namespace Samples.Security.Application.Implementations.Commands
{
    [Command("user-list")]
    internal class UserListCommand : CommandBase
    {
        private readonly IUsersService _usersService;
        public UserListCommand(IAccountService accountService,
            IUsersService usersService,
            IConsole console) : base(accountService, console)
        {
            _usersService = usersService;
        }

        protected override void DoExecute(IConsole console)
        {
            foreach (var user in _usersService.GetAll())
            {
                console.Say($"{user.LoginName};{user.FirstName};{user.LastName};{user.Email}\n");
            }
        }

        protected override UserRole[] GetAcceptedUserRole()
        {
            return new UserRole[] { UserRole.Administrator };
        }
    }
}
