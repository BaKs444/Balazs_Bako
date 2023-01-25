using RestSharp;
using RestSharp.Authenticators;


namespace RestSharpApi
{
    public class ApiClient
    {
        private static readonly RestClient restClient = new RestClient("https://restful-booker.herokuapp.com/");

        public RestResponse GetBookingById(string bookingid)
        {
            var request = new RestRequest("booking/{bookingid}", Method.Get);
            request.AddUrlSegment("bookingid", bookingid);
            request.AddHeader("Accept", "application/json");
            RestResponse response = restClient.Execute(request);
            
            return response;  
        }
        public RestResponse CreateBooking(string jsonStringData)
        {
            var request = new RestRequest("booking", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(jsonStringData);

            var response = restClient.Execute(request);
            return response;
        }
        public RestResponse DeletBooking(string id)
        {
            var request = new RestRequest("booking/{id}", Method.Delete);
            request.AddUrlSegment("id", id);
            request.AddHeader("Accept", "application/json");
            restClient.Authenticator = new HttpBasicAuthenticator("admin", "password123");
            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute(request);
            return response;
        }
        public RestResponse DeletBookingWrongCredentials(string id)
        {
            var request = new RestRequest("booking/{id}", Method.Delete);
            request.AddUrlSegment("id", id);
            request.AddHeader("Accept", "application/json");
            restClient.Authenticator = new HttpBasicAuthenticator("admi", "password123");
            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute(request);
            return response;
        }
        public RestResponse UpdateBooking(string id, string jsonUpdateStringData)
        {
            var request = new RestRequest("booking/{id}", Method.Put);
            request.AddUrlSegment("id", id);
            request.AddHeader("Accept", "application/json");
            restClient.Authenticator = new HttpBasicAuthenticator("admin", "password123");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(jsonUpdateStringData);

            var response = restClient.Execute(request);
            return response;
        }
    }
}
