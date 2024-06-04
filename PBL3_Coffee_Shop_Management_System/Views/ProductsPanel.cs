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
    public partial class ProductsPanel : UserControl
    {
        public ProductsPanel(string Product)
        {
            InitializeComponent();
            Name = Product;
            using (FileStream fs = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "Images\\" + Product.Replace(" ", "_") + ".jpg", FileMode.Open))
            {
                pictureBox1.Image = Image.FromStream(fs);
            }
            pictureBox1.Tag = Product;
            label1.Text = Product;
            label1.Left = (Width - label1.Width) / 2;
        }
    }
}
