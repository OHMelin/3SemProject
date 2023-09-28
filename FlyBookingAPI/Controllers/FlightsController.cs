using ClassLibraryModelLayer;
using FlyBooking.DAL;
using FlyBooking.Model;
using Microsoft.AspNetCore.Mvc;

namespace FlyBooking.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FlightsController : ControllerBase
	{
		private readonly ILogger<FlightsController> _logger;

		private readonly IFlightDataAccess _dataAccessLayer;

		public FlightsController(ILogger<FlightsController> logger, IFlightDataAccess dataAccess)
		{
			_logger = logger;
			_dataAccessLayer = dataAccess;
		}

		[HttpPost]
		public int AddFlight(Flight flight)
		{
			//this returns an int of the newly created flight
			return _dataAccessLayer.AddFlight(flight);

		}

		[HttpPut]
        public bool UpdateFlight(Flight flight)
        {
            return _dataAccessLayer.UpdateFlight(flight);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool DeleteFlight(int id)
        {
            return _dataAccessLayer.DeleteFlight(id);
        }

		[HttpGet]
        public IEnumerable<Flight> GetAllFlights()
        {
            return _dataAccessLayer.GetAllFlights();
        }

        [HttpGet]
        [Route("{id}")]
        public Flight GetFlightById(int id)
        {
            return _dataAccessLayer.GetFlightById(id);
        }
    }
}
