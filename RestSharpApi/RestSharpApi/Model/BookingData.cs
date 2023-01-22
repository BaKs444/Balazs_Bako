using System.Text.Json.Serialization;

namespace RestSharpApi.Model
{

        public partial class BookingData
        {
            [JsonPropertyName("firstname")]
            public string Firstname { get; set; }

            [JsonPropertyName("lastname")]
            public string Lastname { get; set; }

            [JsonPropertyName("totalprice")]
            public long Totalprice { get; set; }

            [JsonPropertyName("depositpaid")]
            public bool Depositpaid { get; set; }

            [JsonPropertyName("bookingdates")]
            public Bookingdates Bookingdates { get; set; }

            [JsonPropertyName("additionalneeds")]
            public string Additionalneeds { get; set; }
    }

        public partial class Bookingdates
        {
            [JsonPropertyName("checkin")]
            public string Checkin { get; set; }

            [JsonPropertyName("checkout")]
            public string Checkout { get; set; }
        }
    }
