using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL
{
    public class SeatDataAccess : ISeatDataAccess
    {
        private readonly string connectionString;

        //GetAllFlightSeatsWhereID command
        private static readonly string getAllSeatsWhereFlightIDCommand = "SELECT * FROM Seat INNER JOIN Plane ON Seat.PlaneModelID = Plane.PlaneModelID WHERE Plane.PlaneID=@id;";
        //GetAllAvailableSeatsWhereFlightID command
        private static readonly string getAllAvailableSeatsCommand = "SELECT Seat.SeatID, Seat.SeatRow, Seat.SeatColumn, Seat.PlaneModelID FROM Seat " +
                    "WHERE Seat.SeatID NOT IN " +
                    "(SELECT Ticket.SeatID FROM Ticket JOIN Booking ON Ticket.BookingID = Booking.BookingID WHERE Booking.FlightID = @FlightId) " +
                    "AND Seat.PlaneModelID = (SELECT Plane.PlaneModelID FROM Plane JOIN Flight ON Flight.FlightID = @FlightId WHERE Flight.PlaneID = Plane.PlaneID)";
        private static readonly string getAllUnavailableSeatsCommand = "SELECT Seat.SeatID, Seat.SeatRow, Seat.SeatColumn, Seat.PlaneModelID FROM Seat " +
                    "WHERE Seat.SeatID IN " +
                    "(SELECT Ticket.SeatID FROM Ticket JOIN Booking ON Ticket.BookingID = Booking.BookingID WHERE Booking.FlightID = @UnavailableFlightId) " +
                    "AND Seat.PlaneModelID = (SELECT Plane.PlaneModelID FROM Plane JOIN Flight ON Flight.FlightID = @UnavailableFlightId WHERE Flight.PlaneID = Plane.PlaneID)";

        public SeatDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Seat> GetAllFlightSeatsWhereID(int id)
        {
            List<Seat> seats = new List<Seat>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command;
                try
                {
                    connection.Open();
                    command = new SqlCommand(getAllSeatsWhereFlightIDCommand, connection);
                }
                catch (Exception e)
                {
                    throw new Exceptions.AccessException("GetAllFlightSeatsWhereID", e);
                }

                try
                {
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Seat seat = DataReaderRowToFlightSeats(reader);
                        seats.Add(seat);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    throw new Exceptions.CommitException("Get", "GetAllFlightSeatsWhereID", e);
                }
            }
            return seats;
        }

        public IEnumerable<Seat> GetAllAvailableSeatsWhereFlightID(int FlightId)
        {
            List<Seat> seats = new List<Seat>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {           
                SqlTransaction transaction;
                SqlCommand command;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    command = new SqlCommand(getAllAvailableSeatsCommand, connection);
                }
                catch (Exception e)
                {
                    throw new Exceptions.AccessException("GetAllAvailableSeatsWhereFlightID", e);
                }

                command.Transaction = transaction;

                try
                {
                    command.Parameters.AddWithValue("@FlightId", FlightId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Seat seat = DataReaderRowToFlightSeats(reader);
                        seat.IsBooked = false;
                        seats.Add(seat);
                    }
                    reader.Close();

                    command.CommandText = getAllUnavailableSeatsCommand;
                    command.Parameters.AddWithValue("@UnavailableFlightId", FlightId);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Seat seat = DataReaderRowToFlightSeats(reader);
                        seat.IsBooked = true;
                        seats.Add(seat);
                    }
                    reader.Close();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception e2)
                    {
                        throw new Exceptions.RollbackException("GetAllAvailableSeatsWhereFlightID", e2);
                    }
                    throw new Exceptions.CommitException("Get", "GetAllAvailableSeatsWhereFlightID", e);
                }
            }
            return seats.OrderBy(o=>o.SeatID).ToList();
        }

        //helper methods
        private Seat DataReaderRowToFlightSeats(SqlDataReader reader)
        {
            Seat Seat = new Seat();
            Seat.SeatID = (int)reader["SeatID"];
            Seat.SeatRow = (int)reader["SeatRow"];
            Seat.SeatColumn = (string)reader["SeatColumn"];
            Seat.PlaneModelID = (int)reader["PlaneModelID"];
            return Seat;
        }
    }
}