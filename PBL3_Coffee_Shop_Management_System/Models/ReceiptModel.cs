using MySql.Data.MySqlClient;
using PBL3_Coffee_Shop_Management_System.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_Coffee_Shop_Management_System.Models
{
    internal class ReceiptModel
    {
        private string connectionString;
        public ReceiptModel(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void getAllData()
        {
            try
            {
                DataStructure<ReceiptDTO>.Instance.Clear();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "SELECT * FROM Receipt";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                List<ProductDTO> products = new List<ProductDTO>();
                                List<int> Quantity = new List<int>();
                                List<int> Total = new List<int>();
                                string sql1 = "SELECT * FROM ReceiptDetails WHERE ID = @ID";
                                using (MySqlCommand command1 = new MySqlCommand(sql1, connection))
                                {
                                    command1.Parameters.AddWithValue("@ID", reader.GetString(0));
                                    using (MySqlDataReader reader1 = command1.ExecuteReader())
                                    {
                                        ProductModel productModel = new ProductModel(connectionString);
                                        
                                        while (reader1.Read())
                                        {
                                            products.Add(productModel.Find(reader1.GetString(1)));
                                            Quantity.Add(reader.GetInt32(2));
                                            Total.Add(reader.GetInt32(3));
                                        }
                                    }
                                }
                                ReceiptDTO structure = new ReceiptDTO(reader.GetString(0), reader.GetDateTime(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));
                                structure.Products = products;
                                structure.Quantity = Quantity;
                                structure.Total = Total;
                                DataStructure<ReceiptDTO>.Instance.Add(structure);
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
        public void Add(ReceiptDTO receipt)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "INSERT INTO Receipt (ID, TransactionTime, EmployeeID, CustomerID, TableNum, Discount) " +
                        "VALUES (@ID, @TransactionTime, @EmployeeID, @CustomerID, @TableNum, @Discount)";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", receipt.ReceiptID);
                        command.Parameters.AddWithValue("@TransactionTime", receipt.TransactionTime);
                        command.Parameters.AddWithValue("@EmployeeID", receipt.EmployeeID);
                        command.Parameters.AddWithValue("@CustomerID", receipt.CustomerID);
                        command.Parameters.AddWithValue("@TableNum", receipt.TableNum);
                        command.Parameters.AddWithValue("@Discount", receipt.Discount);
                        command.ExecuteNonQuery();
                    }
                    sql = "INSERT INTO ReceiptDetails (ReceiptID, ProductID, Quantity, Total) VALUES (@ID, @ProductID, @Quantity, @Total)";
                    int index = 0;
                    foreach(ProductDTO p in receipt.Products)
                    {
                        using (MySqlCommand command = new MySqlCommand(sql, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@ID", receipt.ReceiptID);
                            command.Parameters.AddWithValue("@ProductID", p.ID);
                            command.Parameters.AddWithValue("@Quantity", receipt.Quantity[index]);
                            command.Parameters.AddWithValue("@Total", receipt.Total[index++]);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void Delete(ReceiptDTO receipt)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "DELETE FROM Receipt WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", receipt.ReceiptID);
                        command.ExecuteNonQuery();
                    }
                    sql = "DELETE FROM ReceiptDetails WHERE ReceiptID = @ID";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", receipt.ReceiptID);
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
