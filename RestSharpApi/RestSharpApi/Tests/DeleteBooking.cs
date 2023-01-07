using RestSharp;
using NUnit.Framework;

namespace RestSharpApi
{
    [TestFixture]
    public class DeleteBooking
    {
        [Test]
        public void Positive()
        {
         var client = new RestClient("https://restful-booker.herokuapp.com/");

         var request = new RestRequest("booking/{bookingid}", Method.Delete);
         request.AddUrlSegment("bookingid", 4);
         request.AddHeader("Accept", "application/json");
         request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");
         request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request).Content;

            Assert.AreEqual("Created", response.ToString());
        }

        [Test]
        public void Negative()
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");

            var request = new RestRequest("booking/{bookingid}", Method.Delete);
            request.AddUrlSegment("bookingid", 1);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request).Content;

            Assert.AreEqual("Forbidden", response.ToString());
        }
    }
}
