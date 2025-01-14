using Samples.Security.BussinesLayer.Entities;
using Samples.Security.DataAccess.Entity;

namespace Samples.Security.BussinesLayer.Interfaces;

internal interface IAccountService
{
    UserDto Login(string userName, string password);

    bool IsAutorized(UserRole[] roles);
}
