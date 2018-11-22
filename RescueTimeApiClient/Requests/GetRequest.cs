using System.Net.Http;

namespace RescueTimeWebApiClient.Requests
{
    public abstract class GetRequest : IApiRequest
    {
        public string EndpointUri { get; }
        public bool HasPayload => false;
        public HttpMethod Method => HttpMethod.Get;
        public object Payload => default(object);
    }
}