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
    public partial class ReportScreen : UserControl
    {
        public ReportScreen()
        {
            InitializeComponent();
            ChartRecentWeekRevenue();
        }
        private void ChartRecentWeekRevenue()
        {
            Dictionary<string, int> revenue = new Dictionary<string, int>();
            List<ReceiptDTO> receipt = DataStructure<ReceiptDTO>.Instance.FindAll(x =>
                x.TransactionTime >= DateTime.Now.AddDays(-7) && x.TransactionTime <= DateTime.Now);
            foreach (ReceiptDTO r in receipt)
            {
                int index = 0;
                foreach (int t in r.Total)
                {
                    if (!revenue.ContainsKey(r.TransactionTime.ToString("dd/MM/yyyy")))
                        revenue.Add(r.TransactionTime.ToString("dd/MM/yyyy"), t * r.Quantity[index]);
                    else revenue[r.TransactionTime.ToString("dd/MM/yyyy")] += t * r.Quantity[index];
                    index++;
                }
            }
            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            objChart.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            objChart.AxisX.Interval = 1;
            objChart.AxisX.Maximum = DateTime.Now.ToOADate();
            objChart.AxisX.Minimum = DateTime.Now.ToOADate() - 7;
            objChart.AxisX.MajorGrid.LineWidth = 0;
            //
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 0;
            objChart.AxisY.Maximum = revenue.Values.Max();
            //
            chart1.Titles.Add("Doanh thu 7 ngày gần nhất");
            chart1.Series.Clear();
            Random rnd = new Random();
            chart1.Series.Add("Revenue");
            chart1.Series["Revenue"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            chart1.Series["Revenue"].Color = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            chart1.Series["Revenue"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            foreach (var item in revenue)
            {
                chart1.Series["Revenue"].Points.AddXY(Convert.ToDateTime(item.Key), item.Value);
            }
            chart1.Legends.Clear();
        }

        private void ReportScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
