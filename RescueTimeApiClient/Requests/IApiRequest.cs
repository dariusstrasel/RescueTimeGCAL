using System.Net.Http;

namespace RescueTimeWebApiClient.Requests
{
    public interface IApiRequest<T> : IApiRequest { }
    
    public interface IApiRequest
    {
        string EndPointUri { get; }
        bool HasPayload { get; }
        bool HasQueryParameters { get; }
        HttpMethod Method { get; }
        object Payload { get; }
    }
}