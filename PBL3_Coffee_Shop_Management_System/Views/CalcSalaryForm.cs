using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_Coffee_Shop_Management_System.DTO;
using PBL3_Coffee_Shop_Management_System.Models;

namespace PBL3_Coffee_Shop_Management_System.Views
{
    public partial class CalcSalaryForm : Form
    {
        public CalcSalaryForm()
        {
            InitializeComponent();
            button2.DialogResult = DialogResult.Cancel;
            comboBox2.Enabled = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            AutoSizeColumnList(listView1);
        }
        private void AutoSizeColumnList(ListView listView)
        {
            listView.BeginUpdate();
            Dictionary<int, int> columnSize = new Dictionary<int, int>();
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            foreach (ColumnHeader colHeader in listView.Columns)
                columnSize.Add(colHeader.Index, colHeader.Width);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            foreach (ColumnHeader colHeader in listView.Columns)
            {
                int nColWidth;
                if (columnSize.TryGetValue(colHeader.Index, out nColWidth))
                    colHeader.Width = Math.Max(nColWidth, colHeader.Width);
                else
                    colHeader.Width = Math.Max(50, colHeader.Width);
            }
            listView.EndUpdate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.Enabled = true;
                if (DataStructure<EmployeeDTO>.Instance.Count == 0 )
                {
                    string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                    EmployeeModel employeeModel = new EmployeeModel(connstring);
                    employeeModel.getAllData();
                }
                List<EmployeeDTO> list = DataStructure<EmployeeDTO>.Instance.FindAll(x => x.isFullTime == true);
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Tất cả");
                foreach (EmployeeDTO employee in list)
                {
                    comboBox2.Items.Add(employee.ID + ": " + employee.Name);
                }
                comboBox2.SelectedIndex = 0;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.Enabled = true;
                if (DataStructure<EmployeeDTO>.Instance.Count == 0)
                {
                    string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                    EmployeeModel employeeModel = new EmployeeModel(connstring);
                    employeeModel.getAllData();
                }
                List<EmployeeDTO> list = DataStructure<EmployeeDTO>.Instance.FindAll(x => x.isFullTime == false);
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Tất cả");
                foreach (EmployeeDTO employee in list)
                {
                    comboBox2.Items.Add(employee.ID + ": " + employee.Name);
                }
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                comboBox2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
            WorkshiftModel workshiftModel = new WorkshiftModel(connstring);
            List<EmployeeDTO> list;
            if (comboBox1.SelectedIndex == 0 || (comboBox1.SelectedIndex != 0 && comboBox2.SelectedIndex == 0))
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    list = DataStructure<EmployeeDTO>.Instance;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    list = DataStructure<EmployeeDTO>.Instance.FindAll(x => x.isFullTime == true);
                }
                else
                {
                    list = DataStructure<EmployeeDTO>.Instance.FindAll(x => x.isFullTime == false);
                }
            }
            else
            {
                list = new List<EmployeeDTO> { DataStructure<EmployeeDTO>.Instance.Find(x => x.ID == comboBox2.GetItemText(comboBox2.SelectedItem).Substring(0, 6)) };
            }
            foreach (EmployeeDTO employee in list)
            {
                listView1.Items.Add(new ListViewItem(new string[] { employee.ID, employee.Name, employee.isFullTime?"Có":"Không",
                    employee.Salary.ToString(), workshiftModel.GetHoursWorked(employee, dateTimePicker1.Value.ToString("MM/yyyy")).ToString(),
                    (employee.Salary*workshiftModel.GetHoursWorked(employee, dateTimePicker1.Value.ToString("MM/yyyy"))).ToString() }));
            }
            AutoSizeColumnList(listView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
