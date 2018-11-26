using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RescueTimeWebApiClient.Requests;

namespace RescueTimeWebApiClient
{
    public class ApiWebClient
    {
        private readonly HttpClient httpClient;

        public ApiWebClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<T> MakeRequest<T>(IApiRequest<T> apiRequest)
        {
            var response = await SendAsync(apiRequest);

            if (response.IsSuccessStatusCode)
            {
                var responseBodyAsString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseBodyAsString);
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Request to {apiRequest?.EndPointUri} returned failure status code of {response.StatusCode} with error content: \n\n{errorContent}");
        }

        private async Task<HttpResponseMessage> SendAsync(IApiRequest apiRequest)
        {
            var httpRequestMessageBuilder = new HttpRequestMessageBuilder();
            
            httpRequestMessageBuilder.WithMethod(apiRequest.Method);
            httpRequestMessageBuilder.WithRequestUri(new Uri(apiRequest.EndPointUri));
            if (apiRequest.HasPayload)
                httpRequestMessageBuilder.WithPayload(apiRequest.Payload);
            if (apiRequest.HasQueryParameters)
                httpRequestMessageBuilder.WithQueryStringParameters(apiRequest.Payload);

            var response = await httpClient.SendAsync(httpRequestMessageBuilder.Build());

            return response;
        }
    }
}