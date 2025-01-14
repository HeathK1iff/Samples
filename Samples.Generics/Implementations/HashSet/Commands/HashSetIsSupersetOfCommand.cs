using Samples.Generics.Abstractions;
using Samples.Generics.Extensions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.HashSet.Commands;

internal class HashSetIsSupersetOfCommand : GenericCommandBase<HashSet<int>>
{
    public HashSetIsSupersetOfCommand(HashSet<int> hashSet, IConsole console) : base(hashSet, console)
    {
    }

    protected override void DoExecute(IConsole console, HashSet<int> hashSet)
    {
        console.WriteLine("Method: bool IsSupersetOf(int[])");

        bool isSuperSet = hashSet.IsSupersetOf(console.AskNumberSet());

        console.WriteLine($"Result: {isSuperSet}");
    }
}
