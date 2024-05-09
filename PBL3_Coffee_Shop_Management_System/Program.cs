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
            //Application.Run(new Form1());
            string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
            UserAccountModel userAccountModel = new UserAccountModel(connstring);
            userAccountModel.getAllData();
            Form1 form1 = new Form1();
            UserAccountPresenter userAccountPresenter = new UserAccountPresenter(userAccountModel, form1);
            Application.Run(form1);
        }
    }
}
