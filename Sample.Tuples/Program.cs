
internal class Program
{
    public static void Main(string[] args)
    {
        var program = new Program();
        program.Run();
    }

    public void Run()
    {

        ValueTuple<string, int> valueTuple = (Name: "Peter", Age: 12);
        (string Name, int Age) valueTuple1 = (Name: "Peter", Age: 12);

        if (valueTuple.Equals(valueTuple1))
        {
            Console.WriteLine(valueTuple1);
            Console.WriteLine("Value tuple are equal");
        }



        //Non named 
        Tuple<string, int> item = new Tuple<string, int>("test", 100);
        Console.WriteLine($"Item1={item.Item1}; Item2={item.Item2}");

        //Deconstruct
        (string name, int age) =  GetNameAndAge();
        Console.WriteLine($"Name {name}; Age {age}");

        //Auto named
        var person = new Person()
        {
            Name = "Gregory",
            Age = 80
        };
        var autoNameTuple = (person.Name, person.Age);
        Console.WriteLine($"Name={autoNameTuple.Name}; Age={autoNameTuple.Age}");

        //Named
        var namedTuple = (Name: "Forest", Age: 99);
        Console.WriteLine($"Name={namedTuple.Name}, Age={namedTuple.Age}");
    }

    internal (string, int) GetNameAndAge()
    {
        return ("John", 14);
    }

    private class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}








