using Samples.Security.BussinesLayer.Entities;
using Samples.Security.BussinesLayer.Extensions;
using Samples.Security.BussinesLayer.Interfaces;
using Samples.Security.BussinesLayer.Interfaces.Security;
using Samples.Security.DataAccess.Entity;
using Samples.Security.DataAccess.Interfaces;

namespace Samples.Security.BussinesLayer.Implementations;

internal class AccountService : IAccountService
{
    private const string DemoUser = "demo";
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public AccountService(IUserRepository userRepository, 
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public bool IsAutorized(UserRole[] roles)
    {
        if (Thread.CurrentPrincipal == null)
        {
            return false;
        }

        foreach (UserRole userRole in roles)
        {
            if (Thread.CurrentPrincipal.IsInRole(userRole.ToString()))
            {
                return true;
            }
        }

        return false;
    }

    public UserDto Login(string userName, string password)
    {
        if (IsPredefined(userName, password))
            return new UserDto()
            {
                LoginName = userName,
                Role = UserRole.Administrator
            };

        User user = _userRepository.GetByUserName(userName);

        if (user != null && CheckPassword(user, password))
        {
            return user.ToDto();
        }

        return null;
    }

    private bool CheckPassword(User user, string password)
    {
        return _passwordHasher.Verify(password, user.Password);
    }

    private bool IsPredefined(string username, string password)
    {
        return !_userRepository.GetAll().Any() &&
            DemoUser.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
            _passwordHasher.Verify(password, _passwordHasher.MakeHash(DemoUser));
    }
}
