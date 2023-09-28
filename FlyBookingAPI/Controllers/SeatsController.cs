using ClassLibraryModelLayer;
using FlyBooking.DAL;
using FlyBooking.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlyBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ILogger<SeatsController> _logger;

        private readonly ISeatDataAccess _dataAccessLayer;

        public SeatsController(ILogger<SeatsController> logger, ISeatDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccessLayer = dataAccess;
        }

        [HttpGet]
        [Route("flights/{id}")] //this might be wrong, but since it finds all seats from a fligt id it is routed to seats/flights/id instead of seats/ since that would normally return all seats
        public IEnumerable<Seat> GetAllFlightSeatsWhereID(int id)
        {
            return _dataAccessLayer.GetAllFlightSeatsWhereID(id);
        }

        [HttpGet]
        [Route("flights/{id}/available")] //this might be wrong, same reason as above ^^
        public IEnumerable<Seat> GetAvailableSeats(int id)
        {
            return _dataAccessLayer.GetAllAvailableSeatsWhereFlightID(id);
        }
    }
}
