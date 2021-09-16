﻿using System;
using System.Collections.Generic;
using System.Text;
using Dal.Entities;
using System.Data.SqlClient;

namespace Dal.Services
{
    public class ContactService
    {
        private string _connectionString = @"Data Source=DESKTOP-RGPQP6I\TFTIC2014;Initial Catalog=NetAzureContact;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<Contact> GetContactByUserId(int UserId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "SELECT * FROM Contact WHERE UserId = @Id";

                    cmd.Parameters.AddWithValue("Id", UserId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Contact
                            {
                                Id = (int)reader["Id"],
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                Telephone = reader["Telephone"].ToString()
                            };
                        }
                    }
                }
            }
        }

        public void Insert(Contact c)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "INSERT INTO Contact (LastName, FirstName, Telephone) " +
                        "VALUES (@LastName, @FirstName, @Telephone)";

                    cmd.Parameters.AddWithValue("LastName", c.LastName);
                    cmd.Parameters.AddWithValue("FirstName", c.FirstName);
                    cmd.Parameters.AddWithValue("Telephone", c.Telephone);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
