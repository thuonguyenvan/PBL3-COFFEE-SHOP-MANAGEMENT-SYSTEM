using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System
{
    internal class DataStructure
    {
        private int _Code;
        private string _Name;
        private int _Price;
        private string _Unit;
        private string _Type;
        private List<DataStructure> _list = new List<DataStructure>();
        private static DataStructure _Instance;
        public static DataStructure Instance
        {
            get { if (_Instance == null)
                    _Instance = new DataStructure();
                return _Instance;
            }
            private set { }
        }
        public int Code { get { return _Code; } set { _Code = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public int Price { get { return _Price; } set { _Price = value; } }
        public string Unit { get { return _Unit; } set { _Unit = value; } }
        public string Type { get { return _Type; } set { _Type = value; } }
        public DataStructure() { }
        public DataStructure(int Code, string Name, int Price, string Unit, string Type)
        {
            _Code = Code;
            _Name = Name;
            _Price = Price;
            _Unit = Unit;
            _Type = Type;
        }
        public List<DataStructure> list { get { return _list; } set { } }
    }
}
