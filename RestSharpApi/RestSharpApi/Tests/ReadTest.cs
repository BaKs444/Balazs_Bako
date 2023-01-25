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
    [AllureSuite("Read operation")]
    public class ReadTest
    {
        [Test(Description = "Create a booking for Charlie Weasley and then check that we get the same ID as when we created the booking.")]
        public void ReadTestPositive()
        {
            CreateDataFactory CreateBookingData = new CreateDataFactory();
            ApiClient testHelper = new ApiClient();

            string bookingData = CreateBookingData.BookingData("Charlie", "Weasley", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(testHelper.CreateBooking(bookingData).Content);
            string bookingId = deserialized["bookingid"].ToString();

            RestResponse response = testHelper.GetBookingById(bookingId);
            Dictionary responseDeserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(response.Content);

            Assert.That(response.StatusCode.ToString() == "OK" & "Charlie" == responseDeserialized["firstname"].ToString());
        }

        [Test(Description = "Try to get a booking with invalid ID.")]
        public void ReadTestNegative()
        {
            ApiClient testHelper = new ApiClient();
            RestResponse response = testHelper.GetBookingById("-1");
            Assert.That(response.StatusCode.ToString() == "NotFound");
        }
    }
}
