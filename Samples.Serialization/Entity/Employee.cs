using System.Xml.Serialization;

public class Employee
{
    [XmlAttribute("id")]
    public int Id { get; set; }
    [XmlElement("first-name")]
    public string FirstName { get; set; }
    [XmlElement("last-name")]
    public string LastName { get; set; }
    [XmlElement("address")]
    public Address Address { get; set; }
    [XmlAttribute("AccountType")]
    public AccountType Account { get; set; }

    public override string ToString()
    {
        return $"#{Id},{FirstName},{LastName},{Account},{Address}#";
    }
}

public enum AccountType: byte 
{ 
    Admin, 
    User 
}
