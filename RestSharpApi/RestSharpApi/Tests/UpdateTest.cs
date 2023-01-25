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
    [AllureSuite("Update operation")]
    public class UpdateTest
    {
        [Test(Description = "Update the just created booking and check that it is really updated.")]
        public void UpdateTestPositive()
        {
            CreateDataFactory CreateBookingData = new CreateDataFactory();
            ApiClient testHelper = new ApiClient();

            string bookingData = CreateBookingData.BookingData("Charlie", "Weasley", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary>(testHelper.CreateBooking(bookingData).Content);
            string bookingId = deserialized["bookingid"].ToString();

            string newBookingData = CreateBookingData.BookingData("Lord", "Voldemort", 777, false, "2022-11-11", "2022-12-01", "Harry Potter requiered");
            RestResponse testResult = testHelper.UpdateBooking(bookingId, newBookingData);
           
            Assert.That(testResult.StatusCode.ToString() == "OK" & testResult.Content.Contains("Voldemort"));
        }

        [Test(Description = "Try to update a not existing booking")]
        public void UpdateTestNegative()
        {
            CreateDataFactory CreateBookingData = new CreateDataFactory();
            ApiClient testHelper = new ApiClient();

            string newBookingData = CreateBookingData.BookingData("Lord", "Voldemort", 777, false, "2022-11-11", "2022-12-01", "Harry Potter requiered");
            RestResponse resultHttpStatusCode = testHelper.UpdateBooking("-1", newBookingData);

            Assert.That(resultHttpStatusCode.StatusCode.ToString() == "MethodNotAllowed");
        }
    }
}
