using System.Net.Http;

namespace RescueTimeWebApiClient.Requests
{
    public interface IApiRequest
    {
        string EndpointUri { get; }
        bool HasPayload { get; }
        HttpMethod Method { get; }
        object Payload { get; }
    }
}