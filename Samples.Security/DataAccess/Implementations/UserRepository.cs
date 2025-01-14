using Samples.Security.DataAccess.Entity;
using Samples.Security.DataAccess.Interfaces;
using Samples.Security.DataAccess.Interfaces.DataSets;

namespace Samples.Security.DataAccess.Implementations;

internal class UserRepository : IUserRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private List<User> _users;

    public UserRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public User Create(User user)
    {
        InternalGetAll().Add(user);

        Post();

        return user;
    }

    public void Delete(Guid id)
    {
        InternalGetAll().RemoveAll(u => u.Id.Equals(id));

        Post();
    }

    public User[] GetAll()
    {
        return InternalGetAll().ToArray();
    }

    private List<User> InternalGetAll()
    {
        if (_users == null)
        {
            _users = new List<User>(_unitOfWork.Users.Load());
        }

        return _users;
    }

    public User GetByUserName(string userName)
    {
        return GetAll().FirstOrDefault(f => f.LoginName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
    }

    public void Update(User user)
    {
        User foundUser = GetAll().FirstOrDefault(f => f.Id.Equals(user.Id));

        if (foundUser == null)
        {
            return;
        }

        foundUser.FirstName = user.FirstName;
        foundUser.LastName = user.LastName;
        foundUser.Role = user.Role;
        foundUser.Email = user.Email;

        Post();
    }

    private void Post()
    {
        if (!GetAll().Any())
        {
            return;
        }

        _unitOfWork.Users.Save(GetAll());
    }
}
