namespace Samples.Security.Application.Implementations;

internal class AppConsole : IConsole
{
    public string Ask(string promt)
    {
        Say(promt);
        return Console.ReadLine();
    }

    public ConsoleKey ReadKey(string promt)
    {
        Say(promt);
        return Console.ReadKey().Key;
    }

    public void Say(string promt, params object[] objects)
    {
        Console.Write(promt, objects);
    }

    public void Say(string promt)
    {
        Say(promt, null);
    }
}
