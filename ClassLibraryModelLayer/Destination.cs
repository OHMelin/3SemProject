using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.Model
{
    public class Destination
    {
        public int? DestinationID { get; set; }
        public int? AirportID { get; set; }
        public string? City { get; set; }
    }
}
