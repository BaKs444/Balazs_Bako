using Dynamitey.DynamicObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

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
            Helper testHelper = new Helper();
            string bookingData = testHelper.BookingData("Charlie", "Weasley", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary resultResponseData = testHelper.CreateBooking(bookingData);
            string resultHttpStatusCode = testHelper.GetBookingId("Charlie", true);
            string resultId = testHelper.GetBookingId("Charlie");

            Assert.That(resultHttpStatusCode == "OK" & resultId == resultResponseData["bookingid"].ToString());
        }

        [Test(Description = "Try to get a booking with invalid ID.")]
        public void ReadTestNegative()
        {
            Helper testHelper = new Helper();
            Dictionary resultHttpStatusCode = testHelper.GetBookingById("-1", true);
            Assert.That(resultHttpStatusCode["httpStatusCode"].ToString() == "NotFound");
        }
    }
}
