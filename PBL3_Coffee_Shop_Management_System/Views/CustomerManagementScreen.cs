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
    public partial class CustomerManagementScreen : UserControl
    {
        public CustomerManagementScreen()
        {
            InitializeComponent();
            foreach (CustomerDTO c in CustomerDTO.Instance.list)
            {
                listView1.Items.Add(new ListViewItem(new string[] {c.ID.ToString(), c.Name, c.Email, c.PhoneNum, c.Points.ToString()}));
            }
        }
    }
}
