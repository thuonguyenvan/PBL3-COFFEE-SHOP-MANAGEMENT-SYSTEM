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
    public partial class ProductDetailsForm : Form
    {
        public ProductDetailsForm()
        {
            InitializeComponent();
            CenterToScreen();
            textBox1.Text = (Convert.ToInt32(DataStructure<ProductDTO>.Instance.Last().ID) + 1).ToString();
            SetCombobox();
        }
        public ProductDetailsForm(ProductDTO product)
        {
            InitializeComponent();
            CenterToScreen();
            textBox1.Text = product.ID;
            textBox2.Text = product.Name;
            textBox3.Text = product.Price.ToString();
            textBox4.Text = product.Unit;
            SetCombobox();
            textBox1.Enabled = false;
        }
        private void SetCombobox()
        {
            foreach (ProductTypeDTO pt in DataStructure<ProductTypeDTO>.Instance)
            {
                comboBox1.Items.Add(pt.Type);
            }
            comboBox1.SelectedIndex = 0;
        }
        public ProductDTO GetData()
        {
            return new ProductDTO(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text), textBox4.Text, comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
