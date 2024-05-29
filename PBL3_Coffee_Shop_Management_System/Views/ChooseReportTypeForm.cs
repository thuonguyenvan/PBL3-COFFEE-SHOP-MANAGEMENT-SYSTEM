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
    public partial class ChooseReportTypeForm : Form
    {
        public int type;
        public int dateType;
        public DateTime startTime;
        public DateTime endTime;
        public ChooseReportTypeForm()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            type = comboBox1.SelectedIndex;
            dateType = comboBox2.SelectedIndex;
            startTime = dateTimePicker1.Value;
            endTime = dateTimePicker2.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
