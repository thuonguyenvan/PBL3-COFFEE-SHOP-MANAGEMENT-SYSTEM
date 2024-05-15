using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.DTO
{
    public class ReceiptDTO
    {
        private string _ReceiptID;
        private DateTime _TransactionTime;
        private string _EmployeeID;
        private string _CustomerID;
        private int _TableNum;
        private int _Discount;
        private List<ProductDTO> _Products;
        private List<int> _Quantity;
        private List<int> _Total;
        public string ReceiptID { get { return _ReceiptID; } set { _ReceiptID = value; } }
        public DateTime TransactionTime { get { return _TransactionTime; } set { _TransactionTime = value; } }
        public string EmployeeID { get { return _EmployeeID; } set { _EmployeeID = value; } }
        public string CustomerID { get { return _CustomerID; } set { _CustomerID = value; } }
        public int TableNum { get { return _TableNum; } set { _TableNum = value; } }
        public int Discount { get { return _Discount; } set { _Discount = value; } }
        public List<ProductDTO> Products { get { return _Products; } set { _Products = value; } }
        public List<int> Quantity { get { return _Quantity; } set { _Quantity = value; } }
        public List<int> Total { get { return _Total; } set { _Total = value; } }
        public ReceiptDTO() { }
        public ReceiptDTO(string ReceiptID, DateTime TransactionTime, string EmployeeID, string CustomerID, int TableNum, int Discount)
        {
            _ReceiptID = ReceiptID;
            _TransactionTime = TransactionTime;
            _EmployeeID = EmployeeID;
            _CustomerID = CustomerID;
            _TableNum = TableNum;
            _Discount = Discount;
        }
    }
}
