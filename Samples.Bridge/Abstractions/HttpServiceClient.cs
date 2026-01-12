using Samples.Bridge.Implemetations;
using System.Net;
using System.Net.Http;

namespace Samples.Bridge.Abstractions;

public class HttpServiceClient : ServiceClientImpl
{
    Uri _host;
    HttpClient _httpClient;

    public HttpServiceClient(Uri host, HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _host = host ?? throw new ArgumentNullException(nameof(host));
    }

    public override async Task<Stream> SendAsync(ServiceRequestBase request)
    {
        var message = new HttpRequestMessage();
        message.Method = HttpMethod.Post;
        message.RequestUri = _host;

        var response = _httpClient.Send(message);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStreamAsync();
    }

    public override bool IsAvailableService()
    {
        return true;
    }
}

