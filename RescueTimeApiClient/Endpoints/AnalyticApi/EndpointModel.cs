using System;

namespace RescueTimeWebApiClient.Endpoints.AnalyticApi
{
    public static class EndpointModel
    {
        public static readonly Uri Uri = new Uri("https://www.rescuetime.com/anapi/data");
        public static readonly string ApiKey = Environment.GetEnvironmentVariable("RescueTimeApiKey");
    }
}