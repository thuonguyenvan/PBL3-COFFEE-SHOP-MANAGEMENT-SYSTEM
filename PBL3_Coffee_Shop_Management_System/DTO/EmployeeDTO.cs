﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.DTO
{
    public class EmployeeDTO
    {
        private string _ID;
        private string _Name;
        private bool _Gender;
        private DateTime _DateOfBirth;
        private string _Address;
        private string _PhoneNum;
        private string _Email;
        private bool _isFullTime;
        private List<EmployeeDTO> _list = new List<EmployeeDTO>();
        public List<EmployeeDTO> list { get { return _list; } set { } }
        private static EmployeeDTO _Instance;
        public static EmployeeDTO Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new EmployeeDTO();
                return _Instance;
            }
            set { _Instance = value; }
        }
        public string ID { get { return _ID; } set { _ID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public bool Gender { get { return _Gender; } set { _Gender = value; } }
        public DateTime DateOfBirth { get { return _DateOfBirth; } set { _DateOfBirth = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public string PhoneNum { get { return _PhoneNum; } set { _PhoneNum = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public bool isFullTime { get { return _isFullTime; } set { _isFullTime = value; } }
        public EmployeeDTO() { }
        public EmployeeDTO(string ID, string Name, bool Gender, DateTime DateOfBirth, string Address, string PhoneNum, string Email, bool isFullTime)
        {
            _ID = ID;
            _Name = Name;
            _Gender = Gender;
            _DateOfBirth = DateOfBirth;
            _Address = Address;
            _PhoneNum = PhoneNum;
            _Email = Email;
            _isFullTime = isFullTime;
        }
    }
}