using Dynamitey.DynamicObjects;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using RestSharpApi.Model;
using System.Linq;
using System.Text.Json;

namespace RestSharpApi
{
    public class ApiClient
    {
        private static readonly RestClient restClient = new RestClient("https://restful-booker.herokuapp.com/");

        public Dictionary GetBookingById(string bookingid)
        {
            var request = new RestRequest("booking/{bookingid}", Method.Get);
            request.AddUrlSegment("bookingid", bookingid);
            request.AddHeader("Accept", "application/json");

            var statusCode = restClient.Execute(request).StatusCode;
            Dictionary statusCodetoReturn = new Dictionary();
            statusCodetoReturn.Add("httpStatusCode", statusCode);
            return statusCodetoReturn;
        }
        public string BookingData(string firstname, string lastname, int totalprice, bool depositpaid, string checkin, string checkout, string additionalneeds)
        {

            var model = new BookingData()
            {
                Firstname = firstname,
                Lastname = lastname,
                Totalprice = totalprice,
                Depositpaid = depositpaid,
                Bookingdates = new Bookingdates
                {
                    Checkin = checkin,
                    Checkout = checkout,
                },
                Additionalneeds = additionalneeds,
            };
            string jsonString = JsonSerializer.Serialize(model);

            return jsonString;
        }
        public Dictionary CreateBooking(string jsonStringData, bool getStatusCodeOptional = false)
        {
            var request = new RestRequest("booking", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(jsonStringData);

            if (getStatusCodeOptional == true)
            {
                var statusCode = restClient.Execute(request).StatusCode;
                Dictionary statusCodetoReturn = new Dictionary();
                statusCodetoReturn.Add("httpStatusCode", statusCode);
                return statusCodetoReturn;
            }

            var response = restClient.Execute(request).Content;
            Dictionary deserialized = JsonSerializer.Deserialize<Dictionary>(response);

            return deserialized;
        }
        public string WrongBookingData(string firstname, string lastname,long totalprice, bool depositpaid, string additionalneeds)
        {
            var model = new BookingData()
            {
                Firstname = firstname,
                Lastname = lastname,
                Depositpaid = depositpaid,
                Totalprice = totalprice,
                Additionalneeds = additionalneeds,
            };
            string jsonString = JsonSerializer.Serialize(model);

            return jsonString;
        }
        public string GetBookingId(string firstname, bool getStatusCodeOptional  = false)
        {
            var request = new RestRequest("booking", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddQueryParameter("firstname", firstname);

            if (getStatusCodeOptional == true)
            {
                var statusCode = restClient.Execute(request).StatusCode;
                string statusCodetoReturn = statusCode.ToString();
                return statusCodetoReturn;
            }

            var response = restClient.Execute(request);
            JArray obs = JArray.Parse(response.Content);
            var result = obs.FirstOrDefault()?["bookingid"]?.Value<string>();

            return result;
        }
        public string GetBookingIdWithWrongParameter(string fullname)
        {
            var request = new RestRequest("booking", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("fullname", fullname);

            var response = restClient.Execute(request).StatusCode;

            var result = response.ToString();

            return result;
        }
        public string DeletBooking(string id)
        {
            var request = new RestRequest("booking/{id}", Method.Delete);
            request.AddUrlSegment("id", id);
            request.AddHeader("Accept", "application/json");
            restClient.Authenticator = new HttpBasicAuthenticator("admin", "password123");
            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute(request).StatusCode;
            var result = response.ToString();

            return result;
        }
        public string DeletBookingWrongCredentials(string id)
        {
            var request = new RestRequest("booking/{id}", Method.Delete);
            request.AddUrlSegment("id", id);
            request.AddHeader("Accept", "application/json");
            restClient.Authenticator = new HttpBasicAuthenticator("admi", "password123");
            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute(request).StatusCode;
            var result = response.ToString();

            return result;
        }
        public Dictionary UpdateBooking(string id, string jsonUpdateStringData, bool getStatusCodeOptional = false)
        {
            var request = new RestRequest("booking/{id}", Method.Put);
            request.AddUrlSegment("id", id);
            request.AddHeader("Accept", "application/json");
            restClient.Authenticator = new HttpBasicAuthenticator("admin", "password123");
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(jsonUpdateStringData);

            if (getStatusCodeOptional == true)
            {
                var statusCode = restClient.Execute(request).StatusCode;
                Dictionary statusCodetoReturn = new Dictionary();
                statusCodetoReturn.Add("httpStatusCode", statusCode);
                return statusCodetoReturn;
            }

            var response = restClient.Execute(request).Content;
            Dictionary deserialized = JsonSerializer.Deserialize<Dictionary>(response);

            return deserialized;
        }
    }
}
