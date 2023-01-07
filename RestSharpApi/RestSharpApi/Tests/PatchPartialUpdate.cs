using RestSharp;
using NUnit.Framework;

namespace RestSharpApi
{
    [TestFixture]
    public class PatchPartialUpdate
    {
        [Test]
        public void Positive()
        {
         var client = new RestClient("https://restful-booker.herokuapp.com/");

         var request = new RestRequest("booking/{bookingid}", Method.Patch);
         request.AddUrlSegment("bookingid", 5);
         request.AddHeader("Accept", "application/json");
         request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");
         request.RequestFormat = DataFormat.Json;


            string jsonString =
                "{" +
                     "\"firstname\" : \"Ronald\"," +
                     "\"lastname\" : \"Weasley\"," +
                     "\"additionalneeds\" : \"New wand\"" +
                "}"; 

            request.AddJsonBody(jsonString);

            var response = client.Execute(request).StatusCode;

            Assert.AreEqual("OK", response.ToString());
        }

       [Test]
        public void Negative()
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");

            var request = new RestRequest("booking/{bookingid}", Method.Put);
            request.AddUrlSegment("bookingid", 1);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "No Authorization");
            request.RequestFormat = DataFormat.Json;


            string jsonString =
                "{" +
                     "\"firstname\" : \"Ronald\"," +
                     "\"lastname\" : \"Weasley\"," +
                     "\"additionalneeds\" : \"New Wand\"" +
                "}";

            request.AddJsonBody(jsonString);

            var response = client.Execute(request).StatusCode;

            Assert.AreEqual("Forbidden", response.ToString());
        }
    }
}
