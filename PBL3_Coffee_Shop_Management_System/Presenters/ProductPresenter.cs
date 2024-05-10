using PBL3_Coffee_Shop_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_Coffee_Shop_Management_System.Views;
using PBL3_Coffee_Shop_Management_System.DTO;
using PBL3_Coffee_Shop_Management_System.EventArguments;

namespace PBL3_Coffee_Shop_Management_System.Presenters
{
    internal class ProductPresenter : IPresenter
    {
        private ProductModel _model;
        private ProductManagementScreen _view;
        public ProductPresenter(ProductModel model, ProductManagementScreen view)
        {
            _model = model;
            _view = view;
            _view.AddProduct += OnAddProduct;
            _view.DeleteProduct += OnDeleteProduct;
            _view.UpdateProduct += OnUpdateProduct;
        }
        public void OnAddProduct(object sender, EventArgs e)
        {
            using (ProductDetailsForm productDetailsForm = new ProductDetailsForm())
            {
                productDetailsForm.ShowDialog();
                if (productDetailsForm.DialogResult != System.Windows.Forms.DialogResult.Cancel)
                {
                    ProductDTO.Instance.list.Add(productDetailsForm.GetData());
                    _model.Add(ProductDTO.Instance);
                }
            }
        }
        public void OnDeleteProduct(object sender, ProductEventArgs e)
        {
            foreach (ProductDTO product in e.product)
            {
                ProductDTO.Instance.list.Remove(product);
                _model.Delete(product);
            }
        }
        public void OnUpdateProduct(object sender, ProductEventArgs e)
        {
            using (ProductDetailsForm productDetailsForm = new ProductDetailsForm(e.product[0]))
            {
                productDetailsForm.ShowDialog();
                if (productDetailsForm.DialogResult != System.Windows.Forms.DialogResult.Cancel)
                {
                    ProductDTO.Instance.list[ProductDTO.Instance.list.FindIndex(x => x.ID == e.product[0].ID)] = productDetailsForm.GetData();
                    _model.Update(ProductDTO.Instance);
                }
            }
        }
    }
}
