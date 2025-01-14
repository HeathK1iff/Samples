using Samples.Serialiazation.NetFramework.Services;
using Samples.Serialization.Entity;
using System;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace Samples.Serialiazation.NetFramework
{
    internal class Program
    {
        private readonly IEmployeeBase64ConvertService _service;

        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            var program = new Program();
            program.Perform();
            program.SetSoapFormatter();
            program.Perform();

            Console.ReadKey();
        }

        public Program() {
            _service = new EmployeeBase64ConvertService(new BinaryFormatter());
        }

        public void SetSoapFormatter()
        {
            _service.SetFormatter(new SoapFormatter());
        }

        public void Perform()
        {  
            Employee employee = CreateEmployee();
            string textData = _service.ToString(employee);

            Console.WriteLine("Serialized data (base64):");
            Console.WriteLine("==============================");
            Console.WriteLine(textData);
            Console.WriteLine("==============================");
            var newEmployee = _service.FromString(textData);
            Console.WriteLine("Deserialized object (base64):");
            Console.WriteLine(newEmployee);
            Console.WriteLine("==============================");
        }

        private Employee CreateEmployee()
        {
            return new Employee()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Wick",
                EmployeeAddress = new Address()
                {
                    Street = "Test",
                    BuildNo = 1
                } 
            };
        }

        
    }
}
