using Samples.Security.DataAccess.Entity;

namespace Samples.Security.DataAccess.Interfaces;

internal interface IUserRepository
{
    User GetByUserName(string userName);

    User[] GetAll();

    User Create(User user);

    void Update(User user);

    void Delete(Guid id);
}
