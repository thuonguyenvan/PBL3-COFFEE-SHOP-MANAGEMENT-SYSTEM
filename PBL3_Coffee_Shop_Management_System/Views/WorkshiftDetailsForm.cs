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
    public partial class WorkshiftDetailsForm : Form
    {
        public string ID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public WorkshiftDetailsForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker1.Value = dateTimePicker1.MinDate;
            dateTimePicker2.Value = dateTimePicker2.MinDate;
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
            string s;
            int i = 1;
            s = "FT";
            s += i.ToString();
            if (s.Length < 6) s = s.Insert(2, string.Concat(Enumerable.Repeat("0", 6 - s.Length)));
            while (DataStructure<WorkshiftDTO>.Instance.Find(x => x.ID == s) != null)
            {
                s = s.Remove(2, 5);
                i++;
                s += i.ToString();
                if (s.Length < 6) s = s.Insert(1, string.Concat(Enumerable.Repeat("0", 6 - s.Length)));
            }
            textBox1.Text = s;
        }
        public WorkshiftDetailsForm(WorkshiftDTO workshift)
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.ShowUpDown = true;
            textBox1.Text = workshift.ID;
            if (workshift.ID[0] == 'F') comboBox1.SelectedIndex = 0;
            else comboBox1.SelectedIndex = 1;
            dateTimePicker1.Value = dateTimePicker1.MinDate + workshift.StartTime;
            dateTimePicker2.Value = dateTimePicker2.MinDate + workshift.EndTime;
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ID = textBox1.Text;
            StartTime = new TimeSpan(dateTimePicker1.Value.Hour, dateTimePicker1.Value.Minute, dateTimePicker1.Value.Second);
            EndTime = new TimeSpan(dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, dateTimePicker2.Value.Second);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                string s;
                int i = 1;
                s = "FT";
                s += i.ToString();
                if (s.Length < 6) s = s.Insert(2, string.Concat(Enumerable.Repeat("0", 6 - s.Length)));
                while (DataStructure<WorkshiftDTO>.Instance.Find(x => x.ID == s) != null)
                {
                    s.Remove(2, 5);
                    i++;
                    s += i.ToString();
                    if (s.Length < 6) s = s.Insert(1, string.Concat(Enumerable.Repeat("0", 6 - s.Length)));
                }
                textBox1.Text = s;
            }
            else
            {
                string s;
                int i = 1;
                s = "PT";
                s += i.ToString();
                if (s.Length < 6) s = s.Insert(2, string.Concat(Enumerable.Repeat("0", 6 - s.Length)));
                while (DataStructure<WorkshiftDTO>.Instance.Find(x => x.ID == s) != null)
                {
                    s.Remove(2, 5);
                    i++;
                    s += i.ToString();
                    if (s.Length < 6) s = s.Insert(1, string.Concat(Enumerable.Repeat("0", 6 - s.Length)));
                }
                textBox1.Text = s;
            }
        }
    }
}
