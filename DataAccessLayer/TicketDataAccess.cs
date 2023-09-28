using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL
{
	public class TicketDataAccess : ITicketDataAccess
	{
		private readonly string connectionString;

		//GetAllTicketsFromUser command
		private static readonly string getAllTicketsWhereUserIDCommand =
			"SELECT Ticket.TicketID, Ticket.BookingID, Ticket.PersonID, Ticket.SeatID, Seat.SeatRow, Seat.SeatColumn, Seat.PlaneModelID " +
			"FROM Ticket " +
			"JOIN Seat ON Seat.SeatID = Ticket.SeatID " +
			"JOIN Booking ON Booking.BookingID = Ticket.BookingID " +
			"WHERE Booking.AccountID=@id";

		public TicketDataAccess(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public IEnumerable<Ticket> GetAllTicketsFromUser(int id)
		{
			List<Ticket> tickets = new List<Ticket>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command;
				try
				{
					connection.Open();
					command = new SqlCommand(getAllTicketsWhereUserIDCommand, connection);
				}
				catch (Exception e)
				{
					throw new Exceptions.AccessException("GetAllTicketsFromUser", e);
				}

				try
				{
					command.Parameters.AddWithValue("@id", id);
					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						Ticket ticket = DataReaderRowToTickets(reader);
						tickets.Add(ticket);
					}
					reader.Close();
				}
				catch (Exception e)
				{
					throw new Exceptions.CommitException("Get", "GetAllTicketsFromUser", e);
				}

				return tickets;
			}
		}

		private Ticket DataReaderRowToTickets(SqlDataReader reader)
		{
			Seat seat = new Seat()
			{
				SeatID = (int)reader["SeatID"],
				SeatColumn = (string)reader["SeatColumn"],
				SeatRow = (int)reader["SeatRow"],
				PlaneModelID = (int)reader["PlaneModelID"]
			};
			Ticket ticket = new Ticket();
			ticket.TicketID = (int)reader["TicketID"];
			ticket.PersonID = (int)reader["PersonID"];
			ticket.SeatID = seat.SeatID;
			ticket.seat = seat;
			ticket.BookingID = (int)reader["BookingID"];
			return ticket;
		}
	}
}