using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using PBL3_Coffee_Shop_Management_System.DTO;

namespace PBL3_Coffee_Shop_Management_System.Models
{
    internal class ProductModel : IModel
    {
        private string connectionString;
        public ProductModel(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void getAllData()
        {
            try
            {
                DataStructure<ProductDTO>.Instance.Clear();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "SELECT * FROM Product";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductDTO structure = new ProductDTO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4));
                                DataStructure<ProductDTO>.Instance.Add(structure);
                            }
                        }
                    }  
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void Add(ProductDTO product)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "INSERT INTO Product (ID, Name, SellPrice, Unit, TypeID) VALUES (@ID, @Name, @Price, @Unit, @TypeID)";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", product.ID);
                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@Unit", product.Unit);
                        command.Parameters.AddWithValue("@TypeID", product.Type);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void Delete(ProductDTO product)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "DELETE FROM Product WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", product.ID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void Update(ProductDTO product)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "UPDATE Product SET Name = @Name, SellPrice = @Price, Unit = @Unit, TypeID = @TypeID WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", product.ID);
                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@Unit", product.Unit);
                        command.Parameters.AddWithValue("@TypeID", product.Type);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
