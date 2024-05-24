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

namespace PBL3_Coffee_Shop_Management_System.Views
{
    public partial class WorkshiftPanel : UserControl
    {
        Color c;
        public EmployeeDTO employee;
        public WorkshiftDTO workshift;
        public DateTime day;
        public WorkshiftPanel(EmployeeDTO employee, WorkshiftDTO workshift, DateTime day)
        {
            InitializeComponent();
            this.employee = employee;
            this.workshift = workshift;
            this.day = day;
            Name = "workshift";
            Height = ((workshift.EndTime - workshift.StartTime).Hours + ((workshift.EndTime.Hours==22)?1:0))*26;
            label1.MaximumSize = new Size(80,0);
            label1.Text = employee.Name;
            label1.Left = (Width - label1.Width) / 2;
            label1.Top = (Height - label1.Height) / 2;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            c = Color.FromArgb(rnd.Next(50,256), rnd.Next(50,256), rnd.Next(50,256));
            BackColor = c;
        }

        private void WorkshiftPanel_Click(object sender, EventArgs e)
        {
            if (Name != "selected")
            {
                BackColor = Color.White;
                Name = "selected";
            }
            else
            {
                BackColor = c;
                Name = "workshift";
            }
        }
    }
}
