using RestSharp;
using NUnit.Framework;

namespace RestSharpApi
{
    [TestFixture]
    public class GetBookingId
    {
        [Test]
        public void Positive()
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");

            var request = new RestRequest("booking", Method.Get);
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request).StatusCode;

            Assert.AreEqual("OK", response.ToString());   
        }

        [Test]
        public void Negative()
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");

            var request = new RestRequest("bookingg", Method.Get);
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request).StatusCode;

            Assert.AreEqual("NotFound", response.ToString());
        }

    }
}
