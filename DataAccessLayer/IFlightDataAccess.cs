using ClassLibraryModelLayer;
using FlyBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL
{
    public interface IFlightDataAccess
    {
        public IEnumerable<Flight> GetAllFlights();
        public Flight GetFlightById(int id);
        public int AddFlight(Flight flight);
        public bool DeleteFlight(int id);
        public bool UpdateFlight(Flight flight);
    }
}