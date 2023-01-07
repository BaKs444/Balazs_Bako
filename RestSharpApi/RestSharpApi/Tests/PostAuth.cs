using RestSharp;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace RestSharpApi
{
    [TestFixture]
    public class PostAuth
    {
        [Test]
        public void Positive()
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");

            var request = new RestRequest("auth", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { username = "admin", password = "password123" });

            var response = client.Execute(request);

            JObject obs = JObject.Parse(response.Content);
            var token = obs["token"].ToString();

            Assert.NotNull(token);
        }

        [Test]
        public void Negative()
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");

            var request = new RestRequest("auth", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { username = "admi", password = "password123" });

            var response = client.Execute(request);

            JObject obs = JObject.Parse(response.Content);
            var reason = obs["reason"].ToString();

            Assert.AreEqual(reason, "Bad credentials");
        }
    }
}
