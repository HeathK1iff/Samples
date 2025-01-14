using Sample.Enums.Repositories;

namespace Sample.Enums.Services;

internal class UsersService
{
    private readonly IUserRepository _userRepository;
    public UsersService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Add(User user)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        _userRepository.Add(user);
    }


    public User[] GetByAccess(UserAccess access)
    {
        return _userRepository.GetByAccess(access);
    }
}
