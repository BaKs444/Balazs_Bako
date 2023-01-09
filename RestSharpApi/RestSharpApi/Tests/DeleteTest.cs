using Dynamitey.DynamicObjects;
using NUnit.Framework;

namespace RestSharpApi.Tests
{
    public class DeleteTest
    {
        [Test]
        public void Positive()
        {
            Helper testHelper = new Helper();
            string bookingData = testHelper.BookingData("Harry", "Potter", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary booking = testHelper.CreateBooking(bookingData);
            string id = booking["bookingid"].ToString();

            string testResult = testHelper.DeletBooking(id);

            Assert.That(testResult == "Created");
        }

        [Test]
        public void Negative()
        {
            Helper testHelper = new Helper();
            string bookingData = testHelper.BookingData("Harry", "Potter", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary booking = testHelper.CreateBooking(bookingData);
            string id = booking["bookingid"].ToString();

            string testResult = testHelper.DeletBookingWrongCredentials(id);

            Assert.That(testResult == "Forbidden");
        }
    }
}
