using System;
using System.Collections.Generic;
using System.Data;
using TopShop.Models;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace TopShop.Repository.SellersRepository
{
    public class MsSqlSellerRepository : ISellerRepository
    {
        private readonly string _connectionString = @"Data Source=DESKTOP-ERULHJ1;Initial Catalog=TopShop;Integrated Security=True";


        public void Insert(Seller seller)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"INSERT INTO Seller(FullName,PhoneNumber,UserPassword) VALUES ('{seller.FullName}','{seller.PhoneNumber}','{seller.Password}');", connection);
                command.ExecuteNonQuery();
            }
        }
        public void Update(Seller seller, int ID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"UPDATE Seller SET FullName = '{seller.FullName}',PhoneNumber = '{seller.PhoneNumber}', UserPassword = '{seller.Password}' WHERE ID = {ID};", connection);
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int ID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"DELETE Seller WHERE ID = {ID};", connection);
                command.ExecuteNonQuery();
            }
        }
        public List<Seller> GetAll()
        {
            List<Seller> sellers = new List<Seller>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand($"SELECT * FROM Seller;", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Seller seller = new Seller()
                        {
                            Id = (int)reader["ID"],
                            FullName = (string)reader.GetValue(1),
                            PhoneNumber = (string)reader.GetValue(2),
                            Password = (string)reader.GetValue(3)
                        };

                        sellers.Add(seller);
                    }
                }

                reader.Close();
            }
            return sellers;
        }
        public void EmptyMethod() { }
    }
}
