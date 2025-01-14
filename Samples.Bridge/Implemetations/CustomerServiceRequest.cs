using Samples.Bridge.Abstractions;

namespace Samples.Bridge.Implemetations
{
    public class CustomerServiceRequest : ServiceRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}