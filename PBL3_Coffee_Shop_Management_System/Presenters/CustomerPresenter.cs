using PBL3_Coffee_Shop_Management_System.DTO;
using PBL3_Coffee_Shop_Management_System.Models;
using PBL3_Coffee_Shop_Management_System.Views;
using PBL3_Coffee_Shop_Management_System.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.Presenters
{
    internal class CustomerPresenter : IPresenter
    {
        private CustomerModel _model;
        private CustomerManagementScreen _view;
        public CustomerPresenter(CustomerModel model, CustomerManagementScreen view)
        {
            _model = model;
            _view = view;
            _view.AddCustomer += OnAddCustomer;
            _view.DeleteCustomer += OnDeleteCustomer;
            _view.UpdateCustomer += OnUpdateCustomer;
        }
        public void OnAddCustomer(object sender, EventArgs e)
        {
            using (CustomerDetailsForm customerDetailsForm = new CustomerDetailsForm())
            {
                customerDetailsForm.ShowDialog();
                if (customerDetailsForm.DialogResult != System.Windows.Forms.DialogResult.Cancel)
                {
                    CustomerDTO.Instance.list.Add(customerDetailsForm.GetData());
                    _model.Add(CustomerDTO.Instance);
                }
            }
        }
        public void OnDeleteCustomer(object sender, CustomerEventArgs e)
        {
            foreach (CustomerDTO customer in e.customer)
            {
                CustomerDTO.Instance.list.Remove(customer);
                _model.Delete(customer);
            }
        }
        public void OnUpdateCustomer(object sender, CustomerEventArgs e)
        {
            using (CustomerDetailsForm customerDetailsForm = new CustomerDetailsForm(e.customer[0]))
            {
                customerDetailsForm.ShowDialog();
                if (customerDetailsForm.DialogResult != System.Windows.Forms.DialogResult.Cancel)
                {
                    CustomerDTO.Instance.list[CustomerDTO.Instance.list.FindIndex(x => x.ID == e.customer[0].ID)] = customerDetailsForm.GetData();
                    _model.Update(CustomerDTO.Instance);
                }
            }
        }
    }
}
