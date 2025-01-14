using System.Xml.Serialization;

[XmlRoot]
public class Employees
{
    [XmlArray]
    [XmlArrayItem(type: typeof(Employee))]
    public List<Employee> Items { get; set; }

    public override string ToString()
    {
        return $"[{ string.Join(',', Items.Select(item=>item.ToString())) }]";
    }
}
