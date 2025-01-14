namespace Samples.Comparers.Entities;

internal class Person : IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public int CompareTo(Person other)
    {
        if (other == null) return 1;

        int compare = Name.CompareTo(other.Name);

        if (compare == 0)
        {
            compare = Age.CompareTo(other.Age);
        }

        return compare;
    }

    public override string ToString()
    {
        return $"{Name}, {Age}";
    }
}