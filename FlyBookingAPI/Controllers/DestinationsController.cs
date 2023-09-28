using ClassLibraryModelLayer;
using FlyBooking.DAL;
using FlyBooking.Model;
using Microsoft.AspNetCore.Mvc;

namespace FlyBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationsController : ControllerBase
    {
        private readonly ILogger<DestinationsController> _logger;

        private readonly IDestinationDataAccess _dataAccessLayer;

        public DestinationsController(ILogger<DestinationsController> logger, IDestinationDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccessLayer = dataAccess;
        }

        [HttpGet]
        public IEnumerable<Destination> GetAllDestinations()
        {
            return _dataAccessLayer.GetAllDestinations();
        }
    }
}
