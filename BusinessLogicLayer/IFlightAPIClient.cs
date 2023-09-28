using ClassLibraryModelLayer;
using FlyBooking.Model;

namespace FlyBooking.APIClient
{
    public interface IFlightAPIClient
    {
        public IEnumerable<Flight> GetAllFlights();
        public Flight GetFlightById(int id);
        public int AddFlight(Flight flight);
        public bool DeleteFlight(int id);
        public bool UpdateFlight(Flight flight);
	}
}