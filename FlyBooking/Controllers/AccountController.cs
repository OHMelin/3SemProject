using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ClassLibraryModelLayer;
using FlyBooking.DAL;

namespace FlyBooking.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly FlyBooking.APIClient.IAccountAPIClient _accountApiClient;
		private readonly FlyBooking.APIClient.ITicketAPIClient _ticketApiClient;

		public AccountController(FlyBooking.APIClient.IAccountAPIClient accountApiClient, FlyBooking.APIClient.ITicketAPIClient ticketApiClient)
        {
			_accountApiClient = accountApiClient;
			_ticketApiClient = ticketApiClient;
		}

		[AllowAnonymous]
		public IActionResult Index()
        {
            return View();
        }

		[AllowAnonymous]
		public IActionResult login()
        {
            return View();
        }

		[AllowAnonymous]
		public IActionResult CreateNewAccount()
        {
            return View();
        }

        [Authorize(Roles = "Administrator, User")]
        public IActionResult PersonalInfo()
        {
            return View(_accountApiClient.GetUserByID(Convert.ToInt32(User.FindFirst("id")?.Value)));
		}

		[Authorize(Roles = "Administrator, User")]
		public IActionResult ViewTickets()
		{
			return View(_ticketApiClient.GetAllTicketsFromUser(Convert.ToInt32(User.FindFirst("id")?.Value)));
		}

		[AllowAnonymous]
        [HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateNewAccount(Account account)
		{
			if (ModelState.IsValid)
			{
				//Temp values-------------------------------
				account.AccountId = 1;
				account.PersonId = 3;

				int accId = _accountApiClient.AddAccount(account);
				return View("Login");
			}
			else
			{
				return View(account);
			}
		}

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {
            bool isValid = _accountApiClient.LoginAccount(password, username);
            if (isValid)
            {
                Account account = _accountApiClient.GetUserByLogin(password, username);
                await SignIn(account);
                return RedirectToAction("", "");
            }
            else
            {
                ModelState.AddModelError("", "Invalid credentials.");
                return View();
            }
        }

        private async Task SignIn(Account account)
        {
            var claims = new List<Claim>
        {
            new Claim("id",account.AccountId.ToString()),
            new Claim(ClaimTypes.Name, account.UserName),
            new Claim(ClaimTypes.Role, account.Role.ToString()),
        };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
                authProperties);

            TempData["Message"] = $"You are logged in as {claimsIdentity.Name}";
        }

        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["Message"] = "Signed out";
            return View("Logout");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
