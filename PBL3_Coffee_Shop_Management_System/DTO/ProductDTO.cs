﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.DTO
{
    internal class ProductDTO
    {
        private int _ID;
        private string _Name;
        private int _Price;
        private string _Unit;
        private int _Type;
        private List<ProductDTO> _list = new List<ProductDTO>();
        private static ProductDTO _Instance;
        public static ProductDTO Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ProductDTO();
                return _Instance;
            }
            private set { }
        }
        public int ID { get { return _ID; } set { _ID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public int Price { get { return _Price; } set { _Price = value; } }
        public string Unit { get { return _Unit; } set { _Unit = value; } }
        public int Type { get { return _Type; } set { _Type = value; } }
        public ProductDTO() { }
        public ProductDTO(int ID, string Name, int Price, string Unit, int Type)
        {
            _ID = ID;
            _Name = Name;
            _Price = Price;
            _Unit = Unit;
            _Type = Type;
        }
        public List<ProductDTO> list { get { return _list; } set { } }
    }
}
