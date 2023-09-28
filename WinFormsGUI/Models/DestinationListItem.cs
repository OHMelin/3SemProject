using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.WFORM.Models
{
    internal class DestinationListItem
    {
        public int DestinationID { get; set; }
        public string City { get; set; }

        public DestinationListItem(int id, string city)
        {
            DestinationID = id;
            City = city;
        }

        public override string ToString()
        {
            return City;
        }
    }
}
