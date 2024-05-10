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
            textBox1.Text = (ProductDTO.Instance.list.Last().ID + 1).ToString();
        }
        public ProductDetailsForm(ProductDTO product)
        {
            InitializeComponent();
            CenterToScreen();
            textBox1.Text = product.ID.ToString();
            textBox2.Text = product.Name;
            textBox3.Text = product.Price.ToString();
            textBox4.Text = product.Unit;
            textBox5.Text = product.Type.ToString();
            textBox1.Enabled = false;
        }
        public ProductDTO GetData()
        {
            ProductDTO.Instance.ID = Convert.ToInt32(textBox1.Text);
            ProductDTO.Instance.Name = textBox2.Text;
            ProductDTO.Instance.Price = Convert.ToInt32(textBox3.Text);
            ProductDTO.Instance.Unit = textBox4.Text;
            ProductDTO.Instance.Type = Convert.ToInt32(textBox5.Text);
            return new ProductDTO(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text), textBox4.Text, Convert.ToInt32(textBox5.Text));
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
