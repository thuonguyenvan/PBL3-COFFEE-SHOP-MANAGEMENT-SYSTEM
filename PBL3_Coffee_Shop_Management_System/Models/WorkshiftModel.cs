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
    internal class WorkshiftModel
    {
        private string connectionString;
        public WorkshiftModel(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void getAllWorkshiftData()
        {
            try
            {
                DataStructure<WorkshiftDTO>.Instance.Clear();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "SELECT * FROM Workshift";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                WorkshiftDTO structure = new WorkshiftDTO(reader.GetString(0), reader.GetTimeSpan(1), reader.GetTimeSpan(2));
                                DataStructure<WorkshiftDTO>.Instance.Add(structure);
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
        public void getAllShiftDetails(EmployeeDTO employee)
        {
            try
            {
                DataStructure<ShiftDetailsDTO>.Instance.Clear();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "SELECT * FROM ShiftDetails WHERE EmployeeID = @EmployeeID";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@EmployeeID", employee.ID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                WorkshiftDTO workshiftDTO = DataStructure<WorkshiftDTO>.Instance.Find(x => x.ID == reader.GetString(0));
                                EmployeeDTO employeeDTO = DataStructure<EmployeeDTO>.Instance.Find(x => x.ID == reader.GetString(1));
                                ShiftDetailsDTO structure = new ShiftDetailsDTO(employeeDTO, workshiftDTO, reader.GetDateTime(2), reader.GetBoolean(3));
                                DataStructure<ShiftDetailsDTO>.Instance.Add(structure);
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
        public void AddShiftDetails(EmployeeDTO employee, WorkshiftDTO workshift, DateTime Day)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "INSERT INTO ShiftDetails (WorkshiftID, EmployeeID, Day, isCompleted) VALUES (@WorkshiftID, @EmployeeID, @Day, @isCompleted)";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@EmployeeID", employee.ID);
                        command.Parameters.AddWithValue("@WorkshiftID", workshift.ID);
                        command.Parameters.AddWithValue("@Day", Day);
                        command.Parameters.AddWithValue("@isCompleted", 0);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void UpdateShiftDetails(EmployeeDTO employee, WorkshiftDTO workshift, DateTime Day, bool isCompleted)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "UPDATE ShiftDetails SET isCompleted = @isCompleted WHERE WorkshiftID = @WorkshiftID AND EmployeeID = @EmployeeID AND Day = @Day";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@EmployeeID", employee.ID);
                        command.Parameters.AddWithValue("@WorkshiftID", workshift.ID);
                        command.Parameters.AddWithValue("@Day", Day);
                        command.Parameters.AddWithValue("@isCompleted", isCompleted);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void DeleteShiftDetails(EmployeeDTO employee, WorkshiftDTO workshift, DateTime Day)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "DELETE FROM ShiftDetails WHERE WorkshiftID = @WorkshiftID AND EmployeeID = @EmployeeID AND Day = @Day";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@EmployeeID", employee.ID);
                        command.Parameters.AddWithValue("@WorkshiftID", workshift.ID);
                        command.Parameters.AddWithValue("@Day", Day);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void AddWorkshift(WorkshiftDTO workshift)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "INSERT INTO Workshift (ID, StartTime, EndTime) VALUES (@ID, @StartTime, @EndTime)";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", workshift.ID);
                        command.Parameters.AddWithValue("@StartTime", workshift.StartTime);
                        command.Parameters.AddWithValue("@EndTime", workshift.EndTime);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void DeleteWorkshift(WorkshiftDTO workshift)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "DELETE FROM Workshift WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", workshift.ID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void UpdateWorkshift(WorkshiftDTO workshift)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "UPDATE Workshift SET StartTime = @StartTime, EndTime = @EndTime WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ID", workshift.ID);
                        command.Parameters.AddWithValue("@StartTime", workshift.StartTime);
                        command.Parameters.AddWithValue("@EndTime", workshift.EndTime);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public int GetHoursWorked(EmployeeDTO employee, string month)
        {
            try
            {
                int hoursWorked;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "SELECT HoursWorked FROM HoursWorkedInMonth WHERE EmployeeID = @EmployeeID AND Month = @Month";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Month", month);
                        command.Parameters.AddWithValue("@EmployeeID", employee.ID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            hoursWorked = reader.GetInt32(0);
                        }
                    }
                }
                return hoursWorked;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
        }
        public void UpdateHoursWorked(EmployeeDTO employee, WorkshiftDTO workshift, string month)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = "INSERT INTO HoursWorkedInMonth (Month, EmployeeID, HoursWorked) VALUES (@Month, @EmployeeID, @HoursWorked)" +
                        " ON DUPLICATE KEY UPDATE HoursWorked = HoursWorked + @HoursWorked";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Month", month);
                        command.Parameters.AddWithValue("@EmployeeID", employee.ID);
                        command.Parameters.AddWithValue("@HoursWorked", (workshift.EndTime - workshift.StartTime).Hours);
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
