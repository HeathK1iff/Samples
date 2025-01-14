using System.Collections.Generic;

namespace Samples.Linq2Sql.NetFramework.Implementations
{
    public abstract class CommandBase
    {
        protected readonly KeyValuePair<string, string>[] _args;
        protected readonly DbContext _context;

        protected CommandBase(DbContext context, KeyValuePair<string, string>[] args)
        {
            _context = context;
            _args = args;
        }

        public void Execute()
        {
            if (CanExecute())
            {
                DoExecute(_context, _args);
            }
        }

        protected abstract void DoExecute(DbContext context, KeyValuePair<string, string>[] args);

        protected virtual bool CanExecute()
        {
            return true;
        }

    }

}
