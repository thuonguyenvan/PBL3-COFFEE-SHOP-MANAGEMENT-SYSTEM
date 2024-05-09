using PBL3_Coffee_Shop_Management_System.Models;
using PBL3_Coffee_Shop_Management_System.Presenters;
using PBL3_Coffee_Shop_Management_System.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PBL3_Coffee_Shop_Management_System.Views
{
    public partial class Form1 : Form
    {
        WelcomeScreen welcomeScreen = new WelcomeScreen();
        UserAccountDTO userAccount;
        public Form1()
        {
            /*using (LoginForm loginForm = new LoginForm())
            {
                loginForm.ShowDialog();
                if (loginForm.DialogResult != DialogResult.Cancel)
                {
                    userAccount = loginForm.GetUserAccount();
                    if (loginForm.Authentication == 1)
                        userAccount.Authentication = true;
                    else userAccount.Authentication = false;
                }
                else Dispose();
            }*/
            InitializeComponent();
            label2.Text = "Xin chào, " + userAccount.UserName;
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
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                ProductModel productModel = new ProductModel(connstring);
                productModel.getAllData();
                SellScreen sellScreen = new SellScreen();
                SellScreenPresenter sellScreenPresenter = new SellScreenPresenter(productModel, sellScreen);
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
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                CustomerModel customerModel = new CustomerModel(connstring);
                customerModel.getAllData();
                CustomerManagementScreen customerManagementScreen = new CustomerManagementScreen();
                panel1.Controls.Clear();
                panel1.Controls.Add(customerManagementScreen);
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
                SalesHistoryScreen salesHistoryScreen = new SalesHistoryScreen();
                panel1.Controls.Clear();
                panel1.Controls.Add(salesHistoryScreen);
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
                ProductManagementScreen productManagementScreen = new ProductManagementScreen();
                panel1.Controls.Clear();
                panel1.Controls.Add(productManagementScreen);
            }
            else
            {
                lastChecked = null;
                panel1.Controls.Clear();
                panel1.Controls.Add(welcomeScreen);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
