
using Samples.Bridge.Dto;
using Samples.Bridge.Implemetations;
using System.Text;

namespace Samples.Bridge.Abstractions;

//Abstraction
public class ServiceClient
{
    protected ServiceClientImpl ServiceClientImpl;
    private Serializator _serializator;

    public ServiceClient(ServiceClientImpl serviceClientImp, Serializator serializator)
    {
        _serializator = serializator ?? throw new ArgumentNullException(nameof(serializator));
        ServiceClientImpl = serviceClientImp ?? throw new ArgumentNullException(nameof(serviceClientImp));
    }

    public async Task<bool> AuthenticateAsync(CheckCredentialRequest request)
    {
        if (!ServiceClientImpl.IsAvailableService())
        {
            throw new InvalidOperationException("Service is unavailabe");
        }

        var response =  await ServiceClientImpl.SendAsync(request);

        if (response == null)
        {
            throw new InvalidOperationException();
        }

        using (StreamReader streamReader = new StreamReader(response, Encoding.UTF8))
        {
             var res =  _serializator.Deserialize<ServiceResponseBase>(streamReader.ReadToEnd());
             return res.Success.Equals("success", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
