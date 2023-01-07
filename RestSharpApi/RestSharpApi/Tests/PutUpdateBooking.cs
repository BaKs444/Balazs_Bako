using RestSharp;
using NUnit.Framework;

namespace RestSharpApi
{
    [TestFixture]
    public class PutUpdateBooking
    {
        [Test]
        public void Positive()
        {
         var client = new RestClient("https://restful-booker.herokuapp.com/");

         var request = new RestRequest("booking/{bookingid}", Method.Put);
         request.AddUrlSegment("bookingid", 5);
         request.AddHeader("Accept", "application/json");
         request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");
         request.RequestFormat = DataFormat.Json;


            string jsonString =
                "{" +
                     "\"firstname\" : \"Harry\"," +
                     "\"lastname\" : \"Potter\"," +
                     "\"totalprice\" : 1112," +
                     "\"depositpaid\" : true," +
                     "\"bookingdates\" : {" +
                        "\"checkin\" : \"2018-01-01\"," +
                        "\"checkout\" : \"2019-01-01\"" +
                     "}," +
                     "\"additionalneeds\" : \"Breakfast\"" +
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
                     "\"firstname\" : \"Harry\"," +
                     "\"lastname\" : \"Potter\"," +
                     "\"totalprice\" : 1112," +
                     "\"depositpaid\" : true," +
                     "\"bookingdates\" : {" +
                        "\"checkin\" : \"2018-01-01\"," +
                        "\"checkout\" : \"2019-01-01\"" +
                     "}," +
                     "\"additionalneeds\" : \"Breakfast\"" +
                "}";

            request.AddJsonBody(jsonString);

            var response = client.Execute(request).StatusCode;

            Assert.AreEqual("Forbidden", response.ToString());
        }
    }
}
