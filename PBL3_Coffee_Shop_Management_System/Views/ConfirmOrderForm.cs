using PBL3_Coffee_Shop_Management_System.DTO;
using PBL3_Coffee_Shop_Management_System.EventArguments;
using PBL3_Coffee_Shop_Management_System.Models;
using PBL3_Coffee_Shop_Management_System.Presenters;
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
        CustomerDTO customer = null;
        ReceiptDTO receipt = new ReceiptDTO();
        public ConfirmOrderForm(DataTable dataTable)
        {
            InitializeComponent();
            CenterToScreen();
            comboBox1.SelectedIndex = 0;
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

        public event EventHandler AddCustomer;
        public event EventHandler<ReceiptEventArgs> AddReceipt;

        private void button1_Click(object sender, EventArgs e)
        {
            string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
            CustomerModel customerModel = new CustomerModel(connstring);
            if (DataStructure<CustomerDTO>.Instance.Count == 0)
            {
                customerModel.getAllData();
            }
            customer = DataStructure<CustomerDTO>.Instance.Find(x => x.PhoneNum == textBox1.Text);
            if (customer == null)
            {
                DialogResult res = MessageBox.Show("Không tìm thấy khách hàng nào với số điện thoại này!\nBạn có muốn thêm khách hàng mới không?", "Customer not found",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    CustomerPresenter cp = new CustomerPresenter(customerModel, this);
                    AddCustomer(textBox1.Text, EventArgs.Empty);
                }
                else
                {
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                return;
            }
            button2.Enabled = true;
            textBox2.Text = customer.Name;
            textBox3.Text = customer.Points.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "0";
            label5.Visible = true;
            label6.Visible = true;
            receipt.Discount = customer.Points * Form1.Instance.PointsToMoney;
            label6.Text = label6.Text + " " + receipt.Discount.ToString();
            customer.Points = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Receipt to be added here");
            receipt.TransactionTime = DateTime.Now;
            receipt.EmployeeID = Form1.Instance.EmployeeID;
            if (customer != null)
                receipt.CustomerID = customer.ID;
            receipt.TableNum = comboBox1.SelectedIndex + 1;
            List<ProductDTO> products = new List<ProductDTO>();
            List<int> Quantity = new List<int>();
            List<int> Total = new List<int>();
            int total = 0;
            foreach (ListViewItem i in listView1.Items)
            {
                ProductDTO product = new ProductDTO();
                product.Name = i.SubItems[1].Text;
                products.Add(product);
                Quantity.Add(Convert.ToInt32(i.SubItems[2].Text));
                Total.Add(Convert.ToInt32(i.SubItems[4].Text));
                total += Convert.ToInt32(i.SubItems[4].Text);
            }
            receipt.Products = products;
            receipt.Quantity = Quantity;
            receipt.Total = Total;
            AddReceipt(this, new ReceiptEventArgs(new List<ReceiptDTO> { receipt }));
            if (customer != null)
            {
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                CustomerModel customerModel = new CustomerModel(connstring);
                customer.Points = (int)((total - receipt.Discount) * Form1.Instance.MoneyToPoints);
                customerModel.Update(customer);
            }
        }
    }
}
