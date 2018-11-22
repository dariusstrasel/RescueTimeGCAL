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

        public async Task MakeRequest(IApiRequest apiRequest)
        {
            var response = await SendAsync(apiRequest);
        }

        private async Task<HttpResponseMessage> SendAsync(IApiRequest apiRequest)
        {
            var request = new HttpRequestMessage
            {
                Method = apiRequest.Method,
                RequestUri = new Uri(apiRequest.EndpointUri)
            };

            if (apiRequest.HasPayload)
            {
                throw new NotImplementedException();
            }

            request.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Payload));
            
            var response = await httpClient.SendAsync(request);

            return response;
        }
    }
}