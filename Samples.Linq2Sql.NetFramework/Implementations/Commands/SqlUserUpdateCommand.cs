using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.Linq2Sql.NetFramework.Implementations.Commands
{
    internal class SqlUserUpdateCommand : CommandBase
    {
        private static string Id = "id";
        private static string FirstName = "firstname";
        private static string LastName = "lastname";
        private static string BirthDate = "birthdate";


        private readonly HashSet<string> mandatoryArgs = new HashSet<string>()
        {
            Id
        };

        public SqlUserUpdateCommand(DbContext context, KeyValuePair<string, string>[] args) : base(context, args)
        {
        }

        protected override void DoExecute(DbContext context, KeyValuePair<string, string>[] args)
        {
            ThrowOfArgsIsMissing(args);
            
            int id = Convert.ToInt32(ArgumentExtractorUtils.GetStringValue(args, Id));

            User item = context.Users.FirstOrDefault(i => i.Id == id);

            if (item == default)
            {
                throw new KeyNotFoundException(nameof(item));
            }

            if (HasArg(args, FirstName))
            {
                item.FirstName = ArgumentExtractorUtils.GetStringValue(args, FirstName);
            }

            if (HasArg(args, LastName))
            {

                item.LastName = ArgumentExtractorUtils.GetStringValue(args, LastName);
            }

            if (HasArg(args, BirthDate))
            {
                item.BirthDate = ArgumentExtractorUtils.GetDateValue(args, BirthDate);
            }

            context.SubmitChanges();
        }

        private bool HasArg(KeyValuePair<string, string>[] args, string argName)
        {
            return Array.Exists(args, c => c.Key.Equals(argName, StringComparison.InvariantCultureIgnoreCase));
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
