using PBL3_Coffee_Shop_Management_System.DTO;
using PBL3_Coffee_Shop_Management_System.EventArguments;
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
    public partial class CustomerManagementScreen : UserControl
    {
        public CustomerManagementScreen()
        {
            InitializeComponent();
            foreach (CustomerDTO c in DataStructure<CustomerDTO>.Instance)
            {
                listView1.Items.Add(new ListViewItem(new string[] {c.ID.ToString(), c.Name, c.PhoneNum, c.Email, c.Points.ToString()}));
            }
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
        public event EventHandler AddCustomer;
        public event EventHandler<CustomerEventArgs> DeleteCustomer;
        public event EventHandler<CustomerEventArgs> UpdateCustomer;
        private void button1_Click(object sender, EventArgs e)
        {
            AddCustomer(this, EventArgs.Empty);
            listView1.Items.Clear();
            foreach (CustomerDTO c in DataStructure<CustomerDTO>.Instance)
            {
                listView1.Items.Add(new ListViewItem(new string[] { c.ID.ToString(), c.Name, c.PhoneNum, c.Email, c.Points.ToString() }));
            }
            AutoSizeColumnList(listView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                List<CustomerDTO> list = new List<CustomerDTO>();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    CustomerDTO temp = new CustomerDTO(Convert.ToInt32(item.Text), item.SubItems[1].Text, item.SubItems[2].Text,
                        item.SubItems[3].Text, Convert.ToInt32(item.SubItems[4].Text));
                    list.Add(temp);
                    listView1.Items.Remove(item);
                }
                DeleteCustomer(this, new CustomerEventArgs(list));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListViewItem item = listView1.SelectedItems[0];
                List<CustomerDTO> list = new List<CustomerDTO>();
                CustomerDTO customer = new CustomerDTO(Convert.ToInt32(item.Text), item.SubItems[1].Text, item.SubItems[2].Text,
                        item.SubItems[3].Text, Convert.ToInt32(item.SubItems[4].Text));
                list.Add(customer);
                UpdateCustomer(this, new CustomerEventArgs(list));
                listView1.Items.Clear();
                foreach (CustomerDTO c in DataStructure<CustomerDTO>.Instance)
                {
                    listView1.Items.Add(new ListViewItem(new string[] { c.ID.ToString(), c.Name, c.PhoneNum, c.Email, c.Points.ToString() }));
                }
                AutoSizeColumnList(listView1);
            }
        }
    }
}
