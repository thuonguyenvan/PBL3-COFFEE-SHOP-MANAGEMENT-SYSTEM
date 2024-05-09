﻿using System;
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
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject(Product.Replace(" ", "_"));
            label1.Text = Product;
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Product chose", "a");
        }
    }
}