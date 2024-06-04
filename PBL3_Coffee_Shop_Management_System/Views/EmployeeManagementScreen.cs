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
    public partial class EmployeeManagementScreen : UserControl
    {
        private bool Authentication;
        public EmployeeManagementScreen(bool auth)
        {
            InitializeComponent();
            Authentication = auth;
            if (auth)
            {
                columnHeader11 = new ColumnHeader();
                columnHeader11.Text = "Mật Khẩu";
                columnHeader11.TextAlign = HorizontalAlignment.Center;
                columnHeader12 = new ColumnHeader();
                columnHeader12.Text = "Lương Một Giờ";
                columnHeader12.TextAlign = HorizontalAlignment.Center;
                listView1.Columns.Add(columnHeader11);
                listView1.Columns.Add(columnHeader12);
                foreach (EmployeeDTO e in DataStructure<EmployeeDTO>.Instance)
                {
                    listView1.Items.Add(new ListViewItem(new string[] {e.ID.ToString(), e.Name, e.Gender?"Nữ":"Nam", e.DateOfBirth.ToString(), e.Address, e.PhoneNum,
                e.Email, e.isFullTime?"Có":"Không", DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == e.ID).UserName, DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == e.ID).Password, e.Salary.ToString()}));
                }
            }
            else
            {
                foreach (EmployeeDTO e in DataStructure<EmployeeDTO>.Instance)
                {
                    listView1.Items.Add(new ListViewItem(new string[] {e.ID.ToString(), e.Name, e.Gender?"Nữ":"Nam", e.DateOfBirth.ToString(), e.Address, e.PhoneNum,
                    e.Email, e.isFullTime?"Có":"Không", DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == e.ID).UserName}));
                }
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
        public event EventHandler AddEmployee;
        public event EventHandler<EmployeeEventArgs> DeleteEmployee;
        public event EventHandler<EmployeeEventArgs> UpdateEmployee;

        private void button1_Click(object sender, EventArgs e)
        {
            AddEmployee(this, EventArgs.Empty);
            listView1.Items.Clear();
            if (Authentication)
            {
                foreach (EmployeeDTO em in DataStructure<EmployeeDTO>.Instance)
                {
                    listView1.Items.Add(new ListViewItem(new string[] {em.ID.ToString(), em.Name, em.Gender?"Nữ":"Nam", em.DateOfBirth.ToString(), em.Address, em.PhoneNum,
                    em.Email, em.isFullTime?"Có":"Không", DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == em.ID).UserName, DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == em.ID).Password, em.Salary.ToString()}));
                }
            }
            else
            {
                foreach (EmployeeDTO em in DataStructure<EmployeeDTO>.Instance)
                {
                    listView1.Items.Add(new ListViewItem(new string[] { em.ID, em.Name, em.Gender?"Nữ":"Nam", em.DateOfBirth.ToString(), em.PhoneNum,
                    em.Email, em.isFullTime?"Có":"Không", DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == em.ID).UserName }));
                }
            }
            AutoSizeColumnList(listView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                List<EmployeeDTO> list = new List<EmployeeDTO>();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    EmployeeDTO temp = new EmployeeDTO(item.Text, item.SubItems[1].Text, item.SubItems[2].Text=="Nam"?false:true,
                        Convert.ToDateTime(item.SubItems[3].Text), item.SubItems[4].Text, item.SubItems[5].Text, item.SubItems[6].Text,
                        item.SubItems[7].Text == "Không" ? false : true, Convert.ToInt32(item.SubItems[8].Text));
                    list.Add(temp);
                    listView1.Items.Remove(item);
                }
                DeleteEmployee(this, new EmployeeEventArgs(list));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListViewItem item = listView1.SelectedItems[0];
                List<EmployeeDTO> list = new List<EmployeeDTO>();
                EmployeeDTO employee = new EmployeeDTO(item.Text, item.SubItems[1].Text, item.SubItems[2].Text == "Nam" ? false : true,
                        Convert.ToDateTime(item.SubItems[3].Text), item.SubItems[4].Text, item.SubItems[5].Text, item.SubItems[6].Text,
                        item.SubItems[7].Text == "Không" ? false : true, Convert.ToInt32(item.SubItems[8].Text));
                list.Add(employee);
                UpdateEmployee(this, new EmployeeEventArgs(list));
                listView1.Items.Clear();
                if (Authentication)
                {
                    foreach (EmployeeDTO em in DataStructure<EmployeeDTO>.Instance)
                    {
                        listView1.Items.Add(new ListViewItem(new string[] {em.ID.ToString(), em.Name, em.Gender?"Nữ":"Nam", em.DateOfBirth.ToString(), em.Address, em.PhoneNum,
                    em.Email, em.isFullTime?"Có":"Không", DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == em.ID).UserName, DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == em.ID).Password, em.Salary.ToString()}));
                    }
                }
                else
                {
                    foreach (EmployeeDTO em in DataStructure<EmployeeDTO>.Instance)
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { em.ID, em.Name, em.Gender?"Nữ":"Nam", em.DateOfBirth.ToString(), em.PhoneNum,
                    em.Email, em.isFullTime?"Có":"Không", DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == em.ID).UserName }));
                    }
                }
                AutoSizeColumnList(listView1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            List<EmployeeDTO> employee = DataStructure<EmployeeDTO>.Instance.FindAll(x => x.ID.Contains(textBox1.Text) || x.Name.Contains(textBox1.Text) || x.Address.Contains(textBox1.Text)
                || x.Email.Contains(textBox1.Text) || x.Salary.ToString().Contains(textBox1.Text) || x.PhoneNum.Contains(textBox1.Text));
            if (Authentication)
            {
                foreach (EmployeeDTO em in employee)
                {
                    listView1.Items.Add(new ListViewItem(new string[] {em.ID.ToString(), em.Name, em.Gender?"Nữ":"Nam", em.DateOfBirth.ToString(), em.Address, em.PhoneNum,
                    em.Email, em.isFullTime?"Có":"Không", DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == em.ID).UserName, DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == em.ID).Password, em.Salary.ToString()}));
                }
            }
            else
            {
                foreach (EmployeeDTO em in employee)
                {
                    listView1.Items.Add(new ListViewItem(new string[] { em.ID, em.Name, em.Gender?"Nữ":"Nam", em.DateOfBirth.ToString(), em.PhoneNum,
                    em.Email, em.isFullTime?"Có":"Không", DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == em.ID).UserName }));
                }
            }
            AutoSizeColumnList(listView1);
        }
    }
}
