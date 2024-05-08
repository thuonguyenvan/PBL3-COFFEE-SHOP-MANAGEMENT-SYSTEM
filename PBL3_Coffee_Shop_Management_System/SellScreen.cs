using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_Coffee_Shop_Management_System
{
    public partial class SellScreen : UserControl
    {
        public SellScreen()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
            foreach (DataStructure d in DataStructure.Instance.list)
            {
                ProductsPanel panel = new ProductsPanel(d.Name);
                flowLayoutPanel1.Controls.Add(panel);
            }
            
        }
    }
}
