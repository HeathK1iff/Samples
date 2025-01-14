using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.Security.Application.Implementations;
using Samples.Security.Application.Implementations.Options;
using Samples.Security.Application.Interfaces;
using Samples.Security.BussinesLayer.Implementations;
using Samples.Security.BussinesLayer.Implementations.Security;
using Samples.Security.BussinesLayer.Interfaces;
using Samples.Security.BussinesLayer.Interfaces.Security;
using Samples.Security.DataAccess.Implementations;
using Samples.Security.DataAccess.Implementations.DataSets;
using Samples.Security.DataAccess.Interfaces;
using Samples.Security.DataAccess.Interfaces.DataSets;
using Serilog;

public class Program : IProgram
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConsole _console;

    public static void Main(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddIniFile("app.ini");

        IConfiguration configuration = configurationBuilder.Build();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.File("app.log")
            .CreateLogger();

        try
        {
            var serviceDescriptors = new ServiceCollection();

            serviceDescriptors.Configure<DataSetOptions>(options => configuration.GetSection(DataSetOptions.DataSet).Bind(options));
            serviceDescriptors.AddScoped<IProgram, Program>();
            serviceDescriptors.AddScoped<IConsole, AppConsole>();
            serviceDescriptors.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceDescriptors.AddScoped<ICommandFactory>(_ => new CommandFactory(serviceDescriptors));
            serviceDescriptors.AddScoped<ICommandInvoker, CommandInvoker>();
            serviceDescriptors.AddScoped<IPasswordHasher, Sha256PasswordHasher>(); 
            serviceDescriptors.AddScoped<IAccountService, AccountService>();
            serviceDescriptors.AddScoped<IUserRepository, UserRepository>();
            serviceDescriptors.AddScoped<ISecurityConvert, SecurityConvert>();
            serviceDescriptors.AddScoped<IUsersService, UsersService>();
            serviceDescriptors.AddScoped(_ => configuration);
            serviceDescriptors.AddSerilog();

            using (var provider = serviceDescriptors.BuildServiceProvider())
            {
                using (IServiceScope scope = provider.CreateScope())
                {
                    var program = scope.ServiceProvider.GetService<IProgram>();
                    program.Run();
                }
            }
        }
        catch (Exception ex)
        {
            Log.Logger.Error(ex, ex.Message);
            throw ex; 
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public Program(IServiceProvider serviceProvider, IConsole console)
    {

        _serviceProvider = serviceProvider;
        _console = console;
    }


    public void Run()
    {
        _console.Say("Application: Sample.Security \n");
        _console.Say("Press Q for exit \n");

        var invoker = _serviceProvider.GetService<ICommandInvoker>();
        invoker.Run();
    }
}
