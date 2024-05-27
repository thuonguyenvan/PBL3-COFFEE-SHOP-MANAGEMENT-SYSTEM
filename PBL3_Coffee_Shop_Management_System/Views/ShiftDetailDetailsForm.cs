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

namespace PBL3_Coffee_Shop_Management_System.Views
{
    public partial class ShiftDetailDetailsForm : Form
    {
        public ShiftDetailDetailsForm()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
            foreach (EmployeeDTO employee in DataStructure<EmployeeDTO>.Instance)
            {
                comboBox1.Items.Add(employee.ID+": "+employee.Name);
            }
            foreach (WorkshiftDTO workshift in DataStructure<WorkshiftDTO>.Instance)
            {
                comboBox2.Items.Add(workshift.ID+": "+workshift.StartTime.ToString()+" - "+workshift.EndTime.ToString());
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        public ShiftDetailDetailsForm(WorkshiftPanel workshiftPanel)
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
            foreach (EmployeeDTO employee in DataStructure<EmployeeDTO>.Instance)
            {
                comboBox1.Items.Add(employee.ID + ": " + employee.Name);
            }
            foreach (WorkshiftDTO workshift in DataStructure<WorkshiftDTO>.Instance)
            {
                comboBox2.Items.Add(workshift.ID + ": " + workshift.StartTime.ToString() + " - " + workshift.EndTime.ToString());
            }
            comboBox1.SelectedIndex = comboBox1.FindString(workshiftPanel.employee.ID);
            comboBox2.SelectedIndex = comboBox2.FindString(workshiftPanel.workshift.ID);
            dateTimePicker1.Value = workshiftPanel.day;
        }
        public ShiftDetailsDTO GetData()
        {
            return new ShiftDetailsDTO(DataStructure<EmployeeDTO>.Instance.Find(x => x.ID == comboBox1.GetItemText(comboBox1.SelectedItem).Remove(6)),
                DataStructure<WorkshiftDTO>.Instance.Find(x => x.ID == comboBox2.GetItemText(comboBox2.SelectedItem).Remove(6)), dateTimePicker1.Value, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
