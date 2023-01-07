using RestSharp;
using NUnit.Framework;

namespace RestSharpApi
{
    [TestFixture]
    public class PostCreateBooking
    {
        [Test]
        public void Positive()
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");

         var request = new RestRequest("booking", Method.Post);
         request.AddHeader("Accept", "application/json");
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

            var request = new RestRequest("booking", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            string jsonString =
                "{" +
                     "\"firstnam\" : \"Harry\"," +
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

            var response = client.Execute(request).Content;

            Assert.AreEqual("Internal Server Error", response.ToString());
        }
    }
}
