using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_Coffee_Shop_Management_System.Models;
using PBL3_Coffee_Shop_Management_System.Presenters;
using PBL3_Coffee_Shop_Management_System.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PBL3_Coffee_Shop_Management_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string Server = "localhost";
            string UserName = "root";
            string Password = "";
            string DatabaseName = "DATA";
            string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3};", Server, DatabaseName, UserName, Password);
            ProductModel productModel = new ProductModel(connstring);
            //Application.Run(new Form1());
            Form1 form1 = new Form1();
            ProductPresenter productPresenter = new ProductPresenter(productModel, form1);
            Application.Run(form1);
        }
    }
}
