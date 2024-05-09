﻿using PBL3_Coffee_Shop_Management_System.DTO;
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
            foreach (ProductDTO p in ProductDTO.Instance.list)
            {
                listView1.Items.Add(new ListViewItem(new string[] { p.ID.ToString(), p.Name, p.Price.ToString(), p.Unit, p.Type.ToString() }));
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
        public event EventHandler GetAllData;
    }
}