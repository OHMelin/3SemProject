using FlyBooking.DAL;
using ClassLibraryModelLayer;
using Microsoft.AspNetCore.Mvc;

namespace FlyBookingAPI.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
       
        private readonly ILogger<AccountsController> _logger;

        private readonly IAccountDataAccess _dataAccessLayer;

        public AccountsController(ILogger<AccountsController> logger, IAccountDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccessLayer = dataAccess;
        }

        [HttpPost]
        public int AddAccount(Account account)
        {
            //this returns an int of the newly created flight
            return _dataAccessLayer.AddAccount(account);
        }

        [HttpPost]
        [Route("GetUserByLogin")] //Needs unique routing with how login currently works. Should be get instead of post 
        public Account GetUserByLogin([FromBody] LoginModel model)
        {
            return _dataAccessLayer.GetUserByLogin(model.Password, model.Username);
        }

        [HttpGet]
        [Route("{id}")]
        public Account GetUserByID(int id)
        {
            return _dataAccessLayer.GetUserByID(id);
        }

        //making a new model so we can add is as a http body json
        [HttpPost]
        [Route("Login")] //might also be wrong :)
        public bool LoginAccount([FromBody] LoginModel model)
        {
            return _dataAccessLayer.LoginAccount(model.Password, model.Username);
        }
    }
}
