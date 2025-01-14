using System;
using System.Text;

namespace Samples.Serialization.Entity
{
    [Serializable]
    public class Employee
    {
        [NonSerialized]
        private string _firstName;

        public int Id { get; set; }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName { get; set; }
        public Address EmployeeAddress { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Id={Id}");
            sb.Append($"&FirstName={FirstName}");
            sb.Append($"&LastName={LastName}");
            if (EmployeeAddress != null)
            {
                sb.Append("&" + EmployeeAddress.ToString());
            }
            return sb.ToString();
        }
    }
}
