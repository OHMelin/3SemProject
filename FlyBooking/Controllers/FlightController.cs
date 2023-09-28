using ClassLibraryModelLayer;
using Microsoft.AspNetCore.Mvc;
using FlyBooking.APIClient;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.AspNetCore.Authorization;

namespace FlyBookingMVC.Controllers
{
	public class FlightController : Controller
	{
		private readonly FlyBooking.APIClient.IFlightAPIClient _apiClientFlight;
        private readonly FlyBooking.APIClient.IDestinationAPIClient _apiClientDestination;
        private readonly FlyBooking.APIClient.ISeatAPIClient _apiClientSeat;
        private readonly FlyBooking.APIClient.IPlaneAPIClient _apiClientPlane;

        public FlightController(	FlyBooking.APIClient.IFlightAPIClient apiClientFlight, 
									FlyBooking.APIClient.IDestinationAPIClient apiClientDestination,
									FlyBooking.APIClient.ISeatAPIClient apiClientSeat,
									FlyBooking.APIClient.IPlaneAPIClient apiClientPlane)
		{
			_apiClientFlight = apiClientFlight;
			_apiClientDestination = apiClientDestination;
			_apiClientSeat = apiClientSeat;
			_apiClientPlane = apiClientPlane;
		}

		public IActionResult Index()
		{
			return View();
		}


        [AllowAnonymous]
        public IActionResult FlightList() 
		{ 
			return View(_apiClientFlight.GetAllFlights());
		}

        [Authorize(Roles = "Administrator, User")]
        public IActionResult FlightSeatBooking(int planeID, int flightID)
        {
			//PlaneId & FlightID & SeatID
			//Ticket skal være hardcoded med et personID
			return View(_apiClientSeat.GetAvailableSeatsWhereFlightId(flightID));
            //return View(_apiClientFlight.GetAvailableSeatsWhereFlightId(flightID));
        }

    }
}
