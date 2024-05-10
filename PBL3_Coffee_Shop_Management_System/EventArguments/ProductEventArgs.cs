using PBL3_Coffee_Shop_Management_System.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.EventArguments
{
    public class ProductEventArgs
    {
        private readonly List<ProductDTO> _product;
        public ProductEventArgs(List<ProductDTO> product)
        {
            _product = product;
        }
        public List<ProductDTO> product
        {
            get { return _product; }
        }
    }
}
