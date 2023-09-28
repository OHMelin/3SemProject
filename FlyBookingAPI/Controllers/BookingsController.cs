using ClassLibraryModelLayer;
using FlyBooking.DAL;
using FlyBooking.DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FlyBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : Controller
    {

        private readonly ILogger<BookingsController> _logger;

        private readonly IBookingDataAccess _dataAccessLayer;

        public BookingsController(ILogger<BookingsController> logger, IBookingDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccessLayer = dataAccess;
        }

        [HttpPost]
        public int AddBooking(Booking booking)
        {
            try
            {
				return _dataAccessLayer.AddBooking(booking);
			}
            catch
            {
                return -1;
            }
		}

        [HttpDelete]
        [Route("{id}")]
        public bool DeleteBooking(int id)
        {
            return _dataAccessLayer.DeleteBooking(id);
        }

        [HttpGet]
        [Route("Accounts/{id}")] //might be wrong. routing to bookings/accounts/id/
        public IEnumerable<Booking> GetBookingsByAccountId(int id)
        {
            return _dataAccessLayer.getBookingsByAccountId(id);
        }

    }
}
