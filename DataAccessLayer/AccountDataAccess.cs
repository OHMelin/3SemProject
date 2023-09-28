	using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Principal;

namespace FlyBooking.DAL
{
	public class AccountDataAccess : IAccountDataAccess
	{
		//Add account
		private static readonly string InsertAccountCommandText = "INSERT INTO Account (PersonID, Username, HashedPassword, IsAdmin) VALUES (@PersonID, @Username, @HashedPassword, @IsAdmin); SELECT CAST(scope_identity() AS int);";
		//Login account
		private static readonly string SelectHashedPasswordCommandText = "SELECT HashedPassword FROM Account WHERE Username = @Username";
		//Get User by login
		private static readonly string SelectAccountCommandText = "SELECT * FROM Account WHERE Username = @Username";
		//Get user by id
		private static readonly string SelectAccountFromIDCommandText = "SELECT * FROM Account WHERE AccountID = @AccountID";

		private readonly string _connectionString;

		public AccountDataAccess(string connectionString)
		{
			this._connectionString = connectionString;
		}

		public int AddAccount(Account account)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command;
				try
				{
					connection.Open();
					command = new SqlCommand(InsertAccountCommandText, connection);
				}
				catch (Exception e)
				{
					throw new Exceptions.AccessException("AddAccount", e);
				}

				command.Parameters.AddWithValue("@PersonID", account.PersonId);
				command.Parameters.AddWithValue("@Username", account.UserName);
				command.Parameters.AddWithValue("@HashedPassword", BCryptTool.HashPassword(account.Password));
				command.Parameters.AddWithValue("@IsAdmin", account.IsAdmin);

				try
				{
					int newID = (int)command.ExecuteScalar();
					return newID;
				}
				catch (Exception e)
				{
					throw new Exceptions.CommitException("Insert", "AddAccount", e);
				}
			}
		}

		public bool LoginAccount(string password, string username)
		{
			
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command;
				try
				{
					connection.Open();
					command = new SqlCommand(SelectHashedPasswordCommandText, connection);
				}
				catch (Exception e)
				{
					throw new Exceptions.AccessException("LoginAccount", e);
				}

				try
				{
					command.Parameters.AddWithValue("@Username", username);
					string storedPassword = (string)command.ExecuteScalar();
					return BCryptTool.ValidatePassword(password, storedPassword);

				}
				catch (Exception e)
				{
					throw new Exceptions.CommitException("Get", "LoginAccount", e);
				}
			}
		}

		public Account GetUserByLogin(string password, string username)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command;
				try
				{
					connection.Open();
					command = new SqlCommand(SelectAccountCommandText, connection);
				}
				catch (Exception e)
				{
					throw new Exceptions.AccessException("GetUserByLogin", e);
				}
				
				try
				{
					command.Parameters.AddWithValue("@Username", username);
					SqlDataReader reader = command.ExecuteReader();

					if (reader.Read())
					{
						string storedPassword = reader.GetString(reader.GetOrdinal("HashedPassword"));
						if (BCryptTool.ValidatePassword(password, storedPassword))
						{
							return DataReaderRowToAccount(reader);
						}
						else
						{
							return null;
						}
					}
					else
					{
						return null;
					}

				}
				catch (Exception e)
				{
					throw new Exceptions.CommitException("Get", "GetUserByLogin", e);
				}
			}
		}
        public Account GetUserByID(int id) 
		{
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
				SqlCommand command;
				try
				{
					connection.Open();
					command = new SqlCommand(SelectAccountFromIDCommandText, connection);
				}
				catch (Exception e)
				{
					throw new Exceptions.AccessException("GetUserByID", e);
				}
				
                try
                {
					command.Parameters.AddWithValue("@AccountID", id);
					SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return DataReaderRowToAccount(reader);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
					throw new Exceptions.CommitException("Get", "GetUserByID", e);
                }
            }
        }

        protected Account DataReaderRowToAccount(SqlDataReader reader)
		{
			Account account = new Account();
			account.AccountId = (int)reader["AccountID"];
			account.PersonId = (int)reader["PersonID"];
			account.UserName = (string)reader["Username"];
			account.Password = (string)reader["HashedPassword"];
			account.IsAdmin = (bool)reader["IsAdmin"];
			return account;
		}
    }
}