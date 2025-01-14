namespace Samples.Generics.Interfaces;

public interface IConsole
{
    string Ask(string promt);
    string ReadLine();
    void WriteLine(string line);
    void Write(string line);
    ConsoleKey ReadKey();
    void ClearScreen();
}
