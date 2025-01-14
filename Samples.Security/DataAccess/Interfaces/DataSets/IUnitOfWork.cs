using Samples.Security.DataAccess.Entity;

namespace Samples.Security.DataAccess.Interfaces.DataSets;

internal interface IUnitOfWork
{
    public IDataSet<User> Users { get; }
}
