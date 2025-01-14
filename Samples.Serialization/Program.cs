using System.Text.Json;
using System.Xml.Serialization;

internal class Program
{
    private Employees Create()
    {
        return new Employees()
        {
            Items = new List<Employee>() {
                new Employee() {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "Test",
                    Address = new Address()
                    {
                        City = "Krasnodar",
                        Region = "UFO"
                    }
                }
            }
        };
    }

    public static void Main(string[] args)
    {
        var program = new Program();
        
        string xmlText = program.SerializeXmlToString(program.Create());
        Console.WriteLine(xmlText);
        Employees employees = program.DeserializeXmlFromString(xmlText);
        Console.WriteLine(employees);
        
        string jsonText = program.SerializeJsonToString(employees);
        Console.WriteLine(jsonText);
        Employees employees2 = program.DeserializeJsonFromString(jsonText);
        Console.WriteLine(employees2);
    }


    public string SerializeXmlToString(Employees employees)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employees));

        using var stream = new MemoryStream();
        xmlSerializer.Serialize(stream, employees);
        stream.Seek(0, SeekOrigin.Begin);
        using var reader = new StreamReader(stream);
        
        return reader.ReadToEnd();
    }


    public Employees DeserializeXmlFromString(string xmlText)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employees));
        return xmlSerializer.Deserialize(new StringReader(xmlText)) as Employees;
    }

    public string SerializeJsonToString(Employees employees)
    {
        return JsonSerializer.Serialize(employees);
    }

    public Employees DeserializeJsonFromString(string jsonText)
    {
        return JsonSerializer.Deserialize<Employees>(jsonText);
    }
}



