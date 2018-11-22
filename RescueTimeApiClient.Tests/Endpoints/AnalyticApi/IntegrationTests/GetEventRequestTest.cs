using System.Net.Http;
using Moq;
using NUnit.Framework;
using RescueTimeWebApiClient;
using RescueTimeWebApiClient.Endpoints.AnalyticApi;

namespace RescueTimeApiClient.Tests.Endpoints.AnalyticApi.IntegrationTests
{
    [TestFixture]
    public class GetEventRequestTest
    {
        private Mock<HttpClient> httpClient = new Mock<HttpClient>();
        
        [Test]
        public void GetEventRequest_WhenMockedDependencies_ReturnsDataWithOutException()
        {
            const string json = "json";
            var getEventRequest = new GetEventRequest()
            {
                Format = json
            };

            var subject = new ApiWebClient(httpClient.Object);
            var response = subject.MakeRequest(getEventRequest);
            
            Assert.That(response.Status, Is.EqualTo(201));
        }
    }
}