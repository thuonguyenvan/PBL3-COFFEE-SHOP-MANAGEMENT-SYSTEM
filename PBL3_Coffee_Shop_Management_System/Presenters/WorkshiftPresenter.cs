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
        private WorkshiftManagementForm _mform;
        public WorkshiftPresenter(WorkshiftModel model, WorkScheduleScreen view)
        {
            _model = model;
            _view = view;
            _view.AddShift += OnAddShiftDetails;
            _view.DeleteShift += OnDeleteShiftDetails;
        }
        public WorkshiftPresenter(WorkshiftModel model, ShiftCompletedForm form)
        {
            _model = model;
            _form = form;
            _form.UpdateShift += OnUpdateShiftDetails;
        }
        public WorkshiftPresenter(WorkshiftModel model, WorkshiftManagementForm form)
        {
            _model = model;
            _mform = form;
            _mform.GetAllWorkshift += OnGetAllWorkshift;
            _mform.AddWorkshift += OnAddWorkshift;
            _mform.DeleteWorkshift += OnDeleteWorkshift;
            _mform.UpdateWorkshift += OnUpdateWorkshift;
        }
        private void OnAddShiftDetails(object sender, ShiftDetailsEventArgs e)
        {
            DataStructure<ShiftDetailsDTO>.Instance.Add(e.shift[0]);
            _model.AddShiftDetails(e.shift[0].Employee, e.shift[0].Workshift, e.shift[0].Day);
        }
        private void OnDeleteShiftDetails(object sender, ShiftDetailsEventArgs e)
        {
            foreach (ShiftDetailsDTO s in e.shift)
            {
                DataStructure<ShiftDetailsDTO>.Instance.RemoveAll(x => x.Employee.ID == e.shift[0].Employee.ID &&
                    x.Workshift.ID == e.shift[0].Workshift.ID && x.Day == e.shift[0].Day);
                _model.DeleteShiftDetails(s.Employee, s.Workshift, s.Day);
            }
        }
        private void OnUpdateShiftDetails(object sender, ShiftDetailsEventArgs e)
        {
            DataStructure<ShiftDetailsDTO>.Instance.Find(x => x.Employee.ID == e.shift[0].Employee.ID
                    && x.Workshift.ID == e.shift[0].Workshift.ID && x.Day == e.shift[0].Day).isCompleted = true;
            _model.UpdateShiftDetails(e.shift[0].Employee, e.shift[0].Workshift, e.shift[0].Day, true);
            _model.UpdateHoursWorked(e.shift[0].Employee, e.shift[0].Workshift, e.shift[0].Day.ToString("MM/yyyy"));
        }
        private void OnGetAllWorkshift(object sender, EventArgs e)
        {
            if (DataStructure<WorkshiftDTO>.Instance.Count == 0)
                _model.getAllWorkshiftData();
        }
        private void OnAddWorkshift(object sender, WorkshiftEventArgs e)
        {
            _model.AddWorkshift(e.workshifts[0]);
            DataStructure<WorkshiftDTO>.Instance.Add(e.workshifts[0]);
        }
        private void OnDeleteWorkshift(object sender, WorkshiftEventArgs e)
        {
            foreach (WorkshiftDTO workshift in e.workshifts)
            {
                _model.DeleteWorkshift(workshift);
                DataStructure<WorkshiftDTO>.Instance.RemoveAll(x => x.ID == workshift.ID);
            }
        }
        private void OnUpdateWorkshift(object sender, WorkshiftEventArgs e)
        {
            using (WorkshiftDetailsForm form = new WorkshiftDetailsForm(e.workshifts[0]))
            {
                form.ShowDialog();
                if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    WorkshiftDTO workshift = new WorkshiftDTO(form.ID, form.StartTime, form.EndTime);
                    DataStructure<WorkshiftDTO>.Instance[DataStructure<WorkshiftDTO>.Instance.FindIndex(x => x.ID == e.workshifts[0].ID)] = workshift;
                    _model.UpdateWorkshift(workshift);
                }
            }
        }
    }
}
