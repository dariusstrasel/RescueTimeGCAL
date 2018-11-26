using System;
using NUnit.Framework;
using RescueTimeWebApiClient.Endpoints.AnalyticApi;

namespace RescueTimeApiClient.Tests.Endpoints.AnalyticApi
{
    [TestFixture]
    public class GetEventRequestTest
    {
        [Test]
        public void GetEventRequest_HasEndpointUri()
        {
            var restrictBegin = DateTime.Now;
            var restrictEnd = DateTime.Now.AddDays(1);
            var subject = new GetEventRequest
            {
                Format = "",
                Perspective = "",
                ResolutionTime = "",
                RestrictBegin = restrictBegin,
                RestrictEnd = restrictEnd
            };
            
            Assert.That(subject.EndPointUri, Is.Not.Empty);
        }
    }
}