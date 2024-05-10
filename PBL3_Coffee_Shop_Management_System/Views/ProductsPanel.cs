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
    public partial class ProductsPanel : UserControl
    {
        public ProductsPanel(string Product)
        {
            InitializeComponent();
            Name = Product;
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject(Product.Replace(" ", "_"));
            pictureBox1.Tag = Product;
            label1.Text = Product;
            label1.Left = (Width - label1.Width) / 2;
        }
    }
}
