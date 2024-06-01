using PBL3_Coffee_Shop_Management_System.DTO;
using PBL3_Coffee_Shop_Management_System.EventArguments;
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
    public partial class WorkshiftManagementForm : Form
    {
        public WorkshiftManagementForm()
        {
            InitializeComponent();
            AutoSizeColumnList(listView1);
        }
        private void AutoSizeColumnList(ListView listView)
        {
            listView.BeginUpdate();
            Dictionary<int, int> columnSize = new Dictionary<int, int>();
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            foreach (ColumnHeader colHeader in listView.Columns)
                columnSize.Add(colHeader.Index, colHeader.Width);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            foreach (ColumnHeader colHeader in listView.Columns)
            {
                int nColWidth;
                if (columnSize.TryGetValue(colHeader.Index, out nColWidth))
                    colHeader.Width = Math.Max(nColWidth, colHeader.Width);
                else
                    colHeader.Width = Math.Max(50, colHeader.Width);
            }
            listView.EndUpdate();
        }
        public event EventHandler GetAllWorkshift;
        public event EventHandler<WorkshiftEventArgs> AddWorkshift;
        public event EventHandler<WorkshiftEventArgs> DeleteWorkshift;
        public event EventHandler<WorkshiftEventArgs> UpdateWorkshift;
        private void WorkshiftManagementForm_Load(object sender, EventArgs e)
        {
            GetAllWorkshift(this, EventArgs.Empty);
            foreach (WorkshiftDTO workshift in DataStructure<WorkshiftDTO>.Instance)
            {
                listView1.Items.Add(new ListViewItem(new string[] { workshift.ID, workshift.StartTime.ToString(), workshift.EndTime.ToString() }));
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            using (WorkshiftDetailsForm form = new WorkshiftDetailsForm())
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    AddWorkshift(this, new WorkshiftEventArgs(new List<WorkshiftDTO> { new WorkshiftDTO(form.ID, form.StartTime, form.EndTime) }));
                    listView1.Items.Add(new ListViewItem(new string[] { form.ID, form.StartTime.ToString(), form.EndTime.ToString() }));
                    AutoSizeColumnList(listView1);
                }
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                List<WorkshiftDTO> list = new List<WorkshiftDTO>();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    WorkshiftDTO temp = new WorkshiftDTO(item.Text, TimeSpan.Parse(item.SubItems[1].Text), TimeSpan.Parse(item.SubItems[2].Text));
                    list.Add(temp);
                    listView1.Items.Remove(item);
                }
                DeleteWorkshift(this, new WorkshiftEventArgs(list));
                AutoSizeColumnList(listView1);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListViewItem item = listView1.SelectedItems[0];
                List<WorkshiftDTO> list = new List<WorkshiftDTO>();
                WorkshiftDTO workshift = new WorkshiftDTO(item.Text, TimeSpan.Parse(item.SubItems[1].Text), TimeSpan.Parse(item.SubItems[2].Text));
                list.Add(workshift);
                UpdateWorkshift(this, new WorkshiftEventArgs(list));
                listView1.Items.Clear();
                foreach (WorkshiftDTO w in DataStructure<WorkshiftDTO>.Instance)
                {
                    listView1.Items.Add(new ListViewItem(new string[] { w.ID, w.StartTime.ToString(), w.EndTime.ToString() }));
                }
                AutoSizeColumnList(listView1);
            }
        }
    }
}
