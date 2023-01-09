using Dynamitey.DynamicObjects;
using NUnit.Framework;

namespace RestSharpApi.Tests
{
    public class ReadTest
    {
        [Test]
        public void Positive()
        {
            Helper testHelper = new Helper();
            string bookingData = testHelper.BookingData("Charlie", "Weasley", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary resultResponseData = testHelper.CreateBooking(bookingData);
            string resultHttpStatusCode = testHelper.GetBookingId("Charlie", true);
            string resultId = testHelper.GetBookingId("Charlie");

            Assert.That(resultHttpStatusCode == "OK" & resultId == resultResponseData["bookingid"].ToString());
        }

        [Test]
        public void Negative()
        {
            Helper testHelper = new Helper();
            Dictionary resultHttpStatusCode = testHelper.GetBookingById("-1", true);
            Assert.That(resultHttpStatusCode["httpStatusCode"].ToString() == "NotFound");
        }
    }
}
