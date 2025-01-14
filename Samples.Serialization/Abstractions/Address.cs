using System.Text.Json.Serialization;
using System.Xml.Serialization;

public class Address
{
    [XmlAttribute(AttributeName = "city")]
    public string City { get; set; }
    [XmlAttribute(AttributeName = "region")]
    public string Region { get; set; }
    [XmlAttribute(AttributeName = "addressType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AddressType AddressType {  get; set; }   

    public override string ToString()
    {
        return  $"#{City},{Region},{AddressType}#";
    }
}

public enum AddressType
{
    Domestic,
    Foreigh
}