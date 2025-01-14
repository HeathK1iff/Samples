[Flags]
public enum UserAccess: byte
{
    Cooker = 0b_0000_0001,
    Manager = 0b_0000_0010,
    Administrator = 0b_0000_0100
}