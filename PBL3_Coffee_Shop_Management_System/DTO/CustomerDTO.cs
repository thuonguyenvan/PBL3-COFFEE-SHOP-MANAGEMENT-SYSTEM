﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.DTO
{
    internal class CustomerDTO
    {
        private int _ID;
        private string _Name;
        private string _PhoneNum;
        private string _Email;
        private int _Points;
        private List<CustomerDTO> _list = new List<CustomerDTO>();
        public List<CustomerDTO> list { get { return _list; } set { } }
        private static CustomerDTO _Instance;
        public static CustomerDTO Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CustomerDTO();
                return _Instance;
            }
            private set { }
        }
        public int ID { get { return _ID; } set { _ID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string PhoneNum { get { return _PhoneNum; } set { _PhoneNum = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public int Points { get { return _Points; } set { _Points = value; } }
        public CustomerDTO() { }
        public CustomerDTO(int ID, string Name, string PhoneNum, string Email, int Points)
        {
            _ID = ID;
            _Name = Name;
            _PhoneNum = PhoneNum;
            _Email = Email;
            _Points = Points;
        }
        
    }
}
