using Samples.Generics.Interfaces;

namespace Samples.Generics.Utils;

public class InputOutputConsole : IConsole
{
    public string Ask(string promt)
    {
        Write(promt);
        return ReadLine();
    }

    public ConsoleKey AskKey(string promt)
    {
        Write(promt);
        ConsoleKey key = ReadKey();
        Write(Environment.NewLine);
        return key;
    }

    public ConsoleKey ReadKey()
    {
        return Console.ReadKey(false).Key;
    }

    public string ReadLine()
    {
        return Console.ReadLine();
    }

    public void Write(string line)
    {
        Console.Write(line);
    }

    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }

    public void ClearScreen()
    {
        Console.Clear();
    }
}
