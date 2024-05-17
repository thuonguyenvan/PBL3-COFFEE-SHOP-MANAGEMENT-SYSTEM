using PBL3_Coffee_Shop_Management_System.DTO;
using PBL3_Coffee_Shop_Management_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBL3_Coffee_Shop_Management_System.Views
{
    public partial class ConfirmOrderForm : Form
    {
        CustomerDTO customer;
        ReceiptDTO receipt;
        public ConfirmOrderForm(DataTable dataTable)
        {
            InitializeComponent();
            CenterToScreen();
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button4.DialogResult = DialogResult.Cancel;
            button3.DialogResult = DialogResult.OK;
            foreach (DataRow row in dataTable.Rows)
            {
                listView1.Items.Add(new ListViewItem(new string[] { row.ItemArray[0].ToString(), row.ItemArray[1].ToString(),
                    row.ItemArray[2].ToString(), row.ItemArray[3].ToString(), row.ItemArray[4].ToString() }));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (DataStructure<CustomerDTO>.Instance.Count == 0)
            {
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                CustomerModel customerModel = new CustomerModel(connstring);
                customerModel.getAllData();
            }
            customer = DataStructure<CustomerDTO>.Instance.Find(x => x.PhoneNum == textBox1.Text);
            if (customer == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào với số điện thoại này!", "Customer not found");
                textBox2.Text = "";
                textBox3.Text = "";
                return;
            }
            textBox2.Text = customer.Name;
            textBox3.Text = customer.Points.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (customer != null)
            {
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
