using PBL3_Coffee_Shop_Management_System.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.EventArguments
{
    public class WorkshiftEventArgs : EventArgs
    {
        private readonly List<WorkshiftDTO> _workshifts;
        public WorkshiftEventArgs (List<WorkshiftDTO> workshift)
        {
            _workshifts = workshift;
        }
        public List<WorkshiftDTO> workshifts { get { return _workshifts; } }
    }
}
