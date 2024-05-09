using PBL3_Coffee_Shop_Management_System.Models;
using PBL3_Coffee_Shop_Management_System.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.Presenters
{
    internal class UserAccountPresenter : IPresenter
    {
        private UserAccountModel _model;
        private Form1 _view;
        public UserAccountPresenter(UserAccountModel model, Form1 view)
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
