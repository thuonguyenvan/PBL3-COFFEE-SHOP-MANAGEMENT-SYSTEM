using PBL3_Coffee_Shop_Management_System.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.EventArguments
{
    public class ShiftDetailsEventArgs
    {
        private readonly List<ShiftDetailsDTO> _shift;
        public ShiftDetailsEventArgs(List<ShiftDetailsDTO> shift)
        {
            _shift = shift;
        }
        public List<ShiftDetailsDTO> shift
        {
            get { return _shift; }
        }
    }
}
