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
    public partial class Form1 : Form
    {
        WelcomeScreen welcomeScreen = new WelcomeScreen();
        public Form1()
        {
            InitializeComponent();
            panel1.Controls.Add(welcomeScreen);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        CheckBox lastChecked;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && activeCheckBox.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                lastChecked = activeCheckBox;
                SellScreen sellScreen = new SellScreen();
                panel1.Controls.Clear();
                panel1.Controls.Add(sellScreen);
            }
            else
            {
                lastChecked = null;
                panel1.Controls.Clear();
                panel1.Controls.Add(welcomeScreen);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && activeCheckBox.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                lastChecked = activeCheckBox;
                ManagementScreen managementScreen = new ManagementScreen();
                managementScreen.setCustomerManagementScreen();
                panel1.Controls.Clear();
                panel1.Controls.Add(managementScreen);
            }
            else
            {
                lastChecked = null;
                panel1.Controls.Clear();
                panel1.Controls.Add(welcomeScreen);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && activeCheckBox.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                lastChecked = activeCheckBox;
                ManagementScreen managementScreen = new ManagementScreen();
                managementScreen.setSalesHistoryScreen();
                panel1.Controls.Clear();
                panel1.Controls.Add(managementScreen);
            }
            else
            {
                lastChecked = null;
                panel1.Controls.Clear();
                panel1.Controls.Add(welcomeScreen);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && activeCheckBox.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox5.Checked = false;
                lastChecked = activeCheckBox;
                WorkScheduleScreen workScheduleScreen = new WorkScheduleScreen();
                panel1.Controls.Clear();
                panel1.Controls.Add(workScheduleScreen);
            }
            else
            {
                lastChecked = null;
                panel1.Controls.Clear();
                panel1.Controls.Add(welcomeScreen);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && activeCheckBox.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                lastChecked = activeCheckBox;
                ManagementScreen managementScreen = new ManagementScreen();
                managementScreen.setProductManagementScreen();
                panel1.Controls.Clear();
                panel1.Controls.Add(managementScreen);
            }
            else
            {
                lastChecked = null;
                panel1.Controls.Clear();
                panel1.Controls.Add(welcomeScreen);
            }
        }
    }
}
