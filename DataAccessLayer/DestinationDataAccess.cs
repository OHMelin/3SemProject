using ClassLibraryModelLayer;
using FlyBooking.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL
{
    public class DestinationDataAccess : IDestinationDataAccess
    {
        private static readonly string getAllDestinationsCommand = "SELECT DestinationID, AirportID, City FROM Destination";

		private readonly string connectionString;
        public DestinationDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Destination> GetAllDestinations()
        {
            List<Destination> result = new List<Destination>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
				SqlCommand command;
				try
				{
					connection.Open();
					command = new SqlCommand(getAllDestinationsCommand, connection);
				}
				catch (Exception e)
				{
					throw new Exceptions.AccessException("GetAllDestinations", e);
				}

				try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(DataReaderRowToDestination(reader));
                    }
                    return result;
                }
                catch (Exception e)
                {
                    throw new Exceptions.CommitException("Get", "GetAllDestinations", e);
                }
            }
        }

        //helper method
        private Destination DataReaderRowToDestination(SqlDataReader reader)
        {
            return new Destination()
            {
                DestinationID = (int)reader["DestinationID"],
                AirportID = (int)reader["AirportID"],
                City = (string)reader["City"]
            };
        }
    }
}
