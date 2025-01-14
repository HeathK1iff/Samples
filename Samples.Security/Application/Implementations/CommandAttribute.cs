namespace Samples.Security.Application.Implementations;

public class CommandAttribute : Attribute
{
    private string _name;
    public CommandAttribute(string name)
    {
        _name = name.Trim().ToLower();
    }

    public string GetName()
    {
        return _name;
    }
}