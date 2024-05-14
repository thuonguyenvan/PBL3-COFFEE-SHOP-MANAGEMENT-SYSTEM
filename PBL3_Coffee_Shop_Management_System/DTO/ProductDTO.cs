using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.DTO
{
    public class ProductDTO
    {
        private string _ID;
        private string _Name;
        private int _Price;
        private string _Unit;
        private int _Type;
        public string ID { get { return _ID; } set { _ID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public int Price { get { return _Price; } set { _Price = value; } }
        public string Unit { get { return _Unit; } set { _Unit = value; } }
        public int Type { get { return _Type; } set { _Type = value; } }
        public ProductDTO() { }
        public ProductDTO(string ID, string Name, int Price, string Unit, int Type)
        {
            _ID = ID;
            _Name = Name;
            _Price = Price;
            _Unit = Unit;
            _Type = Type;
        }
    }
}
