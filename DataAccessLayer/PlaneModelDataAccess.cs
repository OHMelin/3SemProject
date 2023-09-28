using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL
{
    public class PlaneModelDataAccess : IPlaneModelDataAccess
    {
        private static readonly string getAllPlaneModelsCommand = "SELECT PlaneModel.PlaneModelID, PlaneModel.ModelName FROM PlaneModel";

		private readonly string connectionString;
        public PlaneModelDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<PlaneModel> GetAllPlaneModels()
        {
            
            List<PlaneModel> result = new List<PlaneModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
				SqlCommand command;
				try
				{
					connection.Open();
					command = new SqlCommand(getAllPlaneModelsCommand, connection);
				}
				catch (Exception e)
				{
					throw new Exceptions.AccessException("GetAllPlaneModels", e);
				}

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(DataReaderRowToPlaneModel(reader));
                    }
                    return result;
                }
                catch (Exception e)
                {
                    throw new Exceptions.CommitException("Get", "GetAllPlaneModels", e);
                }
            }
        }

        //Helper method
        private PlaneModel DataReaderRowToPlaneModel(SqlDataReader reader)
        {
            return new PlaneModel()
            {
                PlaneModelID = (int)reader["PlaneModelID"],
                ModelName = (string)reader["ModelName"]
            };
        }
    }
}
