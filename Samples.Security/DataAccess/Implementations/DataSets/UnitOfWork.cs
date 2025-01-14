using Microsoft.Extensions.Options;
using Samples.Security.Application.Implementations.Options;
using Samples.Security.BussinesLayer.Interfaces.Security;
using Samples.Security.DataAccess.Entity;
using Samples.Security.DataAccess.Interfaces.DataSets;

namespace Samples.Security.DataAccess.Implementations.DataSets;

internal class UnitOfWork : IUnitOfWork
{
    private readonly IOptions<DataSetOptions> _options;
    private IDataSet<User> _users;

    public IDataSet<User> Users
    {
        get
        {
            if (_users == null)
            {
                _users = new JsonUsersDataSet(_options.Value.UsersFilePath);
            }

            return _users;

        }
    }

    public UnitOfWork(IOptions<DataSetOptions> options)
    {
        _options = options;
    }
}
