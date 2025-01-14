namespace Samples.Generics.Entities;

public sealed class Person : IEquatable<Person>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public override string ToString()
    {
        return $"{LastName} {FirstName}";
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Person);
    }

    public bool Equals(Person other)
    {
        return other is not null &&
               FirstName == other.FirstName &&
               LastName == other.LastName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName);
    }
}