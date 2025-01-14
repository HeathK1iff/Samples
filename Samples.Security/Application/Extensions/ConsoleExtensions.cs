namespace Samples.Security.Application.Extensions;

internal static class ConsoleExtensions
{
    public static void Status(this IConsole console, string message)
    {
        console.Say($"Status: {message}\n");
    }

    public static void Exception(this IConsole console, Exception exception)
    {
        console.Say($"Fail: {exception.Message}\n");
    }
}
