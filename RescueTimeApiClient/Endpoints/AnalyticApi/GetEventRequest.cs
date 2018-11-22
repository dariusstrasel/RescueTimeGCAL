using System;
using RescueTimeWebApiClient.Requests;

namespace RescueTimeWebApiClient.Endpoints.AnalyticApi
{
    public class GetEventRequest : GetRequest
    {
        public readonly string EndPointUri = EndpointModel.Uri.ToString(); // TODO: Reconcile EndPointUri and Key with new WebClient class. 
        public readonly string Key = EndpointModel.ApiKey;
        public string Perspective { get; set; }
        public string ResolutionTime { get; set; }
        public DateTime RestrictBegin { get; set; }
        public DateTime RestrictEnd { get; set; }
        public string Format { get; set; }

        public object Payload => new
        {
            key = Key,
            perspective = Perspective,
            resolutionTime = ResolutionTime,
            restrictBegin = RestrictBegin,
            restrictEnd = RestrictEnd,
            format = Format
        };
    }
}