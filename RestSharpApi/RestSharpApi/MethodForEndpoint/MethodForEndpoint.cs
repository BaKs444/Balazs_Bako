using Dynamitey.DynamicObjects;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpApi
{
    public class MethodForEndpoint
    {
        public Dictionary GetBookingById(string bookingid)
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");
            var request = new RestRequest("booking/{bookingid}", Method.Get);
            request.AddUrlSegment("bookingid", bookingid );
            request.AddHeader("Accept", "application/json");


            var response = client.Execute(request).Content;
            var deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(response);

            return deserialized;
        }
        public string BookingData(string firstname, string lastname, int totalprice, bool depositpaid, string checkin, string checkout, string additionalneeds)
        {
            string jsonString =
                "{" +
                     "\"firstname\" : " + "\"" + firstname + "\"," +
                     "\"lastname\" : " + "\"" + lastname + "\"," +
                     "\"totalprice\" : " +  totalprice + "," +
                     "\"depositpaid\" : " + depositpaid.ToString().ToLower() + "," +
                     "\"bookingdates\" : {" +
                     "\"checkin\" : " + "\"" + checkin + "\"," +
                     "\"checkout\" : " + "\"" + checkout + "\"" +
                     "}," +
                     "\"additionalneeds\" : " + "\"" + additionalneeds + "\"" +
                "}";
            return jsonString;
        }
        public Dictionary CreateBooking(string jsonStringData)
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");
            var request = new RestRequest("booking", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(jsonStringData);

            var response = client.Execute(request).Content;
            Dictionary deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(response);

            return deserialized;
        }
        public string GetBookingId(string firstname)
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");
            var request = new RestRequest("booking", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddQueryParameter("firstname", firstname);

            var response = client.Execute(request);
            JArray obs = JArray.Parse(response.Content);
            var result = obs.FirstOrDefault()?["bookingid"]?.Value<string>();

            return result;
        }
        public void DeletBooking(string id)
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");
            var request = new RestRequest("booking/{id}", Method.Delete);
            request.AddUrlSegment("id", id);
            request.AddHeader("Accept", "application/json");
            client.Authenticator = new HttpBasicAuthenticator("admin", "password123");
            request.RequestFormat = DataFormat.Json;


            var response = client.Execute(request).Content;
        }
        public Dictionary UpdateBooking(string id, string jsonUpdateStringData)
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");
            var request = new RestRequest("booking/{id}", Method.Put);
            request.AddUrlSegment("id", id);
            request.AddHeader("Accept", "application/json");
            client.Authenticator = new HttpBasicAuthenticator("admin", "password123");
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(jsonUpdateStringData);

            var response = client.Execute(request).Content;
            Dictionary deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(response);

            return deserialized;
        }
    }
}
