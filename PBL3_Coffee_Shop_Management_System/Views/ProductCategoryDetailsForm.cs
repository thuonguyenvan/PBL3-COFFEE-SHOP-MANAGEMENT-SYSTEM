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
            string s = DataStructure<ProductTypeDTO>.Instance.Last().ID;
            s = s.Remove(0, 2);
            int i = Convert.ToInt32(s);
            i += 1;
            s = "PC";
            s += i.ToString();
            if (s.Length < 6) s = s.Insert(2, string.Concat(Enumerable.Repeat("0", 6 - s.Length)));
            while (DataStructure<ProductTypeDTO>.Instance.Find(x => x.ID == s) != null)
            {
                s = s.Remove(2, 4);
                i++;
                s += i.ToString();
                if (s.Length < 6) s = s.Insert(2, string.Concat(Enumerable.Repeat("0", 6 - s.Length)));
            }
            textBox1.Text = s;
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
