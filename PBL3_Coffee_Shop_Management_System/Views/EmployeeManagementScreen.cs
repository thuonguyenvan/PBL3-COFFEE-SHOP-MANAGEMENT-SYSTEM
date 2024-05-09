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
    public partial class EmployeeManagementScreen : UserControl
    {
        public EmployeeManagementScreen()
        {
            InitializeComponent();
            if (UserAccountDTO.Instance.Authentication)
            {
                columnHeader11 = new ColumnHeader();
                columnHeader11.Text = "Mật Khẩu";
                columnHeader11.TextAlign = HorizontalAlignment.Center;
                listView1.Columns.Add(columnHeader11);
                foreach (EmployeeDTO e in EmployeeDTO.Instance.list)
                {
                    listView1.Items.Add(new ListViewItem(new string[] {e.ID.ToString(), e.Name, e.Gender?"Female":"Male", e.DateOfBirth.ToString(), e.Address, e.PhoneNum,
                e.Email, e.isFullTime?"Có":"Không", UserAccountDTO.Instance.list.Find(x => x.ID == e.ID).UserName, UserAccountDTO.Instance.list.Find(x => x.ID == e.ID).Password}));
                }
            }
            else
            {
                foreach (EmployeeDTO e in EmployeeDTO.Instance.list)
                {
                    listView1.Items.Add(new ListViewItem(new string[] {e.ID.ToString(), e.Name, e.Gender?"Female":"Male", e.DateOfBirth.ToString(), e.Address, e.PhoneNum,
                    e.Email, e.isFullTime?"Có":"Không", UserAccountDTO.Instance.list.Find(x => x.ID == e.ID).UserName}));
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
    }
}
