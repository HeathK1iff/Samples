using Samples.Serialization.Entity;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace Samples.Serialiazation.NetFramework.Services
{
    public class EmployeeBase64ConvertService : IEmployeeBase64ConvertService
    {
        private readonly IFormatter _defaultFormatter;
        private IFormatter _formatter;

        public EmployeeBase64ConvertService(IFormatter defaultFormatter)
        {
            _defaultFormatter = defaultFormatter;
        }

        public void SetFormatter(IFormatter formatter)
        {
            _formatter = formatter;
        }

        public string ToString(Employee employee)
        {
            var formatter = GetFormatterOrDefault();

            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, employee);
                stream.Seek(0, SeekOrigin.Begin);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public Employee FromString(string employeeData)
        {
            var formatter = GetFormatterOrDefault();

            using (var stream = new MemoryStream())
            {
                var data = Convert.FromBase64String(employeeData);
                stream.Write(data, 0, data.Length);
                stream.Seek(0, SeekOrigin.Begin);

                return (Employee)formatter.Deserialize(stream);
            }
        }

        private IFormatter GetFormatterOrDefault()
        {
            return _formatter != null ? _formatter : _defaultFormatter;
        }
    }

}
