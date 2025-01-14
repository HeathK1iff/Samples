namespace Samples.Security.BussinesLayer.Interfaces.Security;

internal interface IPasswordHasher
{
    string MakeHash(string password);
    bool Verify(string password, string hashedPassword);
}
