using ClassLibraryModelLayer;
using FlyBooking.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlyBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanesController : ControllerBase
    {
        private readonly ILogger<PlanesController> _logger;

        private readonly IPlaneDataAccess _dataAccessLayer;

        public PlanesController(ILogger<PlanesController> logger, IPlaneDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccessLayer = dataAccess;
        }

        [HttpGet]
        public IEnumerable<Plane> GetAllPlanes()
        {
            return _dataAccessLayer.GetAllPlanes();
        }
    }
}
