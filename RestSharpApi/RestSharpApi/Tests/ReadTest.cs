using Dynamitey.DynamicObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
using RestSharpApi.Factory;

namespace RestSharpApi.Tests
{
    [AllureNUnit]
    [AllureEpic("Restful-booker")]
    [AllureSuite("Read operation")]
    public class ReadTest
    {
        [Test(Description = "Create a booking for Charlie Weasley and then check that we get the same ID as when we created the booking.")]
        public void ReadTestPositive()
        {
            //Create the Data Factory and the API client
            CreateDataFactory CreateBookingData = new CreateDataFactory();
            ApiClient _client = new ApiClient();

            //Create booking data with the help of Data Factory
            string bookingData = CreateBookingData.BookingData("Charlie", "Weasley", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            //Create the booking using the API client, and also deserialize the RestResponse return object into a Dictionary
            Dictionary deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(_client.CreateBooking(bookingData).Content);
            //From the Dictionary we are getting the booking ID
            string bookingId = deserialized["bookingid"].ToString();

            //With the booking ID we search for the just created booking
            RestResponse response = _client.GetBookingById(bookingId);
            //Deserialize the response into a Dictionary
            Dictionary responseDeserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(response.Content);

            Assert.That(response.StatusCode.ToString() == "OK" & "Charlie" == responseDeserialized["firstname"].ToString());
        }

        [Test(Description = "Try to get a booking with invalid ID.")]
        public void ReadTestNegative()
        {
            //Create the API client
            ApiClient _client = new ApiClient();
            //We search for the booking with ID = -1 
            RestResponse response = _client.GetBookingById("-1");

            Assert.That(response.StatusCode.ToString() == "NotFound");
        }
    }
}
