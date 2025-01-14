using System.Security.Cryptography;
using System.Text;

namespace Samples.Security.DataAccess.Extensions;

internal static class SignatureUtils
{
    public static bool IsValid(string data, string signature, string privateKeyFilePath)
    {
        var sha = SHA256.Create();
        byte[] hashedData = sha.ComputeHash(Encoding.UTF8.GetBytes(data));
        byte[] signatureBytes = Convert.FromBase64String(signature);

        var rsa = RSA.Create();

        rsa.FromXmlString(File.ReadAllText(privateKeyFilePath));
        return rsa.VerifyHash(hashedData, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }

    public static string GenerateSignature(string data, string publicKeyFilePath)
    {
        var sha = SHA256.Create();
        byte[] hashedData = sha.ComputeHash(Encoding.UTF8.GetBytes(data));

        var rsa = RSA.Create();
        string publicKey = rsa.ToXmlString(false);
        File.WriteAllText(publicKeyFilePath, publicKey);

        return Convert.ToBase64String(rsa.SignHash(hashedData, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
    }
}
