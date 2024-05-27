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
        private ShiftCompletedForm _form;
        public WorkshiftPresenter(WorkshiftModel model, WorkScheduleScreen view)
        {
            _model = model;
            _view = view;
            _view.AddShift += OnAddShift;
            _view.DeleteShift += OnDeleteShift;
        }
        public WorkshiftPresenter(WorkshiftModel model, ShiftCompletedForm form)
        {
            _model = model;
            _form = form;
            _form.UpdateShift += OnUpdateShift;
        }
        private void OnAddShift(object sender, ShiftDetailsEventArgs e)
        {
            DataStructure<ShiftDetailsDTO>.Instance.Add(e.shift[0]);
            _model.AddShiftDetails(e.shift[0].Employee, e.shift[0].Workshift, e.shift[0].Day);
        }
        private void OnDeleteShift(object sender, ShiftDetailsEventArgs e)
        {
            foreach (ShiftDetailsDTO s in e.shift)
            {
                DataStructure<ShiftDetailsDTO>.Instance.RemoveAll(x => x.Employee.ID == e.shift[0].Employee.ID &&
                    x.Workshift.ID == e.shift[0].Workshift.ID && x.Day == e.shift[0].Day);
                _model.DeleteShiftDetails(s.Employee, s.Workshift, s.Day);
            }
        }
        private void OnUpdateShift(object sender, ShiftDetailsEventArgs e)
        {
            DataStructure<ShiftDetailsDTO>.Instance.Find(x => x.Employee.ID == e.shift[0].Employee.ID
                    && x.Workshift.ID == e.shift[0].Workshift.ID && x.Day == e.shift[0].Day).isCompleted = true;
            _model.UpdateShiftDetails(e.shift[0].Employee, e.shift[0].Workshift, e.shift[0].Day, true);
            _model.UpdateHoursWorked(e.shift[0].Employee, e.shift[0].Workshift, e.shift[0].Day.ToString("MM/yyyy"));
        }
    }
}
