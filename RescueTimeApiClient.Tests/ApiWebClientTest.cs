using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using RescueTimeWebApiClient;
using RescueTimeWebApiClient.Endpoints.AnalyticApi;

namespace RescueTimeApiClient.Tests
{
    [TestFixture]
    public class ApiWebClientTest
    {
        private HttpClient httpClient;
        
        [SetUp]
        public void Setup()
        {
            httpClient = new HttpClient();
        }
        
        [Test]
        public async Task ApiWebClient_GivenFakeGetEventRequest_ReturnsResponseWithoutException()
        {
            var eventRequest = new Mock<GetEventRequest>();
            eventRequest.Setup(r => r.EndPointUri).Returns("http://www.httpbin.org/get");
            var subject = new ApiWebClient(httpClient);

            Assert.DoesNotThrowAsync(() => subject.MakeRequest(eventRequest.Object));
        }

        [Test]
        public async Task ApiWebClient_GivenRealGetEventRequest_ReturnsSuccessfulResponse()
        {
            var eventRequest = new GetEventRequest();
            var subject = new ApiWebClient(httpClient);

            var result = await subject.MakeRequest(eventRequest);
            
            Assert.That(result, Is.Not.Null);
        }
    }
}