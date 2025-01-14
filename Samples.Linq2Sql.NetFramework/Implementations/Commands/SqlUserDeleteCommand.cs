using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.Linq2Sql.NetFramework.Implementations.Commands
{
    internal class SqlUserDeleteCommand : CommandBase
    {
        private static string Id = "id";

        private readonly HashSet<string> mandatoryArgs = new HashSet<string>()
        {
            Id
        };

        public SqlUserDeleteCommand(DbContext context, KeyValuePair<string, string>[] args) : base(context, args)
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

            context.Users.DeleteOnSubmit(item);

            context.SubmitChanges();
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
