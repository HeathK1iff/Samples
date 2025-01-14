using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Samples.Linq2Sql.NetFramework.Implementations.Commands
{
    internal class ArgumentExtractorUtils
    {
        public static DateTime GetDateValue(KeyValuePair<string, string>[] args, string argName)
        {
            string value = args.FirstOrDefault(f => f.Key.Equals(argName, StringComparison.InvariantCultureIgnoreCase)).Value;
            return DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public static string GetStringValue(KeyValuePair<string, string>[] args, string argName)
        {
            return args.FirstOrDefault(f => f.Key.Equals(argName, StringComparison.InvariantCultureIgnoreCase)).Value;
        }
    }
}
