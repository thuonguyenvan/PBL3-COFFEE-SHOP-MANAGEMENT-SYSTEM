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
    public partial class ProductCategoryDetailsForm : Form
    {
        public string TypeID { get; set; }
        public string TypeName { get; set; }
        public ProductCategoryDetailsForm()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
        }
        public ProductCategoryDetailsForm(ProductTypeDTO productType)
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
            textBox1.Text = productType.ID;
            textBox2.Text = productType.Type;
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TypeID = textBox1.Text;
            TypeName = textBox2.Text;
        }
    }
}
