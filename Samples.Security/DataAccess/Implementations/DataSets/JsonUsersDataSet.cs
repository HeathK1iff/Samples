using Samples.Security.DataAccess.Entity;
using Samples.Security.DataAccess.Extensions;
using Samples.Security.DataAccess.Interfaces.DataSets;
using System.Text.Json;

namespace Samples.Security.DataAccess.Implementations.DataSets;

internal class JsonUsersDataSet : IDataSet<User>
{
    private readonly string _path;

    public JsonUsersDataSet(string path)
    {
        _path = path;
    }

    public User[] Load()
    {
        if (!File.Exists(_path))
        {
            return Array.Empty<User>();
        }


        using (var stream = new FileStream(_path, FileMode.Open, FileAccess.Read))
        {
            var signatureData = JsonSerializer.Deserialize<SignatureData<User[]>>(stream);

            string data = JsonSerializer.Serialize(signatureData.Data);

            if (!SignatureUtils.IsValid(data, signatureData.Signature, Path.ChangeExtension(_path, ".key")))
            {
                throw new Exception("Data Corrupted");
            }

            return signatureData.Data;
        }
    }

    public void Save(User[] users)
    {
        using (var stream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            using (var writer = new StreamWriter(stream, System.Text.Encoding.UTF8, leaveOpen: true))
            {
                var data = JsonSerializer.Serialize(users);

                writer.Write(JsonSerializer.Serialize(new SignatureData<User[]>()
                {
                    Data = users,
                    Signature = SignatureUtils.GenerateSignature(data, Path.ChangeExtension(_path, ".key"))
                }));
                writer.Flush();
            }
        }
    }

    public class SignatureData<T> where T : class
    {
        public T Data { get; set; }
        public string Signature { get; set; }
    }

}


