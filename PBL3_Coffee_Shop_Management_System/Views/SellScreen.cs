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
        ProductsPanel[] panel = new ProductsPanel[DataStructure<ProductDTO>.Instance.Count];
        public SellScreen()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
            int index = 0;
            foreach (ProductDTO d in DataStructure<ProductDTO>.Instance)
            {
                panel[index] = new ProductsPanel(d.Name);
                panel[index].MouseClick += ProductSelected;
                foreach (Control control in panel[index].Controls)
                    control.Click += ProductSelected;
                flowLayoutPanel1.Controls.Add(panel[index++]);
            }
        }
        private void ProductSelected(object sender, EventArgs e)
        {
            ProductDTO product;
            if (sender.GetType() == panel[0].GetType())
            {
                var temp = sender as ProductsPanel;
                product = DataStructure<ProductDTO>.Instance.Find(x => x.Name == temp.Name);
            }
            else if (sender.GetType() == label1.GetType())
            {
                var temp = sender as Label;
                product = DataStructure<ProductDTO>.Instance.Find(x => x.Name == temp.Text);
            }
            else
            {
                var temp = sender as PictureBox;
                product = DataStructure<ProductDTO>.Instance.Find(x => x.Name == temp.Tag.ToString());
            }            
            var r = listView1.Items.OfType<ListViewItem>();
            var listViewItem = r.LastOrDefault();
            listView1.Items.Add(new ListViewItem(new string[] { (listViewItem!=null?listView1.Items.IndexOf(listViewItem)+2:1).ToString(), product.Name, "1", product.Price.ToString(), product.Price.ToString() }));
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
