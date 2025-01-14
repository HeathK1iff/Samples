using Samples.Security.BussinesLayer.Entities;
using Samples.Security.DataAccess.Entity;

namespace Samples.Security.BussinesLayer.Extensions;

internal static class UserExtensions
{
    public static UserDto ToDto(this User item)
    {
        return new UserDto()
        {
            Id = item.Id,
            FirstName = item.FirstName,
            LastName = item.LastName,
            LoginName = item.LoginName,
            Email = item.Email,
            Password = item.Password,
            Role = item.Role
        };
    }
}
