using PBL3_Coffee_Shop_Management_System.Models;
using PBL3_Coffee_Shop_Management_System.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.Presenters
{
    internal class EmployeePresenter : IPresenter
    {
        private EmployeeModel _model;
        private EmployeeManagementScreen _view;
        public EmployeePresenter(EmployeeModel model, EmployeeManagementScreen view)
        {
            _model = model;
            _view = view;
        }
        public void OnGetAllData(object sender, EventArgs e)
        {
            _model.getAllData();
        }
    }
}
