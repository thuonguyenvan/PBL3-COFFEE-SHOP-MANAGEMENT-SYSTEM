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

namespace PBL3_Coffee_Shop_Management_System.Views
{
    public partial class CustomerDetailsForm : Form
    {
        public CustomerDetailsForm()
        {
            InitializeComponent();
            CenterToScreen();
            textBox1.Text = (DataStructure<CustomerDTO>.Instance.Last().ID + 1).ToString();
        }
        public CustomerDetailsForm(CustomerDTO customer)
        {
            InitializeComponent();
            CenterToScreen();
            textBox1.Text = customer.ID.ToString();
            textBox2.Text = customer.Name;
            textBox3.Text = customer.PhoneNum;
            textBox4.Text = customer.Email;
            textBox5.Text = customer.Points.ToString();
            textBox1.Enabled = false;
        }
        public CustomerDTO GetData()
        {
            return new CustomerDTO(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToInt32(textBox5.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
