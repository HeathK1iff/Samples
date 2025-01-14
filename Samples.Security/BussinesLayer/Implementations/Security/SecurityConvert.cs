using System.Security.Cryptography;
using System.Text;
using Samples.Security.BussinesLayer.Interfaces.Security;

namespace Samples.Security.BussinesLayer.Implementations.Security;

internal class SecurityConvert : ISecurityConvert
{
    private const string _pass = "!DeMo";
    private const string _salt = "!saMp1eSec";

    public SecurityConvert()
    {
    }

    public string Encrypt(string text)
    {
        byte[] encryptBytes;
        var aes = Aes.Create();

        var pbkdf2 = new Rfc2898DeriveBytes(_pass, Encoding.Unicode.GetBytes(_salt), 1000);
        aes.IV = pbkdf2.GetBytes(16);
        aes.Key = pbkdf2.GetBytes(32);

        using (var memory = new MemoryStream())
        {
            using (var cs = new CryptoStream(memory, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                byte[] data = Encoding.UTF8.GetBytes(text);

                cs.Write(data, 0, data.Length);
            }
            encryptBytes = memory.ToArray();
        }
        return Convert.ToBase64String(encryptBytes);
    }

    public string Decrypt(string base64)
    {
        byte[] plainBytes;
        byte[] base64Bytes = Convert.FromBase64String(base64);

        var aes = Aes.Create();
        var pbkdf2 = new Rfc2898DeriveBytes(_pass, Encoding.Unicode.GetBytes(_salt), 1000);
        aes.IV = pbkdf2.GetBytes(16);
        aes.Key = pbkdf2.GetBytes(32);

        using (var memory = new MemoryStream())
        {
            using (var cs = new CryptoStream(memory, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(base64Bytes, 0, base64Bytes.Length);
                cs.Flush();
            }
            plainBytes = memory.ToArray();
        }
        return Encoding.UTF8.GetString(plainBytes);
    }
}
