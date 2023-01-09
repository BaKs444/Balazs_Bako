using Dynamitey.DynamicObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace RestSharpApi.Tests
{
    [AllureNUnit]
    [AllureEpic("Restful-booker")]
    [AllureSuite("Create operation")]
    public class CreateTest
    {
        [Test (Description = "Creating a new booking for Harry Potter.")]
        public void CreateTestPositive()
        {
            Helper testHelper = new Helper();
            string bookingData = testHelper.BookingData("Harry", "Potter", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary resultHttpStatus = testHelper.CreateBooking(bookingData, true);
            Dictionary resultResponseData = testHelper.CreateBooking(bookingData);

            Assert.That(resultHttpStatus["httpStatusCode"].ToString() == "OK" & resultResponseData["booking"].ToString().Contains("Harry"));
        }

        [Test (Description = "Creating a new booking for Harry Potter but without totalprice attribute.")]
        public void CreateTestNegative()
        {
            Helper testHelper = new Helper();
            string bookingData = testHelper.WrongBookingData("Harry", "Potter", true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary resultHttpStatus = testHelper.CreateBooking(bookingData, true);

            Assert.That(resultHttpStatus["httpStatusCode"].ToString() == "InternalServerError");
        }
    }
}
