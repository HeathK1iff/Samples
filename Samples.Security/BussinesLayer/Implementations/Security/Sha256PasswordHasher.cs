using Samples.Security.BussinesLayer.Interfaces.Security;
using System.Security.Cryptography;
using System.Text;

namespace Samples.Security.BussinesLayer.Implementations.Security;

internal class Sha256PasswordHasher : IPasswordHasher
{
    public string MakeHash(string password)
    {
        byte[] bytesPassword = Encoding.Unicode.GetBytes(password);
        byte[] hashedPassword = SHA256.HashData(bytesPassword);

        return Convert.ToBase64String(hashedPassword);
    }

    public bool Verify(string password, string hashedPassword)
    {
        if (password == null || hashedPassword == null)
        {
            return false;
        }

        string newHashed = MakeHash(password);

        return newHashed.Equals(hashedPassword);
    }
}
