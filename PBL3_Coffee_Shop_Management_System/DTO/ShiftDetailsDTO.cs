using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.DTO
{
    public class ShiftDetailsDTO
    {
        private EmployeeDTO _employee;
        private WorkshiftDTO _workshift;
        private DateTime _day;
        private bool _isCompleted;
        public EmployeeDTO Employee { get { return _employee; } set { _employee = value; } }
        public WorkshiftDTO Workshift { get { return _workshift; } set { _workshift = value; } }
        public DateTime Day { get { return _day; } set { _day = value; } }
        public bool isCompleted { get { return _isCompleted; } set { _isCompleted = value; } }
        public ShiftDetailsDTO() { }
        public ShiftDetailsDTO(EmployeeDTO employee, WorkshiftDTO workshift, DateTime day, bool isCompleted)
        {
            _employee = employee;
            _workshift = workshift;
            _day = day;
            _isCompleted = isCompleted;
        }
    }
}
