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
    internal class CustomerModel : IModel
    {
        private string connectionString;
        public CustomerModel(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void getAllData()
        {
            try
            {
                DataStructure<CustomerDTO>.Instance.Clear();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "SELECT * FROM Customer";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerDTO structure = new CustomerDTO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                                DataStructure<CustomerDTO>.Instance.Add(structure);
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
        public void Add(CustomerDTO customer)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "INSERT INTO Customer (ID, Name, PhoneNum, Email, Points) VALUES (@ID, @Name, @PhoneNum, @Email, @Points)";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", customer.ID);
                        command.Parameters.AddWithValue("@Name", customer.Name);
                        command.Parameters.AddWithValue("@PhoneNum", customer.PhoneNum);
                        command.Parameters.AddWithValue("@Email", customer.Email);
                        command.Parameters.AddWithValue("@Points", customer.Points);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void Delete(CustomerDTO customer)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "DELETE FROM Customer WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", customer.ID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void Update(CustomerDTO customer)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "UPDATE Customer SET Name = @Name, PhoneNum = @PhoneNum, Email = @Email, Points = @Points WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", customer.ID);
                        command.Parameters.AddWithValue("@Name", customer.Name);
                        command.Parameters.AddWithValue("@PhoneNum", customer.PhoneNum);
                        command.Parameters.AddWithValue("@Email", customer.Email);
                        command.Parameters.AddWithValue("@Points", customer.Points);
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
