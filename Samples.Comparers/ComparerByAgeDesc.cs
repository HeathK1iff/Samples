using Samples.Comparers.Entities;

internal class ComparerByAgeDesc : IComparer<Person>
{
    private static IComparer<Person> _comparerByAgeDesc = new ComparerByAgeDesc();

    public int Compare(Person x, Person y)
    {
        if (x.Age > y.Age)
        {
            return -1;
        }

        if (x.Age < y.Age)
        {
            return 1;
        }

        return 0;
    }

    public static IComparer<Person> Default => _comparerByAgeDesc;
}