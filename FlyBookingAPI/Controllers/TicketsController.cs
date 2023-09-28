using ClassLibraryModelLayer;
using FlyBooking.DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlyBooking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketsController : ControllerBase
	{
		private readonly ILogger<TicketsController> _logger;
		private readonly ITicketDataAccess _dataAccess;

		public TicketsController(ITicketDataAccess dataAccess, ILogger<TicketsController> logger)
		{
			_dataAccess = dataAccess;
			_logger = logger;
		}

		// GET: api/<TicketsController>
		[HttpGet]
		[Route("{id}")]
		public IEnumerable<Ticket> Get(int id)
		{
			return _dataAccess.GetAllTicketsFromUser(id);
		}
	}
}
