using Samples.Serialization.Entity;
using System.Runtime.Serialization;

namespace Samples.Serialiazation.NetFramework.Services
{
    public interface IEmployeeBase64ConvertService
    {
        void SetFormatter(IFormatter formatter);
        Employee FromString(string employeeData);
        string ToString(Employee employee);
    }
}