using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
using RestSharpApi.Factory;

namespace RestSharpApi.Tests
{
    [AllureNUnit]
    [AllureEpic("Restful-booker")]
    [AllureSuite("Create operation")]
    public class CreateTest
    {
        [Test(Description = "Creating a new booking for Harry Potter.")]
        public void CreateTestPositive()
        {
            //Create the Data Factory and the API client
            CreateDataFactory CreateBookingData = new CreateDataFactory();
            ApiClient _client = new ApiClient();

            //Create booking data with the help of Data Factory
            string bookingData = CreateBookingData.BookingData("Harry", "Potter", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            //Create booking with the API client
            RestResponse createBooking = _client.CreateBooking(bookingData);

            Assert.That(createBooking.StatusCode.ToString() == "OK" & createBooking.Content.Contains("Harry"));
        }

        [Test(Description = "Creating a new booking for Harry Potter but without dates attributes.")]
        public void CreateTestNegative()
        {
            //Create the Data Factory and the API client
            CreateDataFactory CreateBookingData = new CreateDataFactory();
            ApiClient _client = new ApiClient();

            //Create booking data with the help of Data Factory but it doesn't contains dates
            string bookingData = CreateBookingData.WrongBookingData("Harry", "Potter", 777, true, "Wand requiered");
            //Try to create booking with the API client
            RestResponse createBooking = _client.CreateBooking(bookingData);

            Assert.That(createBooking.StatusCode.ToString() == "InternalServerError");
        }
    }
}
