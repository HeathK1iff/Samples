using Samples.Generics.Abstractions;
using Samples.Generics.Extensions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.HashSet.Commands;

internal class HashSetAddCommand : GenericCommandBase<HashSet<int>>
{
    public HashSetAddCommand(HashSet<int> hashSet, IConsole console) : base(hashSet, console)
    {
    }

    protected override void DoExecute(IConsole console, HashSet<int> hashSet)
    {
        console.WriteLine("Method: void Add(Number)");
        int[] array = console.AskNumberSet();

        foreach (int val in array)
        {
            hashSet.Add(val);
        }
    }
}
