using Sample.Enums.Implementations;
using Sample.Enums.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var program = new Program();
        program.Run();
    }

    public void Run()
    {
        UsersService service = CreateService();
        User[] users = service.GetByAccess(UserAccess.Manager);

        Console.WriteLine(string.Join(',', users.Select(f => f.Login).ToArray()));

        UserAccess groups = UserAccess.Cooker | UserAccess.Manager;
        Console.WriteLine($"Enums: {groups};");


        if (groups.HasFlag(UserAccess.Cooker))
        {
            Console.WriteLine("Has Cooker access");
        }

        if (groups.HasFlag(UserAccess.Cooker | UserAccess.Manager))
        {
            Console.WriteLine("Cooker and Manager access");
        }

        if (groups.HasFlag(UserAccess.Cooker | UserAccess.Manager | UserAccess.Administrator))
        {
            Console.WriteLine("1: Cooker and Manager and Admin access");
        }

        groups |= UserAccess.Administrator;


        if (groups.HasFlag(UserAccess.Cooker | UserAccess.Manager | UserAccess.Administrator))
        {
            Console.WriteLine("2: Cooker and Manager and Admin access");
        }

        groups ^= UserAccess.Administrator;

        if (groups.HasFlag(UserAccess.Cooker | UserAccess.Manager))
        {
            Console.WriteLine("3: Exclude Admin access");
        }


        var jsonText = System.Text.Json.JsonSerializer.Serialize(users);
        Console.WriteLine(jsonText);

    }

    private UsersService CreateService()
    {
        var service = new UsersService(new UserRepository());

        service.Add(new User()
        {
            Login = "Jack",
            Access = UserAccess.Administrator
        });

        service.Add(new User()
        {
            Login = "Forest",
            Access = UserAccess.Manager
        });

        service.Add(new User()
        {
            Login = "Jimmi",
            Access = UserAccess.Cooker | UserAccess.Manager
        });

        return service;
    }

}


