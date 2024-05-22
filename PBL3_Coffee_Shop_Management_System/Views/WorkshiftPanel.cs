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
        public WorkshiftPanel(string EmployeeName, WorkshiftDTO workshift)
        {
            InitializeComponent();
            Name = "workshift";
            Height = ((workshift.EndTime - workshift.StartTime).Hours + ((workshift.EndTime.Hours==22)?1:0))*26;
            label1.MaximumSize = new Size(80,0);
            label1.Text = EmployeeName;
            label1.Left = (Width - label1.Width) / 2;
            label1.Top = (Height - label1.Height) / 2;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            BackColor = Color.FromArgb(rnd.Next(50,256), rnd.Next(50,256), rnd.Next(50,256));
        }
    }
}
