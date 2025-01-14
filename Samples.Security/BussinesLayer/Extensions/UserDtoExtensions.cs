using Samples.Security.BussinesLayer.Entities;
using Samples.Security.DataAccess.Entity;

namespace Samples.Security.BussinesLayer.Extensions;

internal static class UserDtoExtensions
{
    public static User ToEntity(this UserDto item)
    {
        return new User()
        {
            Id = item.Id,
            FirstName = item.FirstName,
            LastName = item.LastName,
            Email = item.Email,
            LoginName = item.LoginName,
            Password = item.Password,
            Role = item.Role
        };
    }
}
