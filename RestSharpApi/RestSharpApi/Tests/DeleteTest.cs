using Dynamitey.DynamicObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace RestSharpApi.Tests
{
    [AllureNUnit]
    [AllureEpic("Restful-booker")]
    [AllureSuite("Delete operation")]
    public class DeleteTest
    {
        [Test (Description = "Deleting the just created new booking for Harry Potter based on it's ID.")]
        public void DeleteTestPositive()
        {
            Helper testHelper = new Helper();
            string bookingData = testHelper.BookingData("Harry", "Potter", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary booking = testHelper.CreateBooking(bookingData);
            string id = booking["bookingid"].ToString();

            string testResult = testHelper.DeletBooking(id);

            Assert.That(testResult == "Created");
        }

        [Test(Description = "Fail to delete because we give wrong credentials.")]
        public void DeleteTestNegative()
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
