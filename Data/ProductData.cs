    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;


namespace Data
{
    public class ProductData
    {
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            string connectionString = "Data Source=tuServidor;Initial Catalog=tuBaseDeDatos;User ID=usuario;Password=contraseña";

            string query = "SELECT Product_Id, Name, Price, Stock, Active FROM Products";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductId = Convert.ToInt32(reader["Product_Id"]),
                                Name = reader["Name"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                Active = Convert.ToBoolean(reader["Active"])
                            };
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
    }
}

