using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.APIClient
{
    public interface IBookingAPIClient
    {
        public int AddBooking(Booking booking);
        public bool DeleteBooking(int id);
        public IEnumerable<Booking> GetBookingsByAccountID(int id);
    }
}
