using Sample.Enums.Repositories;

namespace Sample.Enums.Implementations;

internal class UserRepository : IUserRepository
{
    private List<User> _users = new ();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public void Delete(User user)
    {
        _users.Remove(user);
    }

    public User[] GetAll()
    {
        return _users.ToArray();
    }

    public User[] GetByAccess(UserAccess access)
    {
        return _users
          .Where(f => f.Access.HasFlag(access))
          .ToArray();
    }

    public void Update(User user)
    {
        ;
    }
}
