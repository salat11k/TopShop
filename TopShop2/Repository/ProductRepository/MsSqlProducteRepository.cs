using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TopShop.Models;
using TopShop.Repository;
using TopShop2.Models;

namespace TopShop2.Repository.ProductRepository
{
    public class MsSqlProducteRepository : IRepository<Product>
    {
        private readonly string _connectionString = @"Data Source=DESKTOP-ERULHJ1;Initial Catalog=TopShop;Integrated Security=True";
        private int _sellerID;

        public MsSqlProducteRepository(int sellerID)
        {
            _sellerID = sellerID;
        }


        public void Insert(Product item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO Product(Title,Price,SellerId) VALUES ('{item.Title}','{item.Price}','{item.SellerID}');", connection);
                command.ExecuteNonQuery();
            }
        }
        public void Update(Product item, int ID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"UPDATE Product SET Title = '{item.Title}',Price = '{item.Price}', SellerID = {item.SellerID}' WHERE ID = {ID};", connection);
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int ID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"DELETE Product WHERE ID = {ID};", connection);
                command.ExecuteNonQuery();
            }
        }
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand($"SELECT * FROM Product WHERE SellerID = {_sellerID};", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product product = new Product()
                        {
                            Id = (int)reader["ID"],
                            Title = (string)reader.GetValue(1),
                            Price = (int)reader.GetValue(2),
                        };

                        products.Add(product);
                    }
                }

                reader.Close();
            }
            return products;
        }
    }
}
