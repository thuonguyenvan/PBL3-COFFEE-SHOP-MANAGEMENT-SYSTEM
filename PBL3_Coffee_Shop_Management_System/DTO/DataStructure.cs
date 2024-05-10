using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.DTO
{
    public class DataStructure<T> : List<T> where T : class
    {
        private static DataStructure<T> _Instance;
        public static DataStructure<T> Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new DataStructure<T>();
                return _Instance;
            }
            set { _Instance = value; }
        }
    }
}
