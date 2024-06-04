﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_Coffee_Shop_Management_System.DTO;
using PBL3_Coffee_Shop_Management_System.Models;
using PBL3_Coffee_Shop_Management_System.Presenters;

namespace PBL3_Coffee_Shop_Management_System.Views
{
    public partial class SellScreen : UserControl
    {
        ProductsPanel[] panel = new ProductsPanel[DataStructure<ProductDTO>.Instance.Count];
        DataTable dataTable = new DataTable();
        public SellScreen()
        {
            InitializeComponent();
            Name = "SellScreen";
            flowLayoutPanel1.AutoScroll = true;
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("STT", typeof(int)),
                new DataColumn("Tên sản phẩm", typeof(string)),
                new DataColumn("Số lượng", typeof(int)),
                new DataColumn("Đơn giá", typeof(int)),
                new DataColumn("Thành tiền", typeof (int))
            });
            for (int i = 0; i < dataTable.Columns.Count; i++)
                dataTable.Columns[i].ReadOnly = true;
            dataTable.Columns[2].ReadOnly = false;
            // setup datagridview
            dataGridView1.DataSource = dataTable;
            for (int i = 0; i < dataTable.Columns.Count; i++)
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn();
            dataGridViewButtonColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewButtonColumn.Text = "X";
            dataGridViewButtonColumn.UseColumnTextForButtonValue = true;
            dataGridViewButtonColumn.Width = 20;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 33;
            dataGridView1.Columns.Add(dataGridViewButtonColumn);
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //
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
            var rows = dataTable.AsEnumerable().Where(r => r.Field<string>("Tên sản phẩm") == product.Name);
            if (rows.Count() == 0)
            {
                dataTable.Rows.Add(dataTable.AsEnumerable().LastOrDefault() != null ? (Int32)dataTable.AsEnumerable().LastOrDefault().ItemArray[0]+1:1,
                    product.Name, 1, product.Price, product.Price);
            }
            else
            {
                DataRow dataRow = dataTable.AsEnumerable().Where(r => r.Field<string>("Tên sản phẩm") == product.Name).LastOrDefault();
                dataRow["Số lượng"] = (Int32)dataRow["Số lượng"] + 1;
                dataTable.Columns[4].ReadOnly = false;
                dataRow["Thành tiền"] = (Int32)dataRow["Số lượng"] * (Int32)dataRow["Đơn giá"];
                dataTable.Columns[4].ReadOnly = true;
            }
        }
        public event EventHandler GetAllData;

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Số lượng"].Index)
            {
                dataTable.Columns[4].ReadOnly = false;
                dataTable.Rows[e.RowIndex].SetField(4, (Int32)dataTable.Rows[e.RowIndex].ItemArray[2] * (Int32)dataTable.Rows[e.RowIndex].ItemArray[3]);
                dataTable.Columns[4].ReadOnly = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                dataTable.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfirmOrderForm confirmOrderForm = new ConfirmOrderForm(dataTable);
            string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
            ReceiptModel receiptModel = new ReceiptModel(connstring);
            ReceiptPresenter receiptPresenter = new ReceiptPresenter(receiptModel, confirmOrderForm);
            confirmOrderForm.ShowDialog();
            dataTable.Rows.Clear();
        }
    }
}
