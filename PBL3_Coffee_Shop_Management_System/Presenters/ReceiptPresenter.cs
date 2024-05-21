﻿using System;
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
        private void OnAddReceipt(object sender, ReceiptEventArgs e)
        {
            if (DataStructure<ReceiptDTO>.Instance.Count == 0)
                _model.getAllData();
            e.receipt[0].ReceiptID = (Convert.ToInt32(DataStructure<ReceiptDTO>.Instance.LastOrDefault().ReceiptID)+1).ToString();
            foreach (ProductDTO p in e.receipt[0].Products)
            {
                p.ID = DataStructure<ProductDTO>.Instance.Find(x => x.Name == p.Name).ID;
                p.Price = DataStructure<ProductDTO>.Instance.Find(x => x.Name == p.Name).Price;
            }
            _model.Add(e.receipt[0]);
            DataStructure<ReceiptDTO>.Instance.Add(e.receipt[0]);
        }
    }
}
