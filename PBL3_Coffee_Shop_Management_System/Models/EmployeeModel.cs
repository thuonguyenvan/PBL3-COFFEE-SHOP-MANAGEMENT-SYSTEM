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
    internal class EmployeeModel : IModel
    {
        private string connectionString;
        public EmployeeModel(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void getAllData()
        {
            try
            {
                DataStructure<EmployeeDTO>.Instance.Clear();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "SELECT * FROM Employee";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeDTO structure = new EmployeeDTO(reader.GetString(0), reader.GetString(1), reader.GetBoolean(2), reader.GetDateTime(3),
                                    reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetBoolean(7));
                                DataStructure<EmployeeDTO>.Instance.Add(structure);
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
        public void Add(EmployeeDTO employee)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "INSERT INTO Employee (ID, Name, Gender, DateOfBirth, Address, PhoneNum, Email, isFullTime)" +
                        "VALUES (@ID, @Name, @Gender, @DateOfBirth, @Address, @PhoneNum, @Email, @isFullTime)";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", employee.ID);
                        command.Parameters.AddWithValue("@Name", employee.Name);
                        command.Parameters.AddWithValue("@Gender", employee.Gender);
                        command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                        command.Parameters.AddWithValue("@Address", employee.Address);
                        command.Parameters.AddWithValue("@PhoneNum", employee.PhoneNum);
                        command.Parameters.AddWithValue("@Email", employee.Email);
                        command.Parameters.AddWithValue("@isFullTime", employee.isFullTime);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void Delete(EmployeeDTO employee)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "DELETE FROM Employee WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", employee.ID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void Update(EmployeeDTO employee)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "UPDATE Employee SET Name = @Name, Gender = @Gender, DateOfBirth = @DateOfBirth, Address = @Address, PhoneNum = @PhoneNum," +
                        " Email = @Email, isFullTime = @isFullTime WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", employee.ID);
                        command.Parameters.AddWithValue("@Name", employee.Name);
                        command.Parameters.AddWithValue("@Gender", employee.Gender);
                        command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                        command.Parameters.AddWithValue("@Address", employee.Address);
                        command.Parameters.AddWithValue("@PhoneNum", employee.PhoneNum);
                        command.Parameters.AddWithValue("@Email", employee.Email);
                        command.Parameters.AddWithValue("@isFullTime", employee.isFullTime);
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
