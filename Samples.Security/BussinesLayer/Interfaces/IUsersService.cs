using Samples.Security.BussinesLayer.Entities;

namespace Samples.Security.BussinesLayer.Implementations
{
    internal interface IUsersService
    {
        void CreateUser(UserDto user);
        UserDto[] GetAll();
    }
}