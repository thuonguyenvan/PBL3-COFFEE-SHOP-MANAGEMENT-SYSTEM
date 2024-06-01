using PBL3_Coffee_Shop_Management_System.DTO;
using PBL3_Coffee_Shop_Management_System.EventArguments;
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

namespace PBL3_Coffee_Shop_Management_System.Views
{
    public partial class ProductCategoryManagementForm : Form
    {
        public ProductCategoryManagementForm()
        {
            InitializeComponent();
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

        public event EventHandler GetAllType;
        public event EventHandler<ProductCategoryEventArgs> AddType;
        public event EventHandler<ProductCategoryEventArgs> DeleteType;
        public event EventHandler<ProductCategoryEventArgs> UpdateType;
        private void ProductCategoryManagementForm_Load(object sender, EventArgs e)
        {
            GetAllType(this, EventArgs.Empty);
            foreach (ProductTypeDTO p in DataStructure<ProductTypeDTO>.Instance)
            {
                listView1.Items.Add(new ListViewItem(new string[] { p.ID, p.Type }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ProductCategoryDetailsForm form = new ProductCategoryDetailsForm())
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    AddType(this, new ProductCategoryEventArgs(new List<ProductTypeDTO> { new ProductTypeDTO(form.TypeID, form.TypeName) }));
                    listView1.Items.Add(new ListViewItem(new string[] { form.TypeID, form.TypeName }));
                    AutoSizeColumnList(listView1);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                List<ProductTypeDTO> list = new List<ProductTypeDTO>();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    ProductTypeDTO temp = new ProductTypeDTO(item.Text, item.SubItems[1].Text);
                    list.Add(temp);
                    listView1.Items.Remove(item);
                }
                DeleteType(this, new ProductCategoryEventArgs(list));
                AutoSizeColumnList(listView1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListViewItem item = listView1.SelectedItems[0];
                List<ProductTypeDTO> list = new List<ProductTypeDTO>();
                ProductTypeDTO product = new ProductTypeDTO(item.Text, item.SubItems[1].Text);
                list.Add(product);
                UpdateType(this, new ProductCategoryEventArgs(list));
                listView1.Items.Clear();
                foreach (ProductTypeDTO p in DataStructure<ProductTypeDTO>.Instance)
                {
                    listView1.Items.Add(new ListViewItem(new string[] { p.ID, p.Type }));
                }
                AutoSizeColumnList(listView1);
            }
        }
    }
}
