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
    public partial class ReceiptScreen : Form
    {
        public ReceiptScreen(ReceiptDTO receipt, DataTable dataTable, int cashReceived)
        {
            InitializeComponent();
            CenterToScreen();
            label3.Text = receipt.ReceiptID;
            label5.Text = DataStructure<EmployeeDTO>.Instance.Find(x => x.ID == receipt.EmployeeID).Name;
            label7.Text = receipt.TableNum.ToString();
            label9.Text = receipt.TransactionTime.ToString("HH:mm:ss dd/MM/yyyy");
            label22.Text = DataStructure<CustomerDTO>.Instance.Find(x => x.ID == receipt.CustomerID)!=null? DataStructure<CustomerDTO>.Instance.Find(x => x.ID == receipt.CustomerID).Name : "";
            label11.Text = receipt.Products.Count.ToString();
            label13.Text = receipt.Discount.ToString() + "đ";
            int Total = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                listView1.Items.Add(new ListViewItem(new string[] { row.ItemArray[0].ToString(), row.ItemArray[1].ToString(),
                    row.ItemArray[2].ToString(), row.ItemArray[3].ToString(), row.ItemArray[4].ToString() }));
                Total += (int)row.ItemArray[4];
            }
            label15.Text = Total.ToString() + "đ";
            label17.Text = cashReceived.ToString() + "đ";
            label19.Text = cashReceived!=0?(cashReceived - Total).ToString()+"đ":"0đ";
        }
    }
}
