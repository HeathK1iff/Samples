using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Samples.Linq2Sql.NetFramework.Implementations
{
    public class CommandParcer : ICommandParcer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="command"></param>
        /// <param name="args"></param>
        /// <exception cref="FormatException"></exception>
        /// <returns>True if success otherwise false. If param have incorrect value can throw Format exception</returns>
        public void Parce(string input, out string command, out KeyValuePair<string, string>[] args)
        {
            command = string.Empty;
            args = Array.Empty<KeyValuePair<string, string>>();

            Match match = Regex.Match(input, @"^(\w+)(\s+(.+))?$");

            command = match.Groups[1].Value;

            ParceArgs(match.Groups[3].Value.Trim(), out args);
        }

        private void ParceArgs(string input, out KeyValuePair<string, string>[] args)
        {
            args = Array.Empty<KeyValuePair<string, string>>();


            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            var pairs = new List<KeyValuePair<string, string>>();
            foreach (var arg in input.Split(';'))
            {
                Match match = Regex.Match(arg.Trim(), @"^(\w+)(\s+)?=(\s+)?\""(.+)\""$");

                if (!match.Success)
                {
                    throw new FormatException($"Incorrect format of argument: {arg}. Correct is [Key]=[\"Value\"]; ... ");
                }

                var argPair = new KeyValuePair<string, string>(match.Groups[1].Value, match.Groups[4].Value);

                pairs.Add(argPair);
            }

            args = pairs.ToArray();
        }

    }

}
