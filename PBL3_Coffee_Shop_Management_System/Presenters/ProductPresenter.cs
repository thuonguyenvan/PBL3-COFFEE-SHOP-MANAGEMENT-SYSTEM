using PBL3_Coffee_Shop_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_Coffee_Shop_Management_System.Views;

namespace PBL3_Coffee_Shop_Management_System.Presenters
{
    internal class ProductPresenter : IPresenter
    {
        private ProductModel _model;
        private Form1 _view;
        public ProductPresenter(ProductModel model, Form1 view)
        {
            _model = model;
            _view = view;
            _view.GetAllData += OnGetAllData;
        }
        public void OnGetAllData(object sender, EventArgs e)
        {
            _model.getAllData();
        }
    }
}
