using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModelLayer
{
    public class Booking
    {
        public int? BookingID { get; set; }
        public DateTime? BookingDate { get; set; }
        public int? PaymentID { get; set; }
        public int? AccountID { get; set; }
        public int? FlightID { get; set; }
        public Ticket? ticket { get; set; }
    }
}
