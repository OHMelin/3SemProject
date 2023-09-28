using ClassLibraryModelLayer;
using FlyBooking.Model;
using System.Data.SqlClient;

namespace FlyBooking.DAL
{
    public class FlightDataAccess : IFlightDataAccess
    {
        private readonly string connectionString;

        //add flight commands
        private static readonly string insertFlightCommand = "INSERT INTO Flight (DepartureDate, ArrivalDate, PlaneID, DestinationID) VALUES (@DepartureDate, @ArrivalDate, @PlaneID, @DestinationID); SELECT CAST(scope_identity() AS int);";
        private static readonly string insertPriceCommand = "INSERT INTO FlightPrice (FlightID, PriceDate, Price) VALUES (@PriceFlightID, @PriceDate, @Price)";
        //delete flight commands
        private static readonly string deleteFlightCommand = "DELETE FROM Flight WHERE FlightID = @FlightID";
        private static readonly string deletePriceCommand = "DELETE FROM FlightPrice WHERE FlightID = @FlightPriceFlightID";
        //get all flights command
        private static readonly string getAllFlightsCommand = "SELECT Flight.FlightID, Flight.DepartureDate, Flight.ArrivalDate, Flight.DestinationID, Flight.PlaneID, Destination.AirportID, Destination.City, Plane.PlaneModelID, PlaneModel.ModelName, FlightPrice.FlightPriceID, FlightPrice.Price, FlightPrice.PriceDate FROM Flight INNER JOIN Destination ON Flight.DestinationID = Destination.DestinationID INNER JOIN Plane ON Flight.PlaneID = Plane.PlaneID INNER JOIN PlaneModel ON Plane.PlaneModelID = PlaneModel.PlaneModelID LEFT JOIN FlightPrice ON FlightPrice.FlightID = Flight.FlightID AND FlightPrice.FlightPriceID = (SELECT TOP 1 FlightPrice.FlightPriceID FROM FlightPrice WHERE FlightPrice.FlightID = Flight.FlightID ORDER BY FlightPrice.PriceDate DESC)";
        //get flights by account id command
        private static readonly string getFlightsByAccountIDCommand = "SELECT * FROM Flight INNER JOIN Booking ON Booking.FlightID = Flight.FlightID INNER JOIN Account ON Booking.AccountID = Account.AccountID WHERE Account.AccountID = @accountId";
        //get flight by id command
        private static readonly string getFlightByIDCommand = "SELECT Flight.FlightID, Flight.DepartureDate, Flight.ArrivalDate, Flight.DestinationID, Flight.PlaneID, Destination.AirportID, Destination.City, Plane.PlaneModelID, PlaneModel.ModelName, FlightPrice.FlightPriceID, FlightPrice.Price, FlightPrice.PriceDate FROM Flight INNER JOIN Destination ON Flight.DestinationID = Destination.DestinationID INNER JOIN Plane ON Flight.PlaneID = Plane.PlaneID INNER JOIN PlaneModel ON Plane.PlaneModelID = PlaneModel.PlaneModelID LEFT JOIN FlightPrice ON FlightPrice.FlightID = Flight.FlightID AND FlightPrice.FlightPriceID = (SELECT TOP 1 FlightPrice.FlightPriceID FROM FlightPrice WHERE FlightPrice.FlightID = Flight.FlightID ORDER BY FlightPrice.PriceDate DESC) WHERE Flight.FlightID = @FlightID;";
        //update flight command
        private static readonly string checkForBookingsCommand = "IF EXISTS(SELECT Booking.BookingID FROM Booking WHERE Booking.FlightID = @bookingFlightID) SELECT Flight.PlaneID FROM Flight WHERE Flight.FlightID = @bookingFlightID ELSE SELECT -1";
        private static readonly string updateFlightCommand = "UPDATE Flight SET DepartureDate=@DepartureDate, ArrivalDate=@ArrivalDate, PlaneID=@PlaneID, DestinationID=@DestinationID WHERE FlightID=@FlightID;";


        public FlightDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int AddFlight(Flight flight) 
        {
            int result = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction;
                SqlCommand command;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    command = new SqlCommand(insertFlightCommand, connection);
                }
                catch (Exception e)
                {
                    throw new Exceptions.AccessException("AddFlight", e);
                }
             
                command.Transaction = transaction;
                try
                {
                    command.Parameters.AddWithValue("@DepartureDate", flight.DepartureDate);
                    command.Parameters.AddWithValue("@ArrivalDate", flight.ArrivalDate);
                    command.Parameters.AddWithValue("@PlaneID", flight.PlaneId);
                    command.Parameters.AddWithValue("@DestinationID", flight.DestinationId);
                    result = (int)command.ExecuteScalar(); //Add flight

                    command.CommandText = insertPriceCommand;
                    command.Parameters.AddWithValue("@PriceFlightID", result);
                    command.Parameters.AddWithValue("@PriceDate", flight.Price.PriceDate);
                    command.Parameters.AddWithValue("@Price", flight.Price.Price);
                    command.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (Exception e)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (SqlException e2)
                    {
                        throw new Exceptions.RollbackException("AddFlight", e2);
                    }
                    throw new Exceptions.CommitException("Insert", "AddFlight", e);
                }
                return result;
            }

        }
        public bool DeleteFlight(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction;
                SqlCommand command;
                try 
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    command = new SqlCommand(deletePriceCommand, connection);
                }
                catch (Exception e)
                {
                    throw new Exceptions.AccessException("DeleteFlight", e);
                }
                
                command.Transaction = transaction;

                try
                {
                    command.Parameters.AddWithValue("@FlightPriceFlightID", id);
                    command.ExecuteNonQuery();

                    command.CommandText = deleteFlightCommand;
                    command.Parameters.AddWithValue("@FlightID", id);
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
                    catch (Exception e2)
                    {
                        throw new Exceptions.RollbackException("DeleteFlight", e2);
                    }

                    throw new Exceptions.CommitException("Delete", "DeleteFlight", e);
                }
            }
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            List<Flight> flights = new List<Flight>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command;
                try
                {
                    connection.Open();
                    command = new SqlCommand(getAllFlightsCommand, connection);
                }
                catch (Exception e)
                {
                    throw new Exceptions.AccessException("GetAllFlights", e);
                }

                try 
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Flight flight = DataReaderRowToFlight(reader);
                        flights.Add(flight);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    throw new Exceptions.CommitException("Get", "GetAllFlights", e);
                }
            }
            return flights;
        }
        public IEnumerable<Flight> GetFlightByAccountID(int accountId)
        {
            List<Flight> flights = new List<Flight>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command;
                try
                {
                    connection.Open();
                    command = new SqlCommand(getFlightsByAccountIDCommand, connection);
                }
                catch (Exception e)
                {
                    throw new Exceptions.AccessException("GetFlightByAccountID", e);
                }

                try
                {
                    command.Parameters.AddWithValue("@accountId", accountId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Flight flight = DataReaderRowToFlight(reader);
                        flights.Add(flight);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    throw new Exceptions.CommitException("Get", "GetFlightByAccountID", e);
                }
            }
            return flights;
        }

        public Flight GetFlightById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command;
                try
                {
                    connection.Open();
                    command = new SqlCommand(getFlightByIDCommand, connection);
                }
                catch (Exception e)
                {
                    throw new Exceptions.AccessException("GetFlightByID", e);
                }

                try
                {
                    command.Parameters.AddWithValue("@FlightID", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return DataReaderRowToFlight(reader);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    throw new Exceptions.CommitException("Get", "GetFlightById", e);
                }
            }
        }

        public bool UpdateFlight(Flight flight)
        {
            int planeID = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction;
                SqlCommand command;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    command = new SqlCommand(checkForBookingsCommand, connection);
                }
                catch (Exception e)
                {
                    throw new Exceptions.AccessException("UpdateFlight", e);
                }

                command.Transaction = transaction;
                try
                {
                    command.Parameters.AddWithValue("@bookingFlightID", flight.FlightId);
                    planeID = (int)command.ExecuteScalar();
                    flight.PlaneId = planeID == -1 ? flight.PlaneId : planeID;

                    if (flight.Price.FlightPriceID == null) //only update if new price
                    {
                        command.CommandText = insertPriceCommand;
                        command.Parameters.AddWithValue("@PriceFlightID", flight.FlightId);
                        command.Parameters.AddWithValue("@PriceDate", flight.Price.PriceDate);
                        command.Parameters.AddWithValue("@Price", flight.Price.Price);
                        command.ExecuteNonQuery(); //add new price
                    }

                    command.CommandText = updateFlightCommand;
                    command.Parameters.AddWithValue("@FlightID", flight.FlightId);
                    command.Parameters.AddWithValue("@DepartureDate", flight.DepartureDate);
                    command.Parameters.AddWithValue("@ArrivalDate", flight.ArrivalDate);
                    command.Parameters.AddWithValue("@PlaneID", flight.PlaneId);
                    command.Parameters.AddWithValue("@DestinationID", flight.DestinationId);

                    command.ExecuteNonQuery(); //Update flight

                    transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception e2)
                    {
                        throw new Exceptions.RollbackException("UpdateFlight", e2);
                    }
                    throw new Exceptions.CommitException("Update", "UpdateFlight", e);
                }
            }
        }

        //Helper methods 
        protected Flight DataReaderRowToFlight(SqlDataReader reader)
        {
            Flight flight = new Flight();
            flight.FlightId = (int)reader["FlightID"];
            flight.DepartureDate = (DateTime)reader["DepartureDate"];
            flight.ArrivalDate = (DateTime)reader["ArrivalDate"];
            flight.PlaneId = (int)reader["PlaneID"];
            flight.DestinationId = (int)reader["DestinationID"];

            Destination destination = new Destination()
            {
                DestinationID = flight.DestinationId,
                AirportID = (int)reader["AirportID"],
                City = (string)reader["City"]
            };
            flight.Destination = destination;

            PlaneModel planeModel = new PlaneModel()
            {
                PlaneModelID = (int)reader["PlaneModelID"],
                ModelName = (string)reader["ModelName"]
            };

            Plane plane = new Plane()
            {
                PlaneID = flight.PlaneId,
                PlaneModel = planeModel
            };
            flight.Plane = plane;

            FlightPrice price = new FlightPrice()
            {
                FlightPriceID = (int)reader["FlightPriceID"],
                FlightId = flight.FlightId,
                Price = (int)reader["Price"],
                PriceDate = (DateTime)reader["PriceDate"]
            };
            flight.Price = price;

            return flight;
        }
    }
}