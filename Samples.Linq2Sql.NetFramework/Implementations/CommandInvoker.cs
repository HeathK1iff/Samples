using Samples.Linq2Sql.NetFramework.Implementations.Commands;
using System;
using System.Linq;

namespace Samples.Linq2Sql.NetFramework.Implementations
{
    internal class CommandInvoker
    {
        private const string Quit = "Q";
        private ICommandParcer _commandParcer;
        private DbContext _context;
        private (string Command, Type CommandType)[] _commands = new[]
        {
            ("list", typeof(SqlUserListCommand)),
            ("insert", typeof(SqlUserInsertCommand)),
            ("delete", typeof(SqlUserDeleteCommand)),
            ("update", typeof(SqlUserUpdateCommand))
        };


        public CommandInvoker(DbContext context, ICommandParcer commandParcer)
        {
            _context = context;
            _commandParcer = commandParcer;
        }

        public void Run()
        {
            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine();

                if (Quit.Equals(input, StringComparison.InvariantCultureIgnoreCase)) 
                {
                    break;
                }


                _commandParcer.Parce(input, out string command, out var args);

                var commandType = _commands.FirstOrDefault(c => c.Command.Equals(command, StringComparison.InvariantCultureIgnoreCase));

                if (commandType != default)
                {
                    CommandBase createdCommand = Activator.CreateInstance(commandType.CommandType, _context, args) as CommandBase;
                    createdCommand.Execute();
                }
            }
        }
    }

}
