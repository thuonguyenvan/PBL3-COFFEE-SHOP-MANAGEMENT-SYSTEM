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
        public Form1()
        {
            /*using (LoginForm loginForm = new LoginForm())
            {
                loginForm.ShowDialog();
                if (loginForm.DialogResult != DialogResult.Cancel)
                {
                    UserAccountDTO.Instance = loginForm.GetUserAccount();
                    if (loginForm.Authentication == 1)
                        UserAccountDTO.Instance.Authentication = true;
                    else UserAccountDTO.Instance.Authentication = false;
                }
                else Environment.Exit(0);
            }*/
            UserAccountDTO.Instance.Authentication = true;
            UserAccountDTO.Instance.UserName = "admin";
            InitializeComponent(UserAccountDTO.Instance.Authentication);
            label1.Text = "Xin chào, " + UserAccountDTO.Instance.UserName;
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
                if (UserAccountDTO.Instance.Authentication)
                    checkBox6.Checked = false;
                lastChecked = activeCheckBox;
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                ProductModel productModel = new ProductModel(connstring);
                if (ProductDTO.Instance.list.Count() == 0)
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
                if (UserAccountDTO.Instance.Authentication)
                    checkBox6.Checked = false;
                lastChecked = activeCheckBox;
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                CustomerModel customerModel = new CustomerModel(connstring);
                if (CustomerDTO.Instance.list.Count() == 0)
                    customerModel.getAllData();
                CustomerManagementScreen customerManagementScreen = new CustomerManagementScreen();
                CustomerPresenter customerPresenter = new CustomerPresenter(customerModel, customerManagementScreen);
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
                if (UserAccountDTO.Instance.Authentication)
                    checkBox6.Checked = false;
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
                if (UserAccountDTO.Instance.Authentication)
                    checkBox6.Checked = false;
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
                if (UserAccountDTO.Instance.Authentication)
                    checkBox6.Checked = false;
                lastChecked = activeCheckBox;
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                ProductModel productModel = new ProductModel(connstring);
                if (ProductDTO.Instance.list.Count() == 0)
                    productModel.getAllData();
                ProductManagementScreen productManagementScreen = new ProductManagementScreen();
                ProductPresenter productPresenter = new ProductPresenter(productModel, productManagementScreen);
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
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && activeCheckBox.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                lastChecked = activeCheckBox;
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                EmployeeModel employeeModel = new EmployeeModel(connstring);
                if (EmployeeDTO.Instance.list.Count() == 0)
                    employeeModel.getAllData();
                EmployeeManagementScreen employeeManagementScreen = new EmployeeManagementScreen();
                EmployeePresenter employeePresenter = new EmployeePresenter(employeeModel, employeeManagementScreen);
                panel1.Controls.Clear();
                panel1.Controls.Add(employeeManagementScreen);
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
            string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
            EmployeeModel employeeModel = new EmployeeModel(connstring);
            if (EmployeeDTO.Instance.list.Count() == 0)
                employeeModel.getAllData();
            // to do later
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            using (LoginForm loginForm = new LoginForm())
            {
                loginForm.ShowDialog();
                if (loginForm.DialogResult != DialogResult.Cancel)
                {
                    UserAccountDTO.Instance = loginForm.GetUserAccount();
                    if (loginForm.Authentication == 1)
                        UserAccountDTO.Instance.Authentication = true;
                    else UserAccountDTO.Instance.Authentication = false;
                }
                else Environment.Exit(0);
            }
            InitializeComponent(UserAccountDTO.Instance.Authentication);
            label1.Text = "Xin chào, " + UserAccountDTO.Instance.UserName;
            panel1.Controls.Add(welcomeScreen);
        }
    }
}
