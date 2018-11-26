using System;
using RescueTimeWebApiClient.Requests;

namespace RescueTimeWebApiClient.Endpoints.AnalyticApi
{
    public class GetEventRequest : GetRequest<GetEventResponse>
    {
        public override string EndPointUri => EndpointModel.Uri.ToString();
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