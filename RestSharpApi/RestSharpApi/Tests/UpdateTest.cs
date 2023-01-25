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
    [AllureSuite("Update operation")]
    public class UpdateTest
    {
        [Test(Description = "Update the just created booking and check that it is really updated.")]
        public void UpdateTestPositive()
        {
            //Create the Data Factory and the API client
            CreateDataFactory CreateBookingData = new CreateDataFactory();
            ApiClient _client = new ApiClient();

            //Create booking data with the help of Data Factory
            string bookingData = CreateBookingData.BookingData("Charlie", "Weasley", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            //Create the booking using the API client, and also deserialize the RestResponse return object into a Dictionary
            Dictionary deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(_client.CreateBooking(bookingData).Content);
            //From the Dictionary we are getting the booking ID of the just created booking
            string bookingId = deserialized["bookingid"].ToString();

            //Create new booking data with the help of Data Factory
            string newBookingData = CreateBookingData.BookingData("Lord", "Voldemort", 777, false, "2022-11-11", "2022-12-01", "Harry Potter requiered");
            //Update the original booking with the newly created booking data based on ID
            RestResponse testResult = _client.UpdateBooking(bookingId, newBookingData);
           
            Assert.That(testResult.StatusCode.ToString() == "OK" & testResult.Content.Contains("Voldemort"));
        }

        [Test(Description = "Try to update a not existing booking")]
        public void UpdateTestNegative()
        {
            //Create the Data Factory and the API client
            CreateDataFactory CreateBookingData = new CreateDataFactory();
            ApiClient _client = new ApiClient();

            //Create booking data with the help of Data Factory
            string newBookingData = CreateBookingData.BookingData("Lord", "Voldemort", 777, false, "2022-11-11", "2022-12-01", "Harry Potter requiered");
            //Try to Update the booking with ID = -1 with the new booking data
            RestResponse resultHttpStatusCode = _client.UpdateBooking("-1", newBookingData);

            Assert.That(resultHttpStatusCode.StatusCode.ToString() == "MethodNotAllowed");
        }
    }
}
