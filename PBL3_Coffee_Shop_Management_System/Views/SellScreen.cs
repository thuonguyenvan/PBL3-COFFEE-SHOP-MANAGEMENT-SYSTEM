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
    public partial class SellScreen : UserControl
    {
        public SellScreen()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
            foreach (ProductDTO d in DataStructure<ProductDTO>.Instance)
            {
                ProductsPanel panel = new ProductsPanel(d.Name);
                flowLayoutPanel1.Controls.Add(panel);
            }
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
        public event EventHandler GetAllData;
    }
}
