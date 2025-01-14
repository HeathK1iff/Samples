using Samples.Generics.Entities;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Extensions;

public static class ConsoleExtensions
{
    public static Person AskPerson(this IConsole console, string promt)
    {
        console.WriteLine(promt);

        return new()
        {
            FirstName = console.Ask("First Name :"),
            LastName = console.Ask("Last Name  :")
        };
    }

    public static int[] AskNumberSet(this IConsole console)
    {
        string input = console.Ask("Set :");
        string[] tokens = input.Split(',');

        var result = new List<int>();

        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int val))
            {
                result.Add(val);
            }            
        }

        return result.ToArray();
    }

    public static int AskNumberOrDefault(this IConsole console, string promt)
    {
        int result = int.TryParse(console.Ask(promt), out result) ? result : default;
        return result;
    }

    public static void WriteException(this IConsole console, Exception exception)
    {
        console.WriteLine($"Fail: {exception.GetType().Name} => {exception.Message}");
    }

}
