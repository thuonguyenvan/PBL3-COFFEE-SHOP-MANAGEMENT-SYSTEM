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
    public partial class EmployeeDetailsForm : Form
    {
        public EmployeeDetailsForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            CenterToScreen();
            string s = DataStructure<EmployeeDTO>.Instance.Last().ID;
            s = s.Remove(0, 1);
            int i = Convert.ToInt32(s);
            i += 1;
            s = DataStructure<EmployeeDTO>.Instance.Last().ID;
            s = s.Remove(1, 5);
            s += i.ToString();
            if (s.Length < 6) s = s.Insert(1, string.Concat(Enumerable.Repeat("0", 6-s.Length)));
            textBox1.Text = s;
        }
        public EmployeeDetailsForm(EmployeeDTO employee)
        {
            InitializeComponent();
            CenterToScreen();
            textBox1.Text = employee.ID;
            textBox2.Text = employee.Name;
            textBox3.Text = employee.Address;
            textBox4.Text = employee.PhoneNum;
            textBox5.Text = employee.Email;
            textBox6.Text = DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == employee.ID).UserName;
            textBox7.Text = DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == employee.ID).Password;
            textBox1.Enabled = false;
            comboBox1.SelectedIndex = employee.Gender ? 1 : 0;
            comboBox2.SelectedIndex = employee.isFullTime ? 0 : 1;
            dateTimePicker1.Value = employee.DateOfBirth;
        }
        public EmployeeDTO GetData()
        {
            int index = DataStructure<UserAccountDTO>.Instance.FindIndex(x => x.ID == textBox1.Text);
            if (index != -1)
            {
                DataStructure<UserAccountDTO>.Instance[index].UserName = textBox6.Text;
                DataStructure<UserAccountDTO>.Instance[index].Password = textBox7.Text;
            }
            else
            {
                UserAccountDTO user = new UserAccountDTO();
                user.ID = textBox1.Text;
                user.UserName = textBox6.Text;
                user.Password = textBox7.Text;
                DataStructure<UserAccountDTO>.Instance.Add(user);
            }
            return new EmployeeDTO(textBox1.Text, textBox2.Text, comboBox1.SelectedIndex==0?false:true, dateTimePicker1.Value, textBox3.Text, textBox4.Text,
                textBox5.Text, comboBox2.SelectedIndex == 0 ? true : false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
