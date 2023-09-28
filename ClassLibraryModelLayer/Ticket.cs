using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModelLayer
{
    public class Ticket
    {
        public int? TicketID { get; set; }
        public int? PersonID { get; set; }
        public int? SeatID { get; set; }
        public int? BookingID { get; set; }
        public Seat? seat { get; set; }
    }
}
