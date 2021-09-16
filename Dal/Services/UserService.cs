using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dal.Entities;

namespace Dal.Services
{
    public class UserService
    {
        private string _connectionString = @"Data Source=DESKTOP-RGPQP6I\TFTIC2014;Initial Catalog=NetAzureContact;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    
        public void Insert(string Email, string Password, string ScreenName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "AddUser";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Email", Email);
                    cmd.Parameters.AddWithValue("Password", Password);
                    cmd.Parameters.AddWithValue("ScreenName", ScreenName);

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public User Login(string Email, string Password)
        {
            User connecterUser= new User();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "LoginUser";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Email", Email);
                    cmd.Parameters.AddWithValue("Password", Password);

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            connecterUser.Id = (int)reader["Id"];
                            connecterUser.Email = reader["Email"].ToString();
                            connecterUser.ScreenName = reader["ScreenName"].ToString();
                        }
                    }
                }
                return connecterUser;
            }
        }
    }
}
