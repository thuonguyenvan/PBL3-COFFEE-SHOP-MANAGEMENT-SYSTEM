using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

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
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "SELECT * FROM Table1";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader.GetInt32(0));
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
    }
}
