using PBL3_Coffee_Shop_Management_System.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.EventArguments
{
    public class CustomerEventArgs : EventArgs
    {
        private readonly List<CustomerDTO> _customer;
        public CustomerEventArgs(List<CustomerDTO> customer)
        {
            _customer = customer;
        }
        public List<CustomerDTO> customer
        {
            get { return _customer; }
        }
    }
}
