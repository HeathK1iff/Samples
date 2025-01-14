using Samples.Generics.Abstractions;
using Samples.Generics.Interfaces;

namespace Samples.Generics.Implementations.HashSet.Commands;

internal class HashSetPrintCommand : GenericCommandBase<HashSet<int>>
{
    public HashSetPrintCommand(HashSet<int> hashSet, IConsole console) : base(hashSet, console)
    {
    }

    protected override void DoExecute(IConsole console, HashSet<int> hashSet)
    {
        console.WriteLine(String.Join<int>(',', hashSet));
    }
}
