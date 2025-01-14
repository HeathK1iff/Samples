using Samples.Security.Application.Abstractions;

namespace Samples.Security.Application.Interfaces;

internal interface ICommandFactory
{
    CommandBase CreateCommand(string command);
}
