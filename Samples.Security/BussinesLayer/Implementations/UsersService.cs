using Samples.Security.BussinesLayer.Entities;
using Samples.Security.BussinesLayer.Extensions;
using Samples.Security.BussinesLayer.Interfaces.Security;
using Samples.Security.DataAccess.Entity;
using Samples.Security.DataAccess.Interfaces;

namespace Samples.Security.BussinesLayer.Implementations;

internal class UsersService : IUsersService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ISecurityConvert _securityConvert;

    public UsersService(IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ISecurityConvert securityConvert)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _securityConvert = securityConvert;
    }


    public void CreateUser(UserDto user)
    {
        if (user == null)
            throw new ArgumentNullException("user");

        User userEntity = user.ToEntity();

        userEntity.Id = Guid.NewGuid();

        userEntity.FirstName = _securityConvert.Encrypt(user.FirstName);
        userEntity.LastName = _securityConvert.Encrypt(user.LastName);
        userEntity.Email = _securityConvert.Encrypt(user.Email);

        userEntity.Password = _passwordHasher.MakeHash(user.Password);

        _userRepository.Create(userEntity);
    }


    public UserDto[] GetAll()
    {
        return _userRepository
            .GetAll()
            .Select(entity => new UserDto()
            {
                Id = entity.Id,
                FirstName = _securityConvert.Decrypt(entity.FirstName),
                LastName = _securityConvert.Decrypt(entity.LastName),
                Email = _securityConvert.Decrypt(entity.Email),
                Password = entity.Password,
                LoginName = entity.LoginName,
                Role = entity.Role
            }).ToArray();
    }
}
