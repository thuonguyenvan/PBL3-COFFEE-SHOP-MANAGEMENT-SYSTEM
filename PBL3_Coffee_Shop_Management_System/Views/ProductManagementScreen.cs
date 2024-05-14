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
    public partial class ProductManagementScreen : UserControl
    {
        public ProductManagementScreen()
        {
            InitializeComponent();
            foreach (ProductDTO p in DataStructure<ProductDTO>.Instance)
            {
                listView1.Items.Add(new ListViewItem(new string[] { p.ID, p.Name, p.Price.ToString(), p.Unit, p.Type.ToString() }));
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
        public event EventHandler AddProduct;
        public event EventHandler<ProductEventArgs> DeleteProduct;
        public event EventHandler<ProductEventArgs> UpdateProduct;

        private void button1_Click(object sender, EventArgs e)
        {
            AddProduct(this, EventArgs.Empty);
            listView1.Items.Clear();
            foreach (ProductDTO p in DataStructure<ProductDTO>.Instance)
            {
                listView1.Items.Add(new ListViewItem(new string[] { p.ID, p.Name, p.Price.ToString(), p.Unit, p.Type.ToString() }));
            }
            AutoSizeColumnList(listView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                List<ProductDTO> list = new List<ProductDTO>();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    ProductDTO temp = new ProductDTO(item.Text, item.SubItems[1].Text, Convert.ToInt32(item.SubItems[2].Text),
                        item.SubItems[3].Text, Convert.ToInt32(item.SubItems[4].Text));
                    list.Add(temp);
                    listView1.Items.Remove(item);
                }
                DeleteProduct(this, new ProductEventArgs(list));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListViewItem item = listView1.SelectedItems[0];
                List<ProductDTO> list = new List<ProductDTO>();
                ProductDTO product = new ProductDTO(item.Text, item.SubItems[1].Text, Convert.ToInt32(item.SubItems[2].Text),
                        item.SubItems[3].Text, Convert.ToInt32(item.SubItems[4].Text));
                list.Add(product);
                UpdateProduct(this, new ProductEventArgs(list));
                listView1.Items.Clear();
                foreach (ProductDTO p in DataStructure<ProductDTO>.Instance)
                {
                    listView1.Items.Add(new ListViewItem(new string[] { p.ID, p.Name, p.Price.ToString(), p.Unit, p.Type.ToString() }));
                }
                AutoSizeColumnList(listView1);
            }
        }
    }
}
