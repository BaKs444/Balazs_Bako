using Dynamitey.DynamicObjects;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System.Linq;

namespace RestSharpApi
{
    public class Helper
    {
        public Dictionary GetBookingById(string bookingid, bool getStatusCodeOptional = false)
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");
            var request = new RestRequest("booking/{bookingid}", Method.Get);
            request.AddUrlSegment("bookingid", bookingid );
            request.AddHeader("Accept", "application/json");

            if (getStatusCodeOptional == true)
            {
                var statusCode = client.Execute(request).StatusCode;
                Dictionary statusCodetoReturn = new Dictionary();
                statusCodetoReturn.Add("httpStatusCode", statusCode);
                return statusCodetoReturn;
            }

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
        public Dictionary CreateBooking(string jsonStringData, bool getStatusCodeOptional = false)
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");
            var request = new RestRequest("booking", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(jsonStringData);

            if(getStatusCodeOptional == true)
            {
                var statusCode = client.Execute(request).StatusCode;
                Dictionary statusCodetoReturn= new Dictionary();
                statusCodetoReturn.Add("httpStatusCode", statusCode);
                return statusCodetoReturn;
            }

            var response = client.Execute(request).Content;
            Dictionary deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(response);

            return deserialized;
        }
        public string WrongBookingData(string firstname, string lastname, bool depositpaid, string checkin, string checkout, string additionalneeds)
        {
            string jsonString =
                "{" +
                     "\"firstname\" : " + "\"" + firstname + "\"," +
                     "\"lastname\" : " + "\"" + lastname + "\"," +
                    // "\"totalprice\" : " + totalprice + "," +
                     "\"depositpaid\" : " + depositpaid.ToString().ToLower() + "," +
                     "\"bookingdates\" : {" +
                     "\"checkin\" : " + "\"" + checkin + "\"," +
                     "\"checkout\" : " + "\"" + checkout + "\"" +
                     "}," +
                     "\"additionalneeds\" : " + "\"" + additionalneeds + "\"" +
                "}";
            return jsonString;
        }
        public string GetBookingId(string firstname, bool getStatusCodeOptional  = false)
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");
            var request = new RestRequest("booking", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddQueryParameter("firstname", firstname);

            if (getStatusCodeOptional == true)
            {
                var statusCode = client.Execute(request).StatusCode;
                string statusCodetoReturn = statusCode.ToString();
                return statusCodetoReturn;
            }

            var response = client.Execute(request);
            JArray obs = JArray.Parse(response.Content);
            var result = obs.FirstOrDefault()?["bookingid"]?.Value<string>();

            return result;
        }
        public string GetBookingIdWithWrongParameter(string fullname)
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");
            var request = new RestRequest("booking", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("fullname", fullname);

            var response = client.Execute(request).StatusCode;

            var result = response.ToString();

            return result;
        }
        public string DeletBooking(string id)
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");
            var request = new RestRequest("booking/{id}", Method.Delete);
            request.AddUrlSegment("id", id);
            request.AddHeader("Accept", "application/json");
            client.Authenticator = new HttpBasicAuthenticator("admin", "password123");
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request).StatusCode;
            var result = response.ToString();

            return result;
        }
        public string DeletBookingWrongCredentials(string id)
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");
            var request = new RestRequest("booking/{id}", Method.Delete);
            request.AddUrlSegment("id", id);
            request.AddHeader("Accept", "application/json");
            client.Authenticator = new HttpBasicAuthenticator("admi", "password123");
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request).StatusCode;
            var result = response.ToString();

            return result;
        }
        public Dictionary UpdateBooking(string id, string jsonUpdateStringData, bool getStatusCodeOptional = false)
        {
            var client = new RestClient("https://restful-booker.herokuapp.com/");
            var request = new RestRequest("booking/{id}", Method.Put);
            request.AddUrlSegment("id", id);
            request.AddHeader("Accept", "application/json");
            client.Authenticator = new HttpBasicAuthenticator("admin", "password123");
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(jsonUpdateStringData);

            if (getStatusCodeOptional == true)
            {
                var statusCode = client.Execute(request).StatusCode;
                Dictionary statusCodetoReturn = new Dictionary();
                statusCodetoReturn.Add("httpStatusCode", statusCode);
                return statusCodetoReturn;
            }

            var response = client.Execute(request).Content;
            Dictionary deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(response);

            return deserialized;
        }
    }
}
