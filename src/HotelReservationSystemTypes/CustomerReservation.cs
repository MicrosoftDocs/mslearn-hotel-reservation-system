using System;

namespace HotelReservationSystemTypes
{
    [Serializable]
    public class CustomerReservation
    {
        public int ReservationID { get; set; }
        public string CustomerID { get; set; }
        public string HotelID { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int NumberOfGuests { get; set; }
        public string ReservationComments { get; set; }
        public override string ToString() => $"Reservation {ReservationID}, CustomerID {CustomerID}, HotelID {HotelID}, Checkin {Checkin:d}, Checkout {Checkout:d}, Guests {NumberOfGuests}\nComments: {ReservationComments}";
    }
}
