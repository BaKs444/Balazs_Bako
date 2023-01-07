using RestSharp;
using NUnit.Framework;

namespace RestSharpApi
{
    [TestFixture]
    public class GetBooking
    {
        [Test]
        public void Positive()
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");

            var request = new RestRequest("booking/{bookingid}", Method.Get);
            request.AddUrlSegment("bookingid", 5);
            request.AddHeader("Accept", "application/json");


            //var response = client.Execute(request)Content;
            // var deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(response);
            // var result = deserialized["firstname"];
            //string correctForm = result.ToString();

            var response = client.Execute(request).StatusCode;

            //JObject obs = JObject.Parse(response.Content);

            //Assert.That(obs["firstname"].ToString(), Is.EqualTo("Susan"));
            Assert.AreEqual("OK", response.ToString());   
        }

        [Test]
        public void Negative()
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");

            var request = new RestRequest("booking/{bookingid}", Method.Get);
            request.AddUrlSegment("bookingid", -1);
            request.AddHeader("Accept", "application/json");


            //var response = client.Execute(request)Content;
            // var deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(response);
            // var result = deserialized["firstname"];
            //string correctForm = result.ToString();

            var response = client.Execute(request).StatusCode;

            //JObject obs = JObject.Parse(response.Content);

            //Assert.That(obs["firstname"].ToString(), Is.EqualTo("Susan"));
            Assert.AreNotEqual("OK", response.ToString());
        }
    }
}
