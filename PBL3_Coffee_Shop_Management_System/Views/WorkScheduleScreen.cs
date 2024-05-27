using PBL3_Coffee_Shop_Management_System.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_Coffee_Shop_Management_System.EventArguments;
using PBL3_Coffee_Shop_Management_System.Models;
using PBL3_Coffee_Shop_Management_System.Presenters;

namespace PBL3_Coffee_Shop_Management_System.Views
{
    public partial class WorkScheduleScreen : UserControl
    {
        public WorkScheduleScreen(bool auth)
        {
            InitializeComponent();
            InitializeDateLabel();
            if (!auth)
            {
                button26.Visible = false;
                button27.Visible = false;
                button28.Visible = false;
            }
            monthCalendar1.MaxSelectionCount = 1;
            setTableLayoutPanel();
        }
        private void InitializeDateLabel()
        {
            dateLabel = new Label[7];
            for (int i = 0; i < 7; i++)
                dateLabel[i] = new Label();

            dateLabel[0].AutoSize = true;
            dateLabel[0].Location = new Point(336, 118);
            dateLabel[0].Name = "dateLabel[0]";
            dateLabel[0].Size = new Size(35, 13);
            dateLabel[0].TabIndex = 2;
            dateLabel[0].Text = "dateLabel[0]";

            dateLabel[1].AutoSize = true;
            dateLabel[1].Location = new Point(417, 118);
            dateLabel[1].Name = "dateLabel[1]";
            dateLabel[1].Size = new Size(35, 13);
            dateLabel[1].TabIndex = 3;
            dateLabel[1].Text = "dateLabel[1]";

            dateLabel[2].AutoSize = true;
            dateLabel[2].Location = new Point(498, 118);
            dateLabel[2].Name = "dateLabel[2]";
            dateLabel[2].Size = new Size(35, 13);
            dateLabel[2].TabIndex = 4;
            dateLabel[2].Text = "dateLabel[2]";

            dateLabel[3].AutoSize = true;
            dateLabel[3].Location = new Point(579, 118);
            dateLabel[3].Name = "dateLabel[3]";
            dateLabel[3].Size = new Size(35, 13);
            dateLabel[3].TabIndex = 5;
            dateLabel[3].Text = "dateLabel[3]";

            dateLabel[4].AutoSize = true;
            dateLabel[4].Location = new Point(660, 118);
            dateLabel[4].Name = "dateLabel[4]";
            dateLabel[4].Size = new Size(35, 13);
            dateLabel[4].TabIndex = 6;
            dateLabel[4].Text = "dateLabel[4]";

            dateLabel[5].AutoSize = true;
            dateLabel[5].Location = new Point(741, 118);
            dateLabel[5].Name = "dateLabel[5]";
            dateLabel[5].Size = new Size(35, 13);
            dateLabel[5].TabIndex = 7;
            dateLabel[5].Text = "dateLabel[5]";

            dateLabel[6].AutoSize = true;
            dateLabel[6].Location = new Point(822, 118);
            dateLabel[6].Name = "dateLabel[6]";
            dateLabel[6].Size = new Size(35, 13);
            dateLabel[6].TabIndex = 8;
            dateLabel[6].Text = "dateLabel[6]";

            int days = DateTime.Now.DayOfWeek - DayOfWeek.Monday;
            for (int i = 0; i < 7; i++)
            {
                dateLabel[i].Text = DateTime.Now.Date.AddDays(-days + i).ToString("dd/MM/yyyy");
            }

            Controls.Add(dateLabel[6]);
            Controls.Add(dateLabel[5]);
            Controls.Add(dateLabel[4]);
            Controls.Add(dateLabel[3]);
            Controls.Add(dateLabel[2]);
            Controls.Add(dateLabel[1]);
            Controls.Add(dateLabel[0]);
        }

        private void setTableLayoutPanel()
        {
            while (tableLayoutPanel1.Controls.ContainsKey("workshift"))
            {
                tableLayoutPanel1.Controls.RemoveByKey("workshift");
            }
            while (tableLayoutPanel1.Controls.ContainsKey("selected"))
            {
                tableLayoutPanel1.Controls.RemoveByKey("selected");
            }
            List<ShiftDetailsDTO> list = DataStructure<ShiftDetailsDTO>.Instance.FindAll(x =>
                x.Day >= monthCalendar1.SelectionStart.Date.AddDays(DayOfWeek.Monday - ((monthCalendar1.SelectionStart.DayOfWeek==DayOfWeek.Sunday) ? DayOfWeek.Saturday + 1 : monthCalendar1.SelectionStart.DayOfWeek))
                && x.Day <= monthCalendar1.SelectionStart.Date.AddDays(DayOfWeek.Saturday - ((monthCalendar1.SelectionStart.DayOfWeek == DayOfWeek.Sunday) ? DayOfWeek.Saturday + 1 : monthCalendar1.SelectionStart.DayOfWeek) + 1));
            foreach (ShiftDetailsDTO shiftDetails in list)
            {
                WorkshiftPanel panel = new WorkshiftPanel(shiftDetails.Employee, shiftDetails.Workshift, shiftDetails.Day);
                tableLayoutPanel1.Controls.Add(panel, (shiftDetails.Day.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)shiftDetails.Day.DayOfWeek), shiftDetails.Workshift.StartTime.Hours - 5);
                tableLayoutPanel1.SetRowSpan(panel, (shiftDetails.Workshift.EndTime - shiftDetails.Workshift.StartTime).Hours
                    + ((shiftDetails.Workshift.EndTime.Hours == 22) ? 1 : 0));
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            int days = ((monthCalendar1.SelectionStart.DayOfWeek == DayOfWeek.Sunday) ? DayOfWeek.Saturday + 1 : monthCalendar1.SelectionStart.DayOfWeek) - DayOfWeek.Monday;
            for (int i = 0; i < 7; i++)
            {
                dateLabel[i].Text = monthCalendar1.SelectionStart.AddDays(-days + i).ToString("dd/MM/yyyy");
            }
            setTableLayoutPanel();
        }

        public event EventHandler<ShiftDetailsEventArgs> AddShift;
        public event EventHandler<ShiftDetailsEventArgs> DeleteShift;

        private void button27_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c.Name == "selected")
                {
                    WorkshiftPanel p = (WorkshiftPanel)c;
                    ShiftDetailsDTO shift = new ShiftDetailsDTO(p.employee, p.workshift, p.day, false);
                    DeleteShift(this, new ShiftDetailsEventArgs(new List<ShiftDetailsDTO> { shift }));
                    tableLayoutPanel1.Controls.Remove(c);
                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c.Name == "selected")
                {
                    WorkshiftPanel p = (WorkshiftPanel)c;
                    ShiftDetailsDTO shiftDetails = new ShiftDetailsDTO(p.employee, p.workshift, p.day, false);
                    DeleteShift(this, new ShiftDetailsEventArgs(new List<ShiftDetailsDTO> { shiftDetails }));
                    tableLayoutPanel1.Controls.Remove(c);
                    using (ShiftDetailDetailsForm form = new ShiftDetailDetailsForm(p))
                    {
                        form.ShowDialog();
                        if (form.DialogResult == DialogResult.OK)
                        {
                            shiftDetails = form.GetData();
                            AddShift(this, new ShiftDetailsEventArgs(new List<ShiftDetailsDTO> { shiftDetails }));
                            WorkshiftPanel panel = new WorkshiftPanel(shiftDetails.Employee, shiftDetails.Workshift, shiftDetails.Day);
                            tableLayoutPanel1.Controls.Add(panel, (shiftDetails.Day.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)shiftDetails.Day.DayOfWeek), shiftDetails.Workshift.StartTime.Hours - 5);
                            tableLayoutPanel1.SetRowSpan(panel, (shiftDetails.Workshift.EndTime - shiftDetails.Workshift.StartTime).Hours
                                + ((shiftDetails.Workshift.EndTime.Hours == 22) ? 1 : 0));
                        }
                    }
                    return;
                }
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            using (ShiftDetailDetailsForm form = new ShiftDetailDetailsForm())
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    ShiftDetailsDTO shiftDetails = form.GetData();
                    AddShift(this, new ShiftDetailsEventArgs(new List<ShiftDetailsDTO> { shiftDetails }));
                    WorkshiftPanel panel = new WorkshiftPanel(shiftDetails.Employee, shiftDetails.Workshift, shiftDetails.Day);
                    tableLayoutPanel1.Controls.Add(panel, (shiftDetails.Day.DayOfWeek == DayOfWeek.Sunday?7:(int)shiftDetails.Day.DayOfWeek), shiftDetails.Workshift.StartTime.Hours - 5);
                    tableLayoutPanel1.SetRowSpan(panel, (shiftDetails.Workshift.EndTime - shiftDetails.Workshift.StartTime).Hours
                        + ((shiftDetails.Workshift.EndTime.Hours == 22) ? 1 : 0));
                }
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            using (ShiftCompletedForm form = new ShiftCompletedForm())
            {
                string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                WorkshiftModel workshiftModel = new WorkshiftModel(connstring);
                WorkshiftPresenter workshiftPresenter = new WorkshiftPresenter(workshiftModel, form);
                form.ShowDialog();
            }
        }
    }
}
