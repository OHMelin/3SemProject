using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL.Exceptions
{
	public class SeatBookedException : Exception
	{
		public SeatBookedException() { }

		public SeatBookedException(Booking booking) : base($"Seat Booked Exception: Seat with id {booking.ticket.SeatID} on Flight with id {booking.FlightID} could not be booked by account with id {booking.AccountID} since it is already booked.") { }

		public SeatBookedException(Booking booking, Exception inner) : base($"Seat Booked Exception: Seat with id {booking.ticket.SeatID} on Flight with id {booking.FlightID} could not be booked by account with id {booking.AccountID} since it is already booked.", inner) { }

		public override string Message => "Seat Booked Exception: The seat could not be booked since it is already booked.";

		public override string? HelpLink
		{
			get
			{
				return "Get more information here: https://github.com/AndreasAhlbeck/UCN3-FlyBooking";
			}
		}
	}
}
