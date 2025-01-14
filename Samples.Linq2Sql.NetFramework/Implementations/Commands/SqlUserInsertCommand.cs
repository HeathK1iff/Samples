using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.Linq2Sql.NetFramework.Implementations.Commands
{
    internal class SqlUserInsertCommand : CommandBase
    {
        private static string FirstName = "firstname";
        private static string LastName = "lastname";
        private static string BirthDate = "birthdate";


        private readonly HashSet<string> mandatoryArgs = new HashSet<string>()
        {
            FirstName, LastName, BirthDate
        };

        public SqlUserInsertCommand(DbContext context, KeyValuePair<string, string>[] args) : base(context, args)
        {
        }

        protected override void DoExecute(DbContext context, KeyValuePair<string, string>[] args)
        {
            ThrowOfArgsIsMissing(args);

            context.Users.InsertOnSubmit(new User()
            {
                Id = NextId(context),
                FirstName = ArgumentExtractorUtils.GetStringValue(args, FirstName),
                LastName = ArgumentExtractorUtils.GetStringValue(args, LastName),
                BirthDate = ArgumentExtractorUtils.GetDateValue(args, BirthDate),
            });

            context.SubmitChanges();
        }


        private int NextId(DbContext context)
        {
            return context.GetTable<User>().Max(f => f.Id) + 1;
        }

        private void ThrowOfArgsIsMissing(KeyValuePair<string, string>[] args)
        {
            HashSet<string> currentKeys = new HashSet<string>(args.Select(f => f.Key));

            if (!mandatoryArgs.IsSubsetOf(currentKeys))
            {
                throw new FormatException("Incorrect list of arguments");
            }
        }
    }
}
