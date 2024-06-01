using PBL3_Coffee_Shop_Management_System.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.EventArguments
{
    public class ProductCategoryEventArgs : EventArgs
    {
        private readonly List<ProductTypeDTO> _productTypes;
        public ProductCategoryEventArgs (List<ProductTypeDTO> productTypes)
        {
            _productTypes = productTypes;
        }
        public List<ProductTypeDTO> ProductTypes { get { return _productTypes; } }
    }
}
