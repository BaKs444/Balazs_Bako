using Dynamitey.DynamicObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
using RestSharpApi.RequestFactory;

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
            CreateDataFactory CreateBookingData = new CreateDataFactory();
            ApiClient testHelper = new ApiClient();

            string bookingData = CreateBookingData.BookingData("Harry", "Potter", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(testHelper.CreateBooking(bookingData).Content);
            string bookingId = deserialized["bookingid"].ToString();

            RestResponse testResult = testHelper.DeletBooking(bookingId);

            Assert.That(testResult.StatusCode.ToString() == "Created");
        }

        [Test(Description = "Fail to delete because we give wrong credentials.")]
        public void DeleteTestNegative()
        {
            CreateDataFactory CreateBookingData = new CreateDataFactory();
            ApiClient testHelper = new ApiClient();

            string bookingData = CreateBookingData.BookingData("Harry", "Potter", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(testHelper.CreateBooking(bookingData).Content);
            string bookingId = deserialized["bookingid"].ToString();

            RestResponse testResult = testHelper.DeletBookingWrongCredentials(bookingId);

            Assert.That(testResult.StatusCode.ToString() == "Forbidden");
        }
    }
}
