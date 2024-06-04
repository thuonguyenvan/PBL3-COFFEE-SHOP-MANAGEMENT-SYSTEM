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
using System.IO;
using PBL3_Coffee_Shop_Management_System.Properties;

namespace PBL3_Coffee_Shop_Management_System.Views
{
    public partial class Form1 : Form
    {
        WelcomeScreen welcomeScreen = new WelcomeScreen("WelcomeScreen");
        UserAccountDTO userAccountDTO = new UserAccountDTO();
        EmployeeDTO employeeDTO;
        private static Form1 _Instance;
        public static Form1 Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Form1();
                return _Instance;
            }
            set { _Instance = value; }
        }
        public string EmployeeID { get { return employeeDTO.ID; } set { } }
        public int PointsToMoney { get; set; }
        public double MoneyToPoints { get; set; }
        public Form1()
        {
            _Instance = this;
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
            userAccountDTO = DataStructure<UserAccountDTO>.Instance[1];
            userAccountDTO.Authentication = true;
            string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
            EmployeeModel employeeModel = new EmployeeModel(connstring);
            if (DataStructure<EmployeeDTO>.Instance.Count() == 0)
                employeeModel.getAllData();
            employeeDTO = DataStructure<EmployeeDTO>.Instance.Find(x => x.ID == userAccountDTO.ID);
            InitializeComponent(userAccountDTO.Authentication);
            label1.Text = "Xin chào, " + userAccountDTO.UserName;
            panel1.Controls.Add(welcomeScreen);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\CustomerPointsSettings.ini"))
            {
                string temp = "";
                temp = sr.ReadLine();
                string[] sArr = temp.Split('=');
                PointsToMoney = int.Parse(sArr[1]);
                temp = sr.ReadLine();
                sArr = temp.Split('=');
                MoneyToPoints = double.Parse(sArr[1]);
            }
        }

        CheckBox lastChecked;
        // Bán hàng
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && activeCheckBox.Checked)
            {
                List<Control> ctrls = new List<Control>();
                foreach (Control c in panel1.Controls)
                    ctrls.Add(c);
                panel1.Controls.Clear();
                foreach (Control c in ctrls)
                {
                    if (c.Name != "WelcomeScreen")
                        c.Dispose();
                }
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                if (userAccountDTO.Authentication)
                {
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                }
                lastChecked = activeCheckBox;
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                ProductModel productModel = new ProductModel(connstring);
                if (DataStructure<ProductDTO>.Instance.Count() == 0)
                    productModel.getAllData();
                SellScreen sellScreen = new SellScreen();
                SellScreenPresenter sellScreenPresenter = new SellScreenPresenter(productModel, sellScreen);
                
                panel1.Controls.Add(sellScreen);
            }
            else
            {
                lastChecked = null;
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false
                    && checkBox6.Checked == false && checkBox7.Checked == false)
                {
                    panel1.Controls.Clear();
                    panel1.Controls.Add(welcomeScreen);
                }
            }
        }
        // Quản lý khách hàng
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && activeCheckBox.Checked)
            {
                List<Control> ctrls = new List<Control>();
                foreach (Control c in panel1.Controls)
                    ctrls.Add(c);
                panel1.Controls.Clear();
                foreach (Control c in ctrls)
                {
                    if (c.Name != "WelcomeScreen")
                        c.Dispose();
                }
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                if (userAccountDTO.Authentication)
                {
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                }
                lastChecked = activeCheckBox;
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                CustomerModel customerModel = new CustomerModel(connstring);
                if (DataStructure<CustomerDTO>.Instance.Count() == 0)
                    customerModel.getAllData();
                CustomerManagementScreen customerManagementScreen = new CustomerManagementScreen();
                CustomerPresenter customerPresenter = new CustomerPresenter(customerModel, customerManagementScreen);
                panel1.Controls.Add(customerManagementScreen);
            }
            else
            {
                lastChecked = null;
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false
                    && checkBox6.Checked == false && checkBox7.Checked == false)
                {
                    panel1.Controls.Clear();
                    panel1.Controls.Add(welcomeScreen);
                }
            }
        }
        // Lịch sử bán hàng
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && activeCheckBox.Checked)
            {
                List<Control> ctrls = new List<Control>();
                foreach (Control c in panel1.Controls)
                    ctrls.Add(c);
                panel1.Controls.Clear();
                foreach (Control c in ctrls)
                {
                    if (c.Name != "WelcomeScreen")
                        c.Dispose();
                }
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                if (userAccountDTO.Authentication)
                {
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                }
                lastChecked = activeCheckBox;
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                ReceiptModel receiptModel = new ReceiptModel(connstring);
                if (DataStructure<ReceiptDTO>.Instance.Count() == 0)
                    receiptModel.getAllData();
                SalesHistoryScreen salesHistoryScreen = new SalesHistoryScreen();
                ReceiptPresenter receiptPresenter = new ReceiptPresenter(receiptModel, salesHistoryScreen);
                panel1.Controls.Add(salesHistoryScreen);
            }
            else
            {
                lastChecked = null;
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false
                    && checkBox6.Checked == false && checkBox7.Checked == false)
                {
                    panel1.Controls.Clear();
                    panel1.Controls.Add(welcomeScreen);
                }
            }
        }
        // Lịch làm việc
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && activeCheckBox.Checked)
            {
                List<Control> ctrls = new List<Control>();
                foreach (Control c in panel1.Controls)
                    ctrls.Add(c);
                panel1.Controls.Clear();
                foreach (Control c in ctrls)
                {
                    if (c.Name != "WelcomeScreen")
                        c.Dispose();
                }
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox5.Checked = false;
                if (userAccountDTO.Authentication)
                {
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                }
                lastChecked = activeCheckBox;
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                WorkshiftModel workshiftModel = new WorkshiftModel(connstring);
                if (DataStructure<WorkshiftDTO>.Instance.Count() == 0)
                    workshiftModel.getAllWorkshiftData();
                if (DataStructure<ShiftDetailsDTO>.Instance.Count() == 0)
                    foreach (EmployeeDTO employee in DataStructure<EmployeeDTO>.Instance)
                    {
                        workshiftModel.getAllShiftDetails(employee);
                    }
                WorkScheduleScreen workScheduleScreen = new WorkScheduleScreen(userAccountDTO.Authentication);
                WorkshiftPresenter workshiftPresenter = new WorkshiftPresenter(workshiftModel, workScheduleScreen);
                panel1.Controls.Add(workScheduleScreen);
            }
            else
            {
                lastChecked = null;
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false
                    && checkBox6.Checked == false && checkBox7.Checked == false)
                {
                    panel1.Controls.Clear();
                    panel1.Controls.Add(welcomeScreen);
                }
            }
        }
        // Quản lý sản phẩm
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && activeCheckBox.Checked)
            {
                List<Control> ctrls = new List<Control>();
                foreach (Control c in panel1.Controls)
                    ctrls.Add(c);
                panel1.Controls.Clear();
                foreach (Control c in ctrls)
                {
                    if (c.Name != "WelcomeScreen")
                        c.Dispose();
                }
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                if (userAccountDTO.Authentication)
                {
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                }
                lastChecked = activeCheckBox;
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                ProductModel productModel = new ProductModel(connstring);
                if (DataStructure<ProductDTO>.Instance.Count() == 0)
                    productModel.getAllData();
                ProductManagementScreen productManagementScreen = new ProductManagementScreen(userAccountDTO.Authentication);
                ProductPresenter productPresenter = new ProductPresenter(productModel, productManagementScreen);
                panel1.Controls.Add(productManagementScreen);
            }
            else
            {
                lastChecked = null;
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false
                    && checkBox6.Checked == false && checkBox7.Checked == false)
                {
                    panel1.Controls.Clear();
                    panel1.Controls.Add(welcomeScreen);
                }
            }
        }
        //Quản lý nhân viên
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && activeCheckBox.Checked)
            {
                List<Control> ctrls = new List<Control>();
                foreach (Control c in panel1.Controls)
                    ctrls.Add(c);
                panel1.Controls.Clear();
                foreach (Control c in ctrls)
                {
                    if (c.Name != "WelcomeScreen")
                        c.Dispose();
                }
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox7.Checked = false;
                lastChecked = activeCheckBox;
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                EmployeeModel employeeModel = new EmployeeModel(connstring);
                if (DataStructure<EmployeeDTO>.Instance.Count() == 0)
                    employeeModel.getAllData();
                EmployeeManagementScreen employeeManagementScreen = new EmployeeManagementScreen(userAccountDTO.Authentication);
                EmployeePresenter employeePresenter = new EmployeePresenter(employeeModel, employeeManagementScreen);
                panel1.Controls.Add(employeeManagementScreen);
            }
            else
            {
                lastChecked = null;
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false
                    && checkBox6.Checked == false && checkBox7.Checked == false)
                {
                    panel1.Controls.Clear();
                    panel1.Controls.Add(welcomeScreen);
                }
            }
        }
        // Thống kê
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && activeCheckBox.Checked)
            {
                List<Control> ctrls = new List<Control>();
                foreach (Control c in panel1.Controls)
                    ctrls.Add(c);
                panel1.Controls.Clear();
                foreach (Control c in ctrls)
                {
                    if (c.Name != "WelcomeScreen")
                        c.Dispose();
                }
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                lastChecked = activeCheckBox;
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                ReceiptModel receiptModel = new ReceiptModel(connstring);
                if (DataStructure<ReceiptDTO>.Instance.Count() == 0)
                    receiptModel.getAllData();
                ReportScreen reportScreen = new ReportScreen();

                panel1.Controls.Add(reportScreen);
            }
            else
            {
                lastChecked = null;
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false
                    && checkBox6.Checked == false && checkBox7.Checked == false)
                {
                    panel1.Controls.Clear();
                    panel1.Controls.Add(welcomeScreen);
                }
            }
        }
        // Xem thông tin cá nhân
        private void button7_Click(object sender, EventArgs e)
        {
            string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
            EmployeeModel employeeModel = new EmployeeModel(connstring);
            if (DataStructure<EmployeeDTO>.Instance.Count() == 0)
                employeeModel.getAllData();
            EmployeePresenter employeePresenter = new EmployeePresenter(employeeModel, employeeDTO);
        }
        // Đăng xuất
        private void button8_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            using (LoginForm loginForm = new LoginForm())
            {
                loginForm.ShowDialog();
                if (loginForm.DialogResult != DialogResult.Cancel)
                {
                    userAccountDTO = loginForm.GetUserAccount();
                    if (loginForm.Authentication == 1)
                        userAccountDTO.Authentication = true;
                    else userAccountDTO.Authentication = false;
                }
                else Environment.Exit(0);
            }
            InitializeComponent(userAccountDTO.Authentication);
            
            if (DataStructure<EmployeeDTO>.Instance.Count() == 0)
            {
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                EmployeeModel employeeModel = new EmployeeModel(connstring);
                employeeModel.getAllData();
            }
            employeeDTO = DataStructure<EmployeeDTO>.Instance.Find(x => x.ID == userAccountDTO.ID);
            label1.Text = "Xin chào, " + userAccountDTO.UserName;
            panel1.Controls.Add(welcomeScreen);
        }
    }
}
