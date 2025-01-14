
int value = int.MaxValue;
Console.WriteLine(value);
checked
{
    value++;
}
Console.WriteLine(value);