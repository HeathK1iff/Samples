using System.Collections.Generic;

namespace Samples.Linq2Sql.NetFramework.Implementations
{
    public interface ICommandParcer
    {
        void Parce(string input, out string command, out KeyValuePair<string, string>[] args);
    }
}