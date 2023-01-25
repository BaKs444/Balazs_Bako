using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
using RestSharpApi.RequestFactory;

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
            CreateDataFactory CreateBookingData = new CreateDataFactory();
            ApiClient testHelper = new ApiClient();

            string bookingData = CreateBookingData.BookingData("Harry", "Potter", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            RestResponse createBooking = testHelper.CreateBooking(bookingData);

            Assert.That(createBooking.StatusCode.ToString() == "OK" & createBooking.Content.Contains("Harry"));
        }

        [Test(Description = "Creating a new booking for Harry Potter but without dates attributes.")]
        public void CreateTestNegative()
        {
            CreateDataFactory CreateBookingData = new CreateDataFactory();
            ApiClient testHelper = new ApiClient();

            string bookingData = CreateBookingData.WrongBookingData("Harry", "Potter", 777, true, "Wand requiered");
            RestResponse createBooking = testHelper.CreateBooking(bookingData);

            Assert.That(createBooking.StatusCode.ToString() == "InternalServerError");
        }
    }
}
