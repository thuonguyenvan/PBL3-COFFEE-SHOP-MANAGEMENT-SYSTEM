using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.DTO
{
    public class WorkshiftDTO
    {
        private string _ID;
        private TimeSpan _StartTime;
        private TimeSpan _EndTime;
        public string ID { get {  return _ID; } set { _ID = value; } }
        public TimeSpan StartTime { get { return _StartTime; } set { _StartTime = value; } }
        public TimeSpan EndTime { get { return _EndTime; } set { _EndTime = value; } }
        public WorkshiftDTO() { }
        public WorkshiftDTO(string ID, TimeSpan StartTime, TimeSpan EndTime)
        {
            _ID = ID;
            _StartTime = StartTime;
            _EndTime = EndTime;
        }
    }
}
