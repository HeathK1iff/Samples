using Samples.Generics.Abstractions;
using Samples.Generics.Implementations.Dictionary;
using Samples.Generics.Implementations.HashSet;
using Samples.Generics.Implementations.LinkedList;
using Samples.Generics.Implementations.Queue;
using Samples.Generics.Implementations.SortedDictionary;
using Samples.Generics.Implementations.SortedList;
using Samples.Generics.Implementations.Stack;
using Samples.Generics.Utils;

var console = new InputOutputConsole();

while (true)
{
    console.ClearScreen();
    console.WriteLine("Main menu:");
    console.WriteLine("1. Dictionary<string, Person>");
    console.WriteLine("2. HashSet<int>");
    console.WriteLine("3. SortedList<int, Person>");
    console.WriteLine("4. SortedDictionary<int, Person>");
    console.WriteLine("5. LinkedList<Person>");
    console.WriteLine("6. Stack<int>");
    console.WriteLine("7. Queue<int>");
    console.WriteLine("Q. Exit");
    ConsoleKey key = console.AskKey("Input: ");

    if (key == ConsoleKey.Q)
        break;

    SampleFactoryBase factory = key switch
    {
        ConsoleKey.D1 => new DictionarySampleFactory(),
        ConsoleKey.D2 => new HashSetSampleFactory(),
        ConsoleKey.D3 => new SortedListSampleFactory(),
        ConsoleKey.D4 => new SortedDictionarySampleFactory(),
        ConsoleKey.D5 => new LinkedListSampleFactory(),
        ConsoleKey.D6 => new StackSampleFactory(),
        ConsoleKey.D7 => new QueueSampleFactory(),
        _ => throw new InvalidOperationException()
    };

    while (true)
    {
        console.ClearScreen();
        console.WriteLine("Menu: ");
        foreach (var promt in factory.GetPromts())
        {
            console.WriteLine(promt.Description);
        }
        console.WriteLine("=> Press Q for return previous menu");

        ConsoleKey commandKey = console.AskKey("Command: ");

        if (commandKey == ConsoleKey.Q)
            break;

        console.ClearScreen();

        CommandBase command = factory.CreateCommand(commandKey, console);
        command.Execute();

        console.WriteLine("=============================================");
        console.WriteLine("Press any key to continue");
        console.ReadKey();
    }
}

console.ClearScreen();

