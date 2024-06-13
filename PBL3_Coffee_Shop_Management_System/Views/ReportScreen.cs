using PBL3_Coffee_Shop_Management_System.DTO;
using PBL3_Coffee_Shop_Management_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            objChart.AxisY.Maximum = revenue.Values.Count>0?revenue.Values.Max():0;
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
                chart1.Series["Revenue"].Points.AddXY(DateTime.ParseExact(item.Key, "dd/MM/yyyy", CultureInfo.InvariantCulture), item.Value);
            }
            chart1.Legends.Clear();
        }
        private void ChartRevenueByDate(DateTime startTime, DateTime endTime)
        {
            Dictionary<string, int> revenue = new Dictionary<string, int>();
            List<ReceiptDTO> receipt = DataStructure<ReceiptDTO>.Instance.FindAll(x =>
                x.TransactionTime >= startTime && x.TransactionTime <= endTime);
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
            objChart.AxisX.Minimum = startTime.ToOADate();
            objChart.AxisX.Maximum = endTime.ToOADate();
            objChart.AxisX.MajorGrid.LineWidth = 0;
            objChart.AxisX.LabelStyle.Format = "dd/MM/yyyy";
            //
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 0;
            objChart.AxisY.Maximum = (revenue.Count!=0)?revenue.Values.Max():0;
            //
            chart1.Titles.Clear();
            chart1.Titles.Add("Doanh thu từ ngày "+startTime.ToString("dd/MM/yyyy")+" đến ngày "+endTime.ToString("dd/MM/yyyy"));
            chart1.Series.Clear();
            Random rnd = new Random();
            chart1.Series.Add("Revenue");
            chart1.Series["Revenue"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            chart1.Series["Revenue"].Color = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            chart1.Series["Revenue"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            foreach (var item in revenue)
            {
                chart1.Series["Revenue"].Points.AddXY(DateTime.ParseExact(item.Key, "dd/MM/yyyy", CultureInfo.InvariantCulture), item.Value);
            }
            chart1.Legends.Clear();
        }
        private void ChartRevenueByMonth(DateTime startTime, DateTime endTime)
        {
            Dictionary<string, int> revenue = new Dictionary<string, int>();
            List<ReceiptDTO> receipt = DataStructure<ReceiptDTO>.Instance.FindAll(x =>
                (x.TransactionTime.Year == startTime.Year && x.TransactionTime.Month >= startTime.Month)
                || (x.TransactionTime.Year > startTime.Year && x.TransactionTime.Year < endTime.Year)
                || (x.TransactionTime.Year == endTime.Year && x.TransactionTime.Month <= endTime.Month));
            foreach (ReceiptDTO r in receipt)
            {
                int index = 0;
                foreach (int t in r.Total)
                {
                    if (!revenue.ContainsKey(r.TransactionTime.ToString("MM/yyyy")))
                        revenue.Add(r.TransactionTime.ToString("MM/yyyy"), t * r.Quantity[index]);
                    else revenue[r.TransactionTime.ToString("MM/yyyy")] += t * r.Quantity[index];
                    index++;
                }
            }
            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            objChart.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            objChart.AxisX.Interval = 1;
            objChart.AxisX.Minimum = startTime.ToOADate();
            objChart.AxisX.Maximum = endTime.ToOADate();
            objChart.AxisX.MajorGrid.LineWidth = 0;
            objChart.AxisX.LabelStyle.Format = "MM/yyyy";
            //
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 0;
            objChart.AxisY.Maximum = (revenue.Count != 0) ? revenue.Values.Max() : 0;
            //
            chart1.Titles.Clear();
            chart1.Titles.Add("Doanh thu từ tháng " + startTime.ToString("MM/yyyy") + " đến tháng " + endTime.ToString("MM/yyyy"));
            chart1.Series.Clear();
            Random rnd = new Random();
            chart1.Series.Add("Revenue");
            chart1.Series["Revenue"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            chart1.Series["Revenue"].Color = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            chart1.Series["Revenue"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            foreach (var item in revenue)
            {
                chart1.Series["Revenue"].Points.AddXY(DateTime.ParseExact(item.Key, "dd/MM/yyyy", CultureInfo.InvariantCulture), item.Value);
            }
            chart1.Legends.Clear();
        }
        private void ChartRevenueByYear(DateTime startTime, DateTime endTime)
        {
            Dictionary<string, int> revenue = new Dictionary<string, int>();
            List<ReceiptDTO> receipt = DataStructure<ReceiptDTO>.Instance.FindAll(x =>
                x.TransactionTime.Year >= startTime.Year && x.TransactionTime.Year <= endTime.Year);
            foreach (ReceiptDTO r in receipt)
            {
                int index = 0;
                foreach (int t in r.Total)
                {
                    if (!revenue.ContainsKey(r.TransactionTime.ToString("yyyy")))
                        revenue.Add(r.TransactionTime.ToString("yyyy"), t * r.Quantity[index]);
                    else revenue[r.TransactionTime.ToString("yyyy")] += t * r.Quantity[index];
                    index++;
                }
            }
            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Years;
            objChart.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Years;
            objChart.AxisX.Interval = 1;
            objChart.AxisX.Minimum = startTime.ToOADate();
            objChart.AxisX.Maximum = endTime.ToOADate();
            objChart.AxisX.MajorGrid.LineWidth = 0;
            objChart.AxisX.LabelStyle.Format = "yyyy";
            //
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 0;
            objChart.AxisY.Maximum = (revenue.Count != 0) ? revenue.Values.Max() : 0;
            //
            chart1.Titles.Clear();
            chart1.Titles.Add("Doanh thu từ năm " + startTime.ToString("yyyy") + " đến năm " + endTime.ToString("yyyy"));
            chart1.Series.Clear();
            Random rnd = new Random();
            chart1.Series.Add("Revenue");
            chart1.Series["Revenue"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            chart1.Series["Revenue"].Color = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            chart1.Series["Revenue"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            foreach (var item in revenue)
            {
                chart1.Series["Revenue"].Points.AddXY(DateTime.ParseExact("01/01/"+item.Key, "dd/MM/yyyy", CultureInfo.InvariantCulture), item.Value);
            }
            chart1.Legends.Clear();
        }
        private void ChartProductRevenueByDate(DateTime startTime, DateTime endTime)
        {
            Dictionary<string, int> revenue = new Dictionary<string, int>();
            List<ReceiptDTO> receipt = DataStructure<ReceiptDTO>.Instance.FindAll(x =>
                x.TransactionTime >= startTime && x.TransactionTime <= endTime);
            foreach (ReceiptDTO r in receipt)
            {
                int index = 0;
                foreach (ProductDTO p in r.Products)
                {
                    if (!revenue.ContainsKey(r.TransactionTime.ToString("dd/MM/yyyy")+": "+p.Name))
                        revenue.Add(r.TransactionTime.ToString("dd/MM/yyyy") + ": " + p.Name, r.Total[index] * r.Quantity[index]);
                    else revenue[r.TransactionTime.ToString("dd/MM/yyyy") + ": " + p.Name] += r.Total[index] * r.Quantity[index];
                    index++;
                }
            }
            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            objChart.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            objChart.AxisX.Interval = 1;
            objChart.AxisX.Maximum = endTime.ToOADate();
            objChart.AxisX.Minimum = startTime.ToOADate();
            objChart.AxisX.MajorGrid.LineWidth = 0;
            objChart.AxisX.LabelStyle.Format = "dd/MM/yyyy";
            //
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 0;
            objChart.AxisY.Maximum = (revenue.Count != 0) ? revenue.Values.Max() : 0;
            //
            chart1.Titles.Clear();
            chart1.Titles.Add("Doanh thu của các loại sản phẩm từ ngày " + startTime.ToString("dd/MM/yyyy") + " đến ngày " + endTime.ToString("dd/MM/yyyy"));
            chart1.Series.Clear();
            Random rnd = new Random();
            chart1.Legends.Add(new Legend("Legend2"));
            foreach (ProductDTO p in DataStructure<ProductDTO>.Instance)
            {
                chart1.Series.Add(p.Name);
                chart1.Series[p.Name].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
                chart1.Series[p.Name].Color = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                chart1.Series[p.Name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart1.Series[p.Name].Legend = "Legend2";
                chart1.Series[p.Name].IsVisibleInLegend = true;
            }
            foreach (var item in revenue)
            {
                chart1.Series[item.Key.Substring(12)].Points.AddXY(DateTime.ParseExact(item.Key.Substring(0,10), "dd/MM/yyyy", CultureInfo.InvariantCulture), item.Value);
            }
        }
        private void ChartProductRevenueByMonth(DateTime startTime, DateTime endTime)
        {
            Dictionary<string, int> revenue = new Dictionary<string, int>();
            List<ReceiptDTO> receipt = DataStructure<ReceiptDTO>.Instance.FindAll(x =>
                (x.TransactionTime.Year == startTime.Year && x.TransactionTime.Month >= startTime.Month)
                || (x.TransactionTime.Year > startTime.Year && x.TransactionTime.Year < endTime.Year)
                || (x.TransactionTime.Year == endTime.Year && x.TransactionTime.Month <= endTime.Month));
            foreach (ReceiptDTO r in receipt)
            {
                int index = 0;
                foreach (ProductDTO p in r.Products)
                {
                    if (!revenue.ContainsKey(r.TransactionTime.ToString("MM/yyyy") + ": " + p.Name))
                        revenue.Add(r.TransactionTime.ToString("MM/yyyy") + ": " + p.Name, r.Total[index] * r.Quantity[index]);
                    else revenue[r.TransactionTime.ToString("MM/yyyy") + ": " + p.Name] += r.Total[index] * r.Quantity[index];
                    index++;
                }
            }
            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            objChart.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            objChart.AxisX.Interval = 1;
            objChart.AxisX.Maximum = endTime.ToOADate();
            objChart.AxisX.Minimum = startTime.ToOADate();
            objChart.AxisX.MajorGrid.LineWidth = 0;
            objChart.AxisX.LabelStyle.Format = "MM/yyyy";
            //
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 0;
            objChart.AxisY.Maximum = (revenue.Count != 0) ? revenue.Values.Max() : 0;
            //
            chart1.Titles.Clear();
            chart1.Titles.Add("Doanh thu của các loại sản phẩm từ tháng " + startTime.ToString("MM/yyyy") + " đến tháng " + endTime.ToString("MM/yyyy"));
            chart1.Series.Clear();
            Random rnd = new Random();
            chart1.Legends.Add(new Legend("Legend2"));
            foreach (ProductDTO p in DataStructure<ProductDTO>.Instance)
            {
                chart1.Series.Add(p.Name);
                chart1.Series[p.Name].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
                chart1.Series[p.Name].Color = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                chart1.Series[p.Name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart1.Series[p.Name].Legend = "Legend2";
                chart1.Series[p.Name].IsVisibleInLegend = true;
            }
            foreach (var item in revenue)
            {
                chart1.Series[item.Key.Substring(9)].Points.AddXY(DateTime.ParseExact(item.Key.Substring(0,7), "dd/MM/yyyy", CultureInfo.InvariantCulture), item.Value);
            }
        }
        private void ChartProductRevenueByYear(DateTime startTime, DateTime endTime)
        {
            Dictionary<string, int> revenue = new Dictionary<string, int>();
            List<ReceiptDTO> receipt = DataStructure<ReceiptDTO>.Instance.FindAll(x =>
                x.TransactionTime.Year >= startTime.Year && x.TransactionTime.Year <= endTime.Year);
            foreach (ReceiptDTO r in receipt)
            {
                int index = 0;
                foreach (ProductDTO p in r.Products)
                {
                    if (!revenue.ContainsKey(r.TransactionTime.ToString("yyyy") + ": " + p.Name))
                        revenue.Add(r.TransactionTime.ToString("yyyy") + ": " + p.Name, r.Total[index] * r.Quantity[index]);
                    else revenue[r.TransactionTime.ToString("yyyy") + ": " + p.Name] += r.Total[index] * r.Quantity[index];
                    index++;
                }
            }
            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Years;
            objChart.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Years;
            objChart.AxisX.Interval = 1;
            objChart.AxisX.Maximum = endTime.ToOADate();
            objChart.AxisX.Minimum = startTime.ToOADate();
            objChart.AxisX.MajorGrid.LineWidth = 0;
            objChart.AxisX.LabelStyle.Format = "yyyy";
            //
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 0;
            objChart.AxisY.Maximum = (revenue.Count != 0) ? revenue.Values.Max() : 0;
            //
            chart1.Titles.Clear();
            chart1.Titles.Add("Doanh thu của các loại sản phẩm từ năm " + startTime.ToString("yyyy") + " đến năm " + endTime.ToString("yyyy"));
            chart1.Series.Clear();
            Random rnd = new Random();
            chart1.Legends.Add(new Legend("Legend2"));
            foreach (ProductDTO p in DataStructure<ProductDTO>.Instance)
            {
                chart1.Series.Add(p.Name);
                chart1.Series[p.Name].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
                chart1.Series[p.Name].Color = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                chart1.Series[p.Name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart1.Series[p.Name].Legend = "Legend2";
                chart1.Series[p.Name].IsVisibleInLegend = true;
            }
            foreach (var item in revenue)
            {
                chart1.Series[item.Key.Substring(6)].Points.AddXY(DateTime.ParseExact("01/01/"+item.Key.Substring(0,4), "dd/MM/yyyy", CultureInfo.InvariantCulture), item.Value);
            }
            chart1.Legends.Clear();
        }

        private void ReportScreen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CalcSalaryForm form = new CalcSalaryForm())
            {
                form.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ChooseReportTypeForm form = new ChooseReportTypeForm())
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    if (form.type == 0)
                    {
                        switch (form.dateType)
                        {
                            case 0:
                                ChartRevenueByDate(form.startTime, form.endTime);
                                break;
                            case 1:
                                ChartRevenueByMonth(form.startTime, form.endTime);
                                break;
                            case 2:
                                ChartRevenueByYear(form.startTime, form.endTime);
                                break;
                        }
                    }
                    else
                    {
                        if (DataStructure<ProductDTO>.Instance.Count == 0)
                        {
                            string connstring = string.Format("Server=localhost; database=PBL3_COFFEE_SHOP_MANAGEMENT_SYSTEM; UID=root; password=;");
                            ProductModel productModel = new ProductModel(connstring);
                            productModel.getAllData();
                        }
                        switch (form.dateType)
                        {
                            case 0:
                                ChartProductRevenueByDate(form.startTime, form.endTime);
                                break;
                            case 1:
                                ChartProductRevenueByMonth(form.startTime, form.endTime);
                                break;
                            case 2:
                                ChartProductRevenueByYear(form.startTime, form.endTime);
                                break;
                            }
                        }
                }
            }
        }
    }
}
