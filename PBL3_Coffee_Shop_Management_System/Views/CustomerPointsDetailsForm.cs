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
    public partial class CustomerPointsDetailsForm : Form
    {
        public CustomerPointsDetailsForm()
        {
            InitializeComponent();
            textBox1.Text = Form1.Instance.PointsToMoney.ToString();
            textBox2.Text = (Form1.Instance.MoneyToPoints*100).ToString();
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.Instance.PointsToMoney = Convert.ToInt32(textBox1.Text);
            Form1.Instance.MoneyToPoints = Convert.ToDouble(textBox2.Text)/100;
        }
    }
}
