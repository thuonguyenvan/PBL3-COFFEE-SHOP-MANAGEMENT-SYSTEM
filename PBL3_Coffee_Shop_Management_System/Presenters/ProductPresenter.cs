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
        private ProductCategoryManagementForm _form;
        public ProductPresenter(ProductModel model, ProductManagementScreen view)
        {
            _model = model;
            _view = view;
            _view.AddProduct += OnAddProduct;
            _view.DeleteProduct += OnDeleteProduct;
            _view.UpdateProduct += OnUpdateProduct;
            _view.GetAllType += OnGetAllType;
        }
        public ProductPresenter(ProductModel model, ProductCategoryManagementForm form)
        {
            _model = model;
            _form = form;
            _form.AddType += OnAddType;
            _form.GetAllType += OnGetAllType;
            _form.DeleteType += OnDeleteType;
            _form.UpdateType += OnUpdateType;
        }
        public void OnAddProduct(object sender, EventArgs e)
        {
            using (ProductDetailsForm productDetailsForm = new ProductDetailsForm())
            {
                productDetailsForm.ShowDialog();
                if (productDetailsForm.DialogResult != System.Windows.Forms.DialogResult.Cancel)
                {
                    ProductDTO product = productDetailsForm.GetData();
                    DataStructure<ProductDTO>.Instance.Add(product);
                    _model.Add(product);
                }
            }
        }
        public void OnDeleteProduct(object sender, ProductEventArgs e)
        {
            foreach (ProductDTO product in e.product)
            {
                DataStructure<ProductDTO>.Instance.RemoveAll(x => x.ID == product.ID);
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
                    ProductDTO product = productDetailsForm.GetData();
                    DataStructure<ProductDTO>.Instance[DataStructure<ProductDTO>.Instance.FindIndex(x => x.ID == e.product[0].ID)] = product;
                    _model.Update(product);
                }
            }
        }
        public void OnGetAllType(object sender, EventArgs e)
        {
            if (DataStructure<ProductTypeDTO>.Instance.Count == 0)
                _model.GetAllType();
        }
        public void OnAddType(object sender, ProductCategoryEventArgs e)
        {
            _model.AddProductType(e.ProductTypes[0]);
            DataStructure<ProductTypeDTO>.Instance.Add(e.ProductTypes[0]);
        }
        public void OnDeleteType(object sender, ProductCategoryEventArgs e)
        {
            foreach (ProductTypeDTO productTypeDTO in e.ProductTypes)
            {
                _model.DeleteProductType(productTypeDTO);
                DataStructure<ProductTypeDTO>.Instance.RemoveAll(x => x.ID == productTypeDTO.ID);
            }
        }
        public void OnUpdateType(object sender, ProductCategoryEventArgs e)
        {
            using (ProductCategoryDetailsForm form = new ProductCategoryDetailsForm(e.ProductTypes[0]))
            {
                form.ShowDialog();
                if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    ProductTypeDTO productType = new ProductTypeDTO(form.TypeID, form.TypeName);
                    DataStructure<ProductTypeDTO>.Instance[DataStructure<ProductTypeDTO>.Instance.FindIndex(x => x.ID == e.ProductTypes[0].ID)] = productType;
                    _model.UpdateProductType(productType);
                }
            }
        }
    }
}
