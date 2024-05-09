using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.DTO
{
    internal class UserAccountDTO
    {
        private string _ID;
        private string _UserName;
        private string _Password;
        private bool _Authentication;
        private List<UserAccountDTO> _list = new List<UserAccountDTO>();
        public List<UserAccountDTO> list { get { return _list; } set { } }
        private static UserAccountDTO _Instance;
        public static UserAccountDTO Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new UserAccountDTO();
                return _Instance;
            }
            private set { }
        }
        public string ID { get { return _ID; } set { _ID = value; } }
        public string UserName { get { return _UserName; } set { _UserName = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public bool Authentication { get { return _Authentication; } set { _Authentication = value; } }
        public UserAccountDTO() { }
        public UserAccountDTO(string ID, string UserName, string Password)
        {
            _ID = ID;
            _UserName = UserName;
            _Password = Password;
        }
    }
}
