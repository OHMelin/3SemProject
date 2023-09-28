using ClassLibraryModelLayer;
using FlyBooking.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlyBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaneModelsController : ControllerBase
    {
        private readonly ILogger<PlaneModelsController> _logger;

        private readonly IPlaneModelDataAccess _dataAccessLayer;

        public PlaneModelsController(ILogger<PlaneModelsController> logger, IPlaneModelDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccessLayer = dataAccess;
        }

        [HttpGet]
        public IEnumerable<PlaneModel> GetAllPlaneModels()
        {
            return _dataAccessLayer.GetAllPlaneModels();
        }
    }
}
