using System.Net.Http;

namespace RescueTimeWebApiClient.Requests
{
    public abstract class GetRequest<T> : IApiRequest<T>
    {
        public abstract string EndPointUri { get; }
        public bool HasPayload => false;
        public bool HasQueryParameters => true;
        public HttpMethod Method => HttpMethod.Get;
        public object Payload => default(object);
    }
}