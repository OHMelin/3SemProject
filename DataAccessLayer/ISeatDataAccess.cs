using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL
{
    public interface ISeatDataAccess
    {
        public IEnumerable<Seat> GetAllFlightSeatsWhereID(int id);
        public IEnumerable<Seat> GetAllAvailableSeatsWhereFlightID(int id);
    }
}
