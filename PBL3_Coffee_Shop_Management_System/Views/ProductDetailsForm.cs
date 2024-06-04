using PBL3_Coffee_Shop_Management_System.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            textBox5.Text = System.AppDomain.CurrentDomain.BaseDirectory + "Images\\" + product.Name.Replace(" ", "_") + ".jpg";
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
            string imageFromPath = textBox5.Text;
            if (imageFromPath.Length != 0)
            {
                Image i = Image.FromFile(imageFromPath);
                if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "Images\\" + textBox2.Text.Replace(" ", "_") + ".jpg"))
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "Images\\" + textBox2.Text.Replace(" ", "_") + ".jpg");
                i.Save(System.AppDomain.CurrentDomain.BaseDirectory + "Images\\" + textBox2.Text.Replace(" ", "_") + ".jpg",
                    System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image|*.png;*.jpg;*.jpeg;*bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox5.Text = ofd.FileName;
                }
            }
        }
    }
}
