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
    internal class UserAccountModel
    {
        private string connectionString;
        public UserAccountModel(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void getAllData()
        {
            try
            {
                DataStructure<UserAccountDTO>.Instance.Clear();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "SELECT * FROM LoginDetails";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserAccountDTO structure = new UserAccountDTO(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                                DataStructure<UserAccountDTO>.Instance.Add(structure);
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
        public void Add(UserAccountDTO UserAccount)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "INSERT INTO LoginDetails (ID, UserName, Password)" +
                        " VALUES (@ID, @UserName, @Password)";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", UserAccount.ID);
                        command.Parameters.AddWithValue("@UserName", UserAccount.UserName);
                        command.Parameters.AddWithValue("@Password", UserAccount.Password);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void Delete(UserAccountDTO UserAccount)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "DELETE FROM LoginDetails WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", UserAccount.ID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void Update(UserAccountDTO UserAccount)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "UPDATE LoginDetails SET UserName = @Name, Password = @Password WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", UserAccount.ID);
                        command.Parameters.AddWithValue("@Name", UserAccount.UserName);
                        command.Parameters.AddWithValue("@Password", UserAccount.Password);
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
