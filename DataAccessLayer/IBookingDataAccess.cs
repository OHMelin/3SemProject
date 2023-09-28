using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL
{
    public interface IBookingDataAccess
    {
        public int AddBooking(Booking booking);
        public bool DeleteBooking(int id);
        public IEnumerable<Booking> getBookingsByAccountId(int accountId);
    }
}
