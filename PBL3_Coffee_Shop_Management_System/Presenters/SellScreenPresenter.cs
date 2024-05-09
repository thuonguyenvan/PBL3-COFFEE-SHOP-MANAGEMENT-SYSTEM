using PBL3_Coffee_Shop_Management_System.Models;
using PBL3_Coffee_Shop_Management_System.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.Presenters
{
    internal class SellScreenPresenter : IPresenter
    {
        private ProductModel _model;
        private SellScreen _view;
        public SellScreenPresenter(ProductModel model, SellScreen view)
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
