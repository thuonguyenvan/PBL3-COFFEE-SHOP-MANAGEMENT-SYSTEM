using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.DTO
{
    public class ProductTypeDTO
    {
        private string _ID;
        private string _Type;
        public string ID { get { return _ID; } set { _ID = value; } }
        public string Type { get { return _Type; } set { _Type = value; } }
        public ProductTypeDTO(string ID, string Type)
        {
            _ID = ID;
            _Type = Type;
        }
    }
}
