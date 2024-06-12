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
    public partial class SalesHistoryScreen : UserControl
    {
        private DataTable dataTable = new DataTable();
        public SalesHistoryScreen(bool Authentication)
        {
            InitializeComponent();
            if (!Authentication)
            {
                button1.Visible = false;
            }
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Mã Hóa Đơn", typeof(string)),
                new DataColumn("Tên Sản Phẩm", typeof(string)),
                new DataColumn("Số Lượng", typeof(string)),
                new DataColumn("Đơn Giá", typeof(string)),
                new DataColumn("Mã Nhân Viên", typeof(string)),
                new DataColumn("Mã Khách Hàng", typeof(string)),
                new DataColumn("Thời Gian Giao Dịch", typeof (DateTime)),
                new DataColumn("Số Thẻ Bàn", typeof (int)),
                new DataColumn("Số Tiền Được Giảm", typeof (int)),
                new DataColumn("Thành Tiền", typeof (int))
            });
            for (int i = 0; i < dataTable.Columns.Count; i++)
                dataTable.Columns[i].ReadOnly = true;
            // setup datagridview
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (ReceiptDTO r in DataStructure<ReceiptDTO>.Instance)
            {
                string products = "";
                string quantity = "";
                string prices = "";
                int total = 0;
                int index = 0;
                foreach (ProductDTO product in r.Products)
                {
                    products += product.Name + "\n";
                    quantity += r.Quantity[index] + "\n";
                    prices += product.Price + "\n";
                    total += r.Total[index++];
                }
                dataTable.Rows.Add(r.ReceiptID, products, quantity, prices, r.EmployeeID, r.CustomerID, r.TransactionTime, r.TableNum, r.Discount, total);
            }
            //
        }
        public event EventHandler DeleteReceipt;

        private void button1_Click(object sender, EventArgs e)
        {
            using (CustomerPointsDetailsForm form = new CustomerPointsDetailsForm())
            {
                form.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                List<string> list = new List<string>();
                foreach (DataGridViewRow rowView in dataGridView1.SelectedRows)
                {
                    DataRow row = ((DataRowView)rowView.DataBoundItem).Row;
                    list.Add(row[0].ToString());
                    dataTable.Rows.Remove(row);
                }
                try
                {
                    DeleteReceipt(list, EventArgs.Empty);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Clear();
            List<ReceiptDTO> receipt = DataStructure<ReceiptDTO>.Instance.FindAll(x => x.ReceiptID.Contains(textBox1.Text) || x.EmployeeID.Contains(textBox1.Text)
                || x.CustomerID.Contains(textBox1.Text) || x.TableNum.ToString().Contains(textBox1.Text));
            foreach (ReceiptDTO r in DataStructure<ReceiptDTO>.Instance)
            {
                string products = "";
                string quantity = "";
                string prices = "";
                int total = 0;
                int index = 0;
                foreach (ProductDTO product in r.Products)
                {
                    products += product.Name + "\n";
                    quantity += r.Quantity[index] + "\n";
                    prices += product.Price + "\n";
                    total += r.Total[index++];
                }
                dataTable.Rows.Add(r.ReceiptID, products, quantity, prices, r.EmployeeID, r.CustomerID, r.TransactionTime, r.TableNum, r.Discount, total);
            }
        }
    }
}
