using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.APIClient
{
    public interface ISeatAPIClient
    {
        public IEnumerable<Seat> GetAllFlightSeatsWhereID(int id);
        public IEnumerable<Seat> GetAvailableSeatsWhereFlightId(int id);
    }
}
