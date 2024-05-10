using PBL3_Coffee_Shop_Management_System.DTO;
using PBL3_Coffee_Shop_Management_System.EventArguments;
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
            _view.AddEmployee += OnAddEmployee;
            _view.DeleteEmployee += OnDeleteEmployee;
            _view.UpdateEmployee += OnUpdateEmployee;
        }
        public void OnGetAllData(object sender, EventArgs e)
        {
            _model.getAllData();
        }
        public void OnAddEmployee(object sender, EventArgs e)
        {
            using (EmployeeDetailsForm employeeDetailsForm = new EmployeeDetailsForm())
            {
                employeeDetailsForm.ShowDialog();
                if (employeeDetailsForm.DialogResult != System.Windows.Forms.DialogResult.Cancel)
                {
                    EmployeeDTO employee = employeeDetailsForm.GetData();
                    DataStructure<EmployeeDTO>.Instance.Add(employee);
                    _model.Add(employee);
                    UserAccountModel userAccountModel = new UserAccountModel("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                    userAccountModel.Add(DataStructure<UserAccountDTO>.Instance.Last());
                }
            }
        }
        public void OnDeleteEmployee(object sender, EmployeeEventArgs e)
        {
            foreach (EmployeeDTO employee in e.employee)
            {
                DataStructure<EmployeeDTO>.Instance.Remove(employee);
                _model.Delete(employee);
                UserAccountModel userAccountModel = new UserAccountModel("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                userAccountModel.Delete(DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == employee.ID));
            }
        }
        public void OnUpdateEmployee(object sender, EmployeeEventArgs e)
        {
            using (EmployeeDetailsForm employeeDetailsForm = new EmployeeDetailsForm(e.employee[0]))
            {
                employeeDetailsForm.ShowDialog();
                if (employeeDetailsForm.DialogResult != System.Windows.Forms.DialogResult.Cancel)
                {
                    EmployeeDTO employee = employeeDetailsForm.GetData();
                    DataStructure<EmployeeDTO>.Instance[DataStructure<EmployeeDTO>.Instance.FindIndex(x => x.ID == e.employee[0].ID)] = employee;
                    _model.Update(employee);
                    UserAccountModel userAccountModel = new UserAccountModel("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                    userAccountModel.Update(DataStructure<UserAccountDTO>.Instance.Find(x => x.ID == employee.ID));
                }
            }
        }
    }
}
