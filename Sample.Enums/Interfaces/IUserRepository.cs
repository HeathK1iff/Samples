namespace Sample.Enums.Repositories;

internal interface IUserRepository
{
    void Add(User user);
    void Update(User user);
    void Delete(User user);
    User[] GetByAccess(UserAccess access);
}
