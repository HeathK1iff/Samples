using Microsoft.Extensions.DependencyInjection;
using Samples.Security.Application.Abstractions;
using Samples.Security.Application.Interfaces;
using System.Reflection;

namespace Samples.Security.Application.Implementations;

internal class CommandFactory : ICommandFactory, IDisposable
{
    private readonly IServiceScope _serviceScope;
    private bool disposedValue;

    public CommandFactory(IServiceCollection descriptors)
    {
        ScanAndFillServices(descriptors);
        _serviceScope = descriptors.BuildServiceProvider().CreateScope();
    }

    private void ScanAndFillServices(IServiceCollection descriptors)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        foreach (Type type in GetTypesByInterface(assembly))
        {
            var commandAttr = type.GetCustomAttribute<CommandAttribute>();

            if (commandAttr == null) continue;

            descriptors.AddKeyedTransient(typeof(CommandBase), commandAttr.GetName(), type);
        }
    }

    private IEnumerable<Type> GetTypesByInterface(Assembly assembly)
    {
        return assembly.
            GetTypes().
            Where(f => f.IsAssignableTo(typeof(CommandBase)));
    }
    public CommandBase CreateCommand(string command)
    {
        return _serviceScope.ServiceProvider.GetKeyedService<CommandBase>(command.Trim().ToLower());
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _serviceScope.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
