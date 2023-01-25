using RestSharp;
using RestSharp.Authenticators;
using RestSharpApi.Model;
using System.Text.Json;

namespace RestSharpApi.Factory
{
    public class CreateDataFactory
    {
        public string BookingData(string firstname, string lastname, int totalprice, bool depositpaid, string checkin, string checkout, string additionalneeds)
        {

            var model = new BookingData()
            {
                Firstname = firstname,
                Lastname = lastname,
                Totalprice = totalprice,
                Depositpaid = depositpaid,
                Bookingdates = new Bookingdates
                {
                    Checkin = checkin,
                    Checkout = checkout,
                },
                Additionalneeds = additionalneeds,
            };
            string jsonString = JsonSerializer.Serialize(model);

            return jsonString;
        }

        public string WrongBookingData(string firstname, string lastname, long totalprice, bool depositpaid, string additionalneeds)
        {
            var model = new BookingData()
            {
                Firstname = firstname,
                Lastname = lastname,
                Depositpaid = depositpaid,
                Totalprice = totalprice,
                Additionalneeds = additionalneeds,
            };
            string jsonString = JsonSerializer.Serialize(model);

            return jsonString;
        }

    }
}