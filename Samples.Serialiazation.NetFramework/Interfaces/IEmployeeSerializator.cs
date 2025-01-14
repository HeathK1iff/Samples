using Samples.Serialization.Entity;
using System.IO;

namespace Samples.Serialiazation.NetFramework.Services
{
    public interface IEmployeeSerializator
    {
        Employee Deserialize(Stream stream);
        void Serialize(Employee employee, out Stream stream);
    }
}