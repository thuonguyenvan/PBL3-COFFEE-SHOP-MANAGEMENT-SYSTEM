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
            string s = DataStructure<CustomerDTO>.Instance.Last().ID;
            s = s.Remove(0, 1);
            int i = Convert.ToInt32(s);
            i += 1;
            s = "C";
            s += i.ToString();
            if (s.Length < 6) s = s.Insert(1, string.Concat(Enumerable.Repeat("0", 6 - s.Length)));
            while (DataStructure<CustomerDTO>.Instance.Find(x => x.ID == s) != null)
            {
                s.Remove(1, 5);
                i++;
                s += i.ToString();
                if (s.Length < 6) s = s.Insert(1, string.Concat(Enumerable.Repeat("0", 6 - s.Length)));
            }
            textBox1.Text = s;
        }
        public CustomerDetailsForm(CustomerDTO customer)
        {
            InitializeComponent();
            CenterToScreen();
            textBox1.Text = customer.ID;
            textBox2.Text = customer.Name;
            textBox3.Text = customer.PhoneNum;
            textBox4.Text = customer.Email;
            textBox5.Text = customer.Points.ToString();
            textBox1.Enabled = false;
        }
        public CustomerDetailsForm(string PhoneNum)
        {
            InitializeComponent();
            CenterToScreen();
            string s = DataStructure<CustomerDTO>.Instance.Last().ID;
            s = s.Remove(0, 1);
            int i = Convert.ToInt32(s);
            i += 1;
            s = "C";
            s += i.ToString();
            if (s.Length < 6) s = s.Insert(1, string.Concat(Enumerable.Repeat("0", 6 - s.Length)));
            while (DataStructure<CustomerDTO>.Instance.Find(x => x.ID == s) != null)
            {
                s = s.Remove(1, 5);
                i++;
                s += i.ToString();
                if (s.Length < 6) s = s.Insert(1, string.Concat(Enumerable.Repeat("0", 6 - s.Length)));
            }
            textBox1.Text = s;
            textBox3.Text = PhoneNum;
        }
        public CustomerDTO GetData()
        {
            return new CustomerDTO(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToInt32(textBox5.Text));
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
