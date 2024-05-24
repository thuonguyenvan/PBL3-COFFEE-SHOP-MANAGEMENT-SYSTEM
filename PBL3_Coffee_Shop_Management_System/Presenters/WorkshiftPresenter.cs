using PBL3_Coffee_Shop_Management_System.DTO;
using PBL3_Coffee_Shop_Management_System.EventArguments;
using PBL3_Coffee_Shop_Management_System.Models;
using PBL3_Coffee_Shop_Management_System.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Coffee_Shop_Management_System.Presenters
{
    internal class WorkshiftPresenter
    {
        private WorkshiftModel _model;
        private WorkScheduleScreen _view;
        public WorkshiftPresenter(WorkshiftModel model, WorkScheduleScreen view)
        {
            _model = model;
            _view = view;
            _view.AddShift += OnAddShift;
            _view.DeleteShift += OnDeleteShift;
        }
        private void OnAddShift(object sender, ShiftDetailsEventArgs e)
        {
            _model.AddShiftDetails(e.shift[0].Employee, e.shift[0].Workshift, e.shift[0].Day);
        }
        private void OnDeleteShift(object sender, ShiftDetailsEventArgs e)
        {
            foreach (ShiftDetailsDTO s in e.shift)
            {
                _model.DeleteShiftDetails(s.Employee, s.Workshift, s.Day);
            }
        }
    }
}
