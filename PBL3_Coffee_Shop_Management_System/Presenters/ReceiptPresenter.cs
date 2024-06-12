using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_Coffee_Shop_Management_System.DTO;
using PBL3_Coffee_Shop_Management_System.EventArguments;
using PBL3_Coffee_Shop_Management_System.Models;
using PBL3_Coffee_Shop_Management_System.Views;

namespace PBL3_Coffee_Shop_Management_System.Presenters
{
    internal class ReceiptPresenter
    {
        private ReceiptModel _model;
        private ConfirmOrderForm _coview;
        private SalesHistoryScreen _shview;
        public ReceiptPresenter(ReceiptModel model, ConfirmOrderForm coview)
        {
            _model = model;
            _coview = coview;
            _coview.AddReceipt += OnAddReceipt;
        }
        public ReceiptPresenter(ReceiptModel model, SalesHistoryScreen shview)
        {
            _model = model;
            _shview = shview;
            _shview.DeleteReceipt += OnDeleteReceipt;
        }
        private void OnAddReceipt(object sender, ReceiptEventArgs e)
        {
            if (DataStructure<ReceiptDTO>.Instance.Count == 0)
                _model.getAllData();
            string s = DataStructure<ReceiptDTO>.Instance.Last().ReceiptID;
            s = s.Remove(0, 1);
            int i = Convert.ToInt32(s);
            i += 1;
            s = "R";
            s += i.ToString();
            if (s.Length < 6) s = s.Insert(1, string.Concat(Enumerable.Repeat("0", 6 - s.Length)));
            while (DataStructure<ReceiptDTO>.Instance.Find(x => x.ReceiptID == s) != null)
            {
                s.Remove(1, 5);
                i++;
                s += i.ToString();
                if (s.Length < 6) s = s.Insert(1, string.Concat(Enumerable.Repeat("0", 6 - s.Length)));
            }
            e.receipt[0].ReceiptID = s;
            foreach (ProductDTO p in e.receipt[0].Products)
            {
                p.ID = DataStructure<ProductDTO>.Instance.Find(x => x.Name == p.Name).ID;
                p.Price = DataStructure<ProductDTO>.Instance.Find(x => x.Name == p.Name).Price;
            }
            _model.Add(e.receipt[0]);
            DataStructure<ReceiptDTO>.Instance.Add(e.receipt[0]);
        }
        private void OnDeleteReceipt(object sender, EventArgs e)
        {
            if (DataStructure<CustomerDTO>.Instance.Count == 0)
            {
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                CustomerModel customerModel = new CustomerModel(connstring);
                customerModel.getAllData();
            }
            List<string> list = sender as List<string>;
            foreach (string s in list)
            {
                ReceiptDTO receipt = DataStructure<ReceiptDTO>.Instance.Find(x => x.ReceiptID == s);
                CustomerDTO customer = DataStructure<CustomerDTO>.Instance.Find(x => x.ID == receipt.CustomerID);
                if (customer != null) customer.Points -= (int)((receipt.Total.Sum() - receipt.Discount) * Form1.Instance.MoneyToPoints);
                _model.Delete(s);
                DataStructure<ReceiptDTO>.Instance.RemoveAll(x => x.ReceiptID == s);
            }
        }
    }
}
