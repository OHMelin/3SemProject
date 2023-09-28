using ClassLibraryModelLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace FlyBooking.MVC.Controllers
{
    public class BookingController : Controller
    {

        private readonly FlyBooking.APIClient.IBookingAPIClient _apiClient;

        public BookingController(FlyBooking.APIClient.IBookingAPIClient apiClient)
        {
            _apiClient = apiClient;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator, User")]
        public IActionResult ViewBookings()
        {
            return View(_apiClient.GetBookingsByAccountID(Convert.ToInt32(User.FindFirst("id")?.Value)));
        }

        [Authorize(Roles = "Administrator, User")]
        public IActionResult CreateBooking(int seatID, int planeModelID, int flightID)
        {
            Console.WriteLine(flightID);
            var ticket = new Ticket
            {
                SeatID = seatID,
                seat = new Seat { PlaneModelID = planeModelID }
            };

            var booking = new Booking
            {
                ticket = ticket,
                FlightID = flightID
            };

            return View(booking);
        }

        [Authorize(Roles = "Administrator, User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBooking(Booking booking)
        {
            //accid
            //flightID
            //personID
            //SeatID

            if (ModelState.IsValid)
            {
                //Booking
                booking.BookingID = 0;
                booking.BookingDate = DateTime.Now;
                booking.PaymentID = 1;
                booking.AccountID = booking.AccountID;

                //Ticket
                booking.ticket = new Ticket() { SeatID = booking.ticket.SeatID, TicketID = 0, BookingID = 0, PersonID = booking.ticket.PersonID};
                int bookingId = _apiClient.AddBooking(booking);
                if(bookingId != -1)
                {
					return View("BookingConfirmed");
				}
                else
                {
                    return View("BookingFailed");
                }
            }
            else
            {
                return View("Error");
            }
        }

        [Authorize(Roles = "Administrator, User")]
        public IActionResult BookingConfirmed()
        {
            return View();
        }

        public IActionResult BookingFailed()
        {
            return View();
        }

    }
}
