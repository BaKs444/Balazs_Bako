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
    [AllureSuite("Delete operation")]
    public class DeleteTest
    {
        [Test(Description = "Deleting the just created new booking for Harry Potter based on it's ID.")]
        public void DeleteTestPositive()
        {
            //Create the Data Factory and the API client
            CreateDataFactory CreateBookingData = new CreateDataFactory();
            ApiClient _client = new ApiClient();

            //Create booking data with the help of Data Factory
            string bookingData = CreateBookingData.BookingData("Harry", "Potter", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            //Create the booking using the API client, and also deserialize the RestResponse return object into a Dictionary
            Dictionary deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(_client.CreateBooking(bookingData).Content);
            //From the Dictionary we are getting the booking ID
            string bookingId = deserialized["bookingid"].ToString();

            //With the ID we can delete the just created booking, and save the response
            RestResponse testResult = _client.DeletBooking(bookingId);

            Assert.That(testResult.StatusCode.ToString() == "Created");
        }

        [Test(Description = "Fail to delete because we give wrong credentials.")]
        public void DeleteTestNegative()
        {
            //Create the Data Factory and the API client
            CreateDataFactory CreateBookingData = new CreateDataFactory();
            ApiClient _client = new ApiClient();

            //Create booking data with the help of Data Factory
            string bookingData = CreateBookingData.BookingData("Harry", "Potter", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            //Create the booking using the API client, and also deserialize the RestResponse return object into a Dictionary
            Dictionary deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(_client.CreateBooking(bookingData).Content);
            //From the Dictionary we are getting the booking ID
            string bookingId = deserialized["bookingid"].ToString();

            //With the ID we try to delete the just created booking but with wrong credentials, and save the response
            RestResponse testResult = _client.DeletBookingWrongCredentials(bookingId);

            Assert.That(testResult.StatusCode.ToString() == "Forbidden");
        }
    }
}
