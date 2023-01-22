using Dynamitey.DynamicObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace RestSharpApi.Tests
{
    [AllureNUnit]
    [AllureEpic("Restful-booker")]
    [AllureSuite("Update operation")]
    public class UpdateTest
    {
        [Test (Description = "Update the just created booking and check that it is really updated.")]
        public void UpdateTestPositive()
        {
            ApiClient testHelper = new ApiClient();
            string bookingData = testHelper.BookingData("Charlie", "Weasley", 777, true, "2022-11-11", "2022-12-01", "Wand requiered");
            Dictionary justCreatedBooking = testHelper.CreateBooking(bookingData);
            string bookingID = justCreatedBooking["bookingid"].ToString();

            string newBookingData = testHelper.BookingData("Lord", "Voldemort", 777, false, "2022-11-11", "2022-12-01", "Harry Potter requiered");
            Dictionary testResult = testHelper.UpdateBooking(bookingID, newBookingData, true);
            Dictionary testResultData = testHelper.UpdateBooking(bookingID, newBookingData);

            Assert.That(testResult["httpStatusCode"].ToString() == "OK" & testResultData["lastname"].ToString() == ("Voldemort"));
        }

        [Test(Description = "Try to update a not existing booking")]
        public void UpdateTestNegative()
        {
            ApiClient testHelper = new ApiClient();
            string newBookingData = testHelper.BookingData("Lord", "Voldemort", 777, false, "2022-11-11", "2022-12-01", "Harry Potter requiered");
            Dictionary resultHttpStatusCode = testHelper.UpdateBooking("-1", newBookingData, true);
            
            Assert.That(resultHttpStatusCode["httpStatusCode"].ToString() == "MethodNotAllowed");
        }
    }
}
