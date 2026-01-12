namespace Samples.Bridge.Abstractions;

public abstract class ServiceClientImpl
{
    public abstract bool IsAvailableService();

    public abstract Task<Stream> SendAsync(ServiceRequestBase request);
}
