using PBL3_Coffee_Shop_Management_System.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.EventArguments
{
    public class ReceiptEventArgs
    {
        private readonly List<ReceiptDTO> _receipt;
        public ReceiptEventArgs(List<ReceiptDTO> receipt)
        {
            _receipt = receipt;
        }
        public List<ReceiptDTO> receipt
        {
            get { return _receipt; }
        }
    }
}
