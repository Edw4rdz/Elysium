using Elysium;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElysiumData
{
    public class SqlDBData
        {
            string connectionString
               = "Data Source =LAPTOP-VESUE4DG\\SQLEXPRESS01; Initial Catalog = Elysium; Integrated Security = True;";
            SqlConnection sqlConnection;

            public SqlDBData()
            {
                sqlConnection = new SqlConnection(connectionString);
            }


            public List<User> GetUsers()
            {
                string selectStatement = "SELECT username, password, email, balance FROM Users";

                SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

                sqlConnection.Open();
                List<User> users = new List<User>();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    string username = reader["username"].ToString();
                    string password = reader["password"].ToString();
                    string email = reader["email"].ToString();
                    string balance = reader["balance"].ToString();

                    User readUser = new User();
                    readUser.username = username;
                    readUser.password = password;
                    readUser.email = email;
                    readUser.balance = balance;

                users.Add(readUser);
                }

                sqlConnection.Close();

                return users;
            }

            public int AddUser(string username, string password, string email, string balance)
            {
                int success;

                string insertStatement = "INSERT INTO users VALUES (@username, @password, @email, @balance )";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

                insertCommand.Parameters.AddWithValue("@username", username);
                insertCommand.Parameters.AddWithValue("@password", password);
                insertCommand.Parameters.AddWithValue("@email", email);
                insertCommand.Parameters.AddWithValue("@balance", balance);
                sqlConnection.Open();

                success = insertCommand.ExecuteNonQuery();

                sqlConnection.Close();

                return success;
            }

            public int UpdateUser(string username, string password, string email, string balance)
            {
                int success;

                string updateStatement = $"UPDATE users SET password = @Password WHERE username = @username @email = email";
                SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
                sqlConnection.Open();

                updateCommand.Parameters.AddWithValue("@Password", password);
                updateCommand.Parameters.AddWithValue("@username", username);
                updateCommand.Parameters.AddWithValue("@email", email);
                updateCommand.Parameters.AddWithValue("balance", balance);

                success = updateCommand.ExecuteNonQuery();

                sqlConnection.Close();

                return success;
            }

            public int DeleteUser(string username)
            {
                int success;

                string deleteStatement = $"DELETE FROM users WHERE username = @username";
                SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
                sqlConnection.Open();

                deleteCommand.Parameters.AddWithValue("@username", username);

                success = deleteCommand.ExecuteNonQuery();

                sqlConnection.Close();

                return success;
            }
        }
    }