using ClassLibraryModelLayer;
using FlyBooking.DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL
{
    public class BookingDataAccess : IBookingDataAccess
    {
        //add booking command
        private static readonly string checkSeatAvailableCommandText = "IF EXISTS(SELECT DISTINCT Booking.BookingID, Booking.BookingDate, Booking.FlightID, Ticket.SeatID FROM Ticket " +
													"JOIN Booking ON Booking.BookingID = Ticket.BookingID " +
													"WHERE Booking.FlightID = @checkFlightID AND Ticket.SeatID = @checkSeatID) " +
													"SELECT 1 " + //1 = the seat is already booked
													"ELSE SELECT 0"; //0 = the seat have not been booked
		private static readonly string paymentCommandText = "INSERT INTO Payment (PaymentDate, Price) SELECT @paymentDate, FlightPrice.Price FROM FlightPrice WHERE FlightPrice.FlightID = @flightPriceFlightID; SELECT CAST(scope_identity() AS int);";
		private static readonly string bookingCommandText = "INSERT INTO Booking (BookingDate, PaymentID, AccountID, FlightID) VALUES (@BookingDate, @PaymentID, @AccountID, @FlightID); SELECT CAST(scope_identity() AS int);";
		private static readonly string ticketCommandText = "INSERT INTO Ticket (PersonID, SeatID, BookingID) VALUES (@PersonID, @SeatID, @BookingID);";
        //get bookings by account id
        private static readonly string getBookingCommand = "SELECT * FROM Booking WHERE AccountID = @accountId";
        //delete booking
        private static readonly string deleteBookingCommand = "DELETE FROM Booking WHERE BookingID= @BookingID";
		private static readonly string deleteTicketCommand = "DELETE FROM Ticket WHERE BookingID = @TicketBookingID";

		private readonly string _connectionString;

        public BookingDataAccess(string connectionString)
        {
            this._connectionString = connectionString;
        }

        SqlTransaction sqlTransaction = null;

        public int AddBooking(Booking booking)
        {
            int bookingId = -1;
            int payemntID = -1;
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
				SqlTransaction transaction;
				SqlCommand command;
				try
				{
					connection.Open();
					transaction = connection.BeginTransaction(System.Data.IsolationLevel.Serializable); //Serializable read isolation level locks all tables used in transaction
					command = new SqlCommand(checkSeatAvailableCommandText, connection);
				}
				catch (Exception e)
				{
					throw new Exceptions.AccessException("AddBooking", e);
				}

				command.Transaction = transaction;

				try
                {
                    command.Parameters.AddWithValue("@checkFlightID", booking.FlightID);
                    command.Parameters.AddWithValue("@checkSeatID", booking.ticket.SeatID);
                    if((int)command.ExecuteScalar() == 1) //booking already exists
                    {
                        throw new Exceptions.SeatBookedException(booking);
                    }
                    else
                    {
                        command.CommandText = paymentCommandText;
                        command.Parameters.AddWithValue("@paymentDate", DateTime.Now);
                        command.Parameters.AddWithValue("@flightPriceFlightID", booking.FlightID);
                        payemntID = (int)command.ExecuteScalar();

                        command.CommandText = bookingCommandText;
                        command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                        command.Parameters.AddWithValue("@PaymentID", payemntID);
                        command.Parameters.AddWithValue("@AccountID", booking.AccountID);
                        command.Parameters.AddWithValue("@FlightID", booking.FlightID);
                        bookingId = (int)command.ExecuteScalar();

                        command.CommandText = ticketCommandText;
                        command.Parameters.AddWithValue("@PersonID", booking.ticket.PersonID);
                        command.Parameters.AddWithValue("@SeatID", booking.ticket.SeatID);
                        command.Parameters.AddWithValue("@BookingID", bookingId);
                        command.ExecuteNonQuery();

                        transaction.Commit();

                        return bookingId;
                    }
                }
                catch (Exception e)
                {
                    try
                    {
						transaction.Rollback();
					}
                    catch(Exception e2)
                    {
                        throw new Exceptions.RollbackException("AddBooking", e2);
                    }

                    if(e is SeatBookedException)
                    {
                        throw e;
                    }
                    else
                    {
						throw new Exceptions.CommitException("Insert", "AddBooking", e);
					}         
                }
            }
        }
        public IEnumerable<Booking> getBookingsByAccountId(int accountId)
        {
            List<Booking> bookings = new List<Booking>();
           
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
				SqlCommand command;
				try
				{
					connection.Open();
					command = new SqlCommand(getBookingCommand, connection);
				}
				catch (Exception e)
				{
					throw new Exceptions.AccessException("getBookingsByAccountId", e);
				}

                try
                {
					command.Parameters.AddWithValue("@accountId", accountId);
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						Booking booking = DataReaderRowToBooking(reader);
						bookings.Add(booking);
					}
					reader.Close();
				}
                catch (Exception e)
                {
                    throw new Exceptions.CommitException("Get", "getBookingsByAccountId", e);
                }
                finally
                {
                    connection.Close();
                }

            }
            return bookings;
        }

        public bool DeleteBooking(int id)
        {
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
				SqlTransaction transaction;
				SqlCommand command;
				try
				{
					connection.Open();
					transaction = connection.BeginTransaction();
					command = new SqlCommand(deleteTicketCommand, connection);
				}
				catch (Exception e)
				{
					throw new Exceptions.AccessException("DeleteBooking", e);
				}

				command.Transaction = transaction;

				try
                {
                    command.Parameters.AddWithValue("@TicketBookingID", id);
                    command.ExecuteNonQuery();

                    command.CommandText = deleteBookingCommand;
                    command.Parameters.AddWithValue("@BookingID", id);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    try
                    {
						transaction.Rollback();
					}
                    catch(Exception e2)
                    {
                        throw new Exceptions.RollbackException("DeleteBooking", e2);
                    }

                    throw new Exceptions.CommitException("Delete", "DeleteBooking", e);
                }
            }
        }
        protected Booking DataReaderRowToBooking(SqlDataReader reader)
        {
            Booking Booking = new Booking();
            Booking.BookingID = (int)reader["BookingID"];
            Booking.BookingDate = (DateTime)reader["BookingDate"];
            Booking.PaymentID = (int)reader["PaymentID"];
            Booking.AccountID = (int)reader["AccountID"];
            Booking.FlightID = (int)reader["FlightID"];
            return Booking;
        }
    }
}

