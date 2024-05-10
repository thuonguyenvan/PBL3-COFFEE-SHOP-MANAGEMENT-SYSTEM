using PBL3_Coffee_Shop_Management_System.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.EventArguments
{
    public class EmployeeEventArgs : EventArgs
    {
        private readonly List<EmployeeDTO> _employee;
        public EmployeeEventArgs(List<EmployeeDTO> employee)
        {
            _employee = employee;
        }
        public List<EmployeeDTO> employee
        {
            get { return _employee; }
        }
    }
}
