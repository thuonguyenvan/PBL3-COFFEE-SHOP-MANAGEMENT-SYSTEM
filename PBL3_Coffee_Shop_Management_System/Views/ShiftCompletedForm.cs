using PBL3_Coffee_Shop_Management_System.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_Coffee_Shop_Management_System.EventArguments;

namespace PBL3_Coffee_Shop_Management_System.Views
{
    public partial class ShiftCompletedForm : Form
    {
        DataTable dataTable = new DataTable();
        public ShiftCompletedForm()
        {
            InitializeComponent();
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Nhân viên", typeof(string)),
                new DataColumn("Ca làm", typeof(string)),
                new DataColumn("Ngày", typeof(string))
            });
            for (int i = 0; i < dataTable.Columns.Count; i++)
                dataTable.Columns[i].ReadOnly = true;
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn();
            dataGridViewButtonColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewButtonColumn.Text = "Đã hoàn thành";
            dataGridViewButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(dataGridViewButtonColumn);
            List<ShiftDetailsDTO> list = DataStructure<ShiftDetailsDTO>.Instance.FindAll(x => x.Day.ToString("dd/MM/yyyy") == dateTimePicker1.Value.ToString("dd/MM/yyyy")
                && x.isCompleted == false);
            foreach (ShiftDetailsDTO s in list)
            {
                dataTable.Rows.Add(s.Employee.ID + ": " + s.Employee.Name, s.Workshift.ID + ": " + s.Workshift.StartTime + " - " + s.Workshift.EndTime,
                    s.Day.ToString("dd/MM/yyyy"));
            }
            button1.DialogResult = DialogResult.OK;
        }
        public event EventHandler<ShiftDetailsEventArgs> UpdateShift;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                ShiftDetailsDTO shift = DataStructure<ShiftDetailsDTO>.Instance.Find(x => x.Employee.ID == dataTable.Rows[e.RowIndex].Field<string>("Nhân viên").Remove(6)
                    && x.Workshift.ID == dataTable.Rows[e.RowIndex].Field<string>("Ca làm").Remove(6) && x.Day.ToString("dd/MM/yyyy") == dateTimePicker1.Value.ToString("dd/MM/yyyy"));
                UpdateShift(this, new ShiftDetailsEventArgs(new List<ShiftDetailsDTO> { shift }));
                dataTable.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataTable.Rows.Clear();
            List<ShiftDetailsDTO> list = DataStructure<ShiftDetailsDTO>.Instance.FindAll(x => x.Day.ToString("dd/MM/yyyy") == dateTimePicker1.Value.ToString("dd/MM/yyyy")
                && x.isCompleted == false);
            foreach (ShiftDetailsDTO s in list)
            {
                dataTable.Rows.Add(s.Employee.ID + ": " + s.Employee.Name, s.Workshift.ID + ": " + s.Workshift.StartTime + " - " + s.Workshift.EndTime,
                    s.Day.ToString("dd/MM/yyyy"));
            }
        }
    }
}
