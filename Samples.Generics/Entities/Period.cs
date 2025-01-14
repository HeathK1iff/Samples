namespace Samples.Generics.Entities;

public class Period
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public override string ToString()
    {
        return $"{From.ToShortDateString()}:{To.ToShortDateString()}";
    }
}
