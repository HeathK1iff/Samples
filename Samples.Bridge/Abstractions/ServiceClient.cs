using Samples.Bridge.Interfaces;

namespace Samples.Bridge.Abstractions
{
    //Abstraction
    public abstract class ServiceClient
    {
        protected Serializator _serializator;
        protected IClient _client;

        protected ServiceClient(Serializator serializator, IClient client)
        {
            _serializator = serializator;
            _client = client;
        }

        public void SetSerializator(Serializator serializator)
        {
            if (_serializator  == null)
            {
                throw new ArgumentNullException(nameof(serializator));
            }
            
            _serializator = serializator;
        }

        public abstract ServiceResponse Send(ServiceRequest request);
    }
}