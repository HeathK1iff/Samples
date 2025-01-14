namespace Samples.Security.BussinesLayer.Interfaces.Security
{
    internal interface ISecurityConvert
    {
        string Decrypt(string base64);
        string Encrypt(string text);
    }
}