public interface IConsole
{
    string Ask(string promt);
    void Say(string promt, params Object[] objects);
    void Say(string promt);
    ConsoleKey ReadKey(string promt);
}