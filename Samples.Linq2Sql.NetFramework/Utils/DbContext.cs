using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Samples.Linq2Sql.NetFramework
{
    public class DbContext : DataContext
    {
        public Table<User> Users { get { return this.GetTable<User>(); } }

        public DbContext(string fileOrServerOrConnection) : base(fileOrServerOrConnection)
        {
        }

        public DbContext(IDbConnection connection) : base(connection)
        {
        }

        public DbContext(string fileOrServerOrConnection, MappingSource mapping) : base(fileOrServerOrConnection, mapping)
        {
        }

        public DbContext(IDbConnection connection, MappingSource mapping) : base(connection, mapping)
        {
        }
    }
}