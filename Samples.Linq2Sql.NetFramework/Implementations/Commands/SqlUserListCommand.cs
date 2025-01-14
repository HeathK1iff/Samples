using ConsoleTables;
using System.Collections.Generic;

namespace Samples.Linq2Sql.NetFramework.Implementations
{
    public class SqlUserListCommand : CommandBase
    {
        public SqlUserListCommand(DbContext context, KeyValuePair<string, string>[] args) : base(context, args)
        {
        }

        protected override void DoExecute(DbContext context, KeyValuePair<string, string>[] args)
        {
            var table = new ConsoleTable("Id", "First Name", "Last Name", "Birthdate");

            foreach (var user in _context.Users)
            {
                table.AddRow(user.Id, user.FirstName, user.LastName, user.BirthDate);
            }

            table.Write();
        }
    }

}
