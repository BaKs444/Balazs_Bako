using Dynamitey.DynamicObjects;
using NUnit.Framework;

namespace RestSharpApi.Tests
{
    public class CreateTest
    {
        [Test]
        public void Positive()
        {
            Helper testHelper = new Helper();
            string bookingData = testHelper.BookingData("Harry", "Potter", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary resultHttpStatus = testHelper.CreateBooking(bookingData, true);
            Dictionary resultResponseData = testHelper.CreateBooking(bookingData);

            Assert.That(resultHttpStatus["httpStatusCode"].ToString() == "OK" & resultResponseData["booking"].ToString().Contains("Harry"));
        }

        [Test]
        public void Negative()
        {
            Helper testHelper = new Helper();
            string bookingData = testHelper.WrongBookingData("Harry", "Potter", true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary resultHttpStatus = testHelper.CreateBooking(bookingData, true);

            Assert.That(resultHttpStatus["httpStatusCode"].ToString() == "InternalServerError");
        }
    }
}
