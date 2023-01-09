using Dynamitey.DynamicObjects;
using NUnit.Framework;

namespace RestSharpApi.Tests
{
    public class UpdateTest
    {
        [Test]
        public void Positive()
        {
            Helper testHelper = new Helper();
            string bookingData = testHelper.BookingData("Charlie", "Weasley", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary justCreatedBooking = testHelper.CreateBooking(bookingData);
            string bookingID = justCreatedBooking["bookingid"].ToString();

            string newBookingData = testHelper.BookingData("Lord", "Voldemort", 777, false, "2022-11-11", "2022-12-01", "Harry Potter requiered");
            Dictionary testResult = testHelper.UpdateBooking(bookingID, newBookingData, true);
            Dictionary testResultData = testHelper.UpdateBooking(bookingID, newBookingData);

            Assert.That(testResult["httpStatusCode"].ToString() == "OK" & testResultData["lastname"].ToString() == ("Voldemort"));
        }

        [Test]
        public void Negative()
        {
            Helper testHelper = new Helper();
            string newBookingData = testHelper.BookingData("Lord", "Voldemort", 777, false, "2022-11-11", "2022-12-01", "Harry Potter requiered");
            Dictionary resultHttpStatusCode = testHelper.UpdateBooking("-1", newBookingData, true);
            
            Assert.That(resultHttpStatusCode["httpStatusCode"].ToString() == "MethodNotAllowed");
        }
    }
}
