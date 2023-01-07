using RestSharp;
using NUnit.Framework;

namespace RestSharpApi
{
    [TestFixture]
    public class GetHealthCheck
    {
        [Test]
        public void Positive()
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");

            var request = new RestRequest("ping", Method.Get);
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request).Content;

            Assert.That(response, Is.EqualTo("Created"));
        }

        [Test]
        public void Negative()
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");

            var request = new RestRequest("pin", Method.Get);
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request).Content;

            Assert.That(response, Is.Not.EqualTo("Created"));
        }
    }
}
