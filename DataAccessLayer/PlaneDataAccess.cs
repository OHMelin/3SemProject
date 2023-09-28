using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL
{
    public class PlaneDataAccess : IPlaneDataAccess
    {
        private static readonly string getAllPlanesCommand = "SELECT Plane.PlaneID, Plane.PlaneModelID, PlaneModel.ModelName FROM Plane JOIN PlaneModel ON Plane.PlaneModelID = PlaneModel.PlaneModelID";

		private readonly string connectionString;
        public PlaneDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Plane> GetAllPlanes()
        {
            
            List<Plane> result = new List<Plane>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
				SqlCommand command;
				try
				{
					connection.Open();
					command = new SqlCommand(getAllPlanesCommand, connection);
				}
				catch (Exception e)
				{
					throw new Exceptions.AccessException("GetAllPlanes", e);
				}

				try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(DataReaderRowToPlane(reader));
                    }
                    return result;
                }
                catch (Exception e)
                {
                    throw new Exceptions.CommitException("Get", "GetAllPlanes", e);
                }
            }
        }

        //Helper method
        private Plane DataReaderRowToPlane(SqlDataReader reader)
        {
            PlaneModel planeModel = new PlaneModel()
            {
                PlaneModelID = (int)reader["PlaneModelID"],
                ModelName = (string)reader["ModelName"]
            };

            return new Plane()
            {
                PlaneID = (int)reader["PlaneID"],
                PlaneModel = planeModel
            };
        }
    }
}
