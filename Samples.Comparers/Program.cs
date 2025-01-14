using Samples.Comparers.Entities;

var list = new List<Person>(new[]
{
    new Person()
    {
        Name = "Jack",
        Age = 30
    },
    new Person()
    {
        Name = "Peter",
        Age = 32
    },
    new Person ()
    {
        Name = "Anna",
        Age = 54
    }
});

Console.WriteLine("Sort by IComparable by Name, Age");
list.Sort();

list.ForEach(x => Console.WriteLine(x));

Console.WriteLine("Sort by Comparison Action by Age");
list.Sort((a, b) =>
{
    return a.Age.CompareTo(b.Age);
});

list.ForEach(x => Console.WriteLine(x));

Console.WriteLine("Sort by Comparison Action by Name");
list.Sort(Comparer<Person>.Create((a, b) =>
{
    return a.Name.CompareTo(b.Name);
}));

list.ForEach(x => Console.WriteLine(x));

Console.WriteLine("Sort by Comparison Action by Age Descending");
list.Sort(ComparerByAgeDesc.Default);

list.ForEach(x => Console.WriteLine(x));


