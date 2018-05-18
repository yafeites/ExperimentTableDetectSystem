using ExperimentTableDetectSystem.entity;
using ExperimentTableDetectSystem.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExperimentTableDetectSystem.Windows.drawing
{
    public partial class CurveDrawing : MetroFramework.Forms.MetroForm
    {
        public CurveDrawing()
        {
            InitializeComponent();
        }
        PcanHelper pcanhelper;
        PeakHelper peakhelper;
        double F1 = 0;
        double F2 = 0;
        double F3 = 0;
        double F4 = 0;
        double F5 = 0;
        double F6 = 0;
        Series f1;
        Series f2;
        Series f3;
        Series f4;
        Series f5;
        Series f6;
        private Thread addDataRunner;
        private delegate void AddDataDelegate();
        private AddDataDelegate addDataDel;

       

        private void btnStartDraw_Click(object sender, EventArgs e)
        {
            btnStartDraw.Enabled = false;
            btnEndDraw.Enabled = true;
            addDataRunner = new Thread(new ThreadStart(AddDataThreadLoop));
            addDataRunner.IsBackground = true;
            addDataDel = new AddDataDelegate(AddData);
            DateTime timeValue = DateTime.Now;
            DateTime minValue = timeValue.ToLocalTime();
            DateTime maxValue = timeValue.AddSeconds(30).ToLocalTime();

            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chart1.ChartAreas[0].AxisX.Title = "时间";
            chart1.ChartAreas[0].AxisY.Title = "压力（bar）";
            chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
            chart1.Series.Clear();

            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chart2.ChartAreas[0].AxisX.Title = "时间";
            chart2.ChartAreas[0].AxisY.Title = "压力（bar）";
            chart2.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
            chart2.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
            chart2.Series.Clear();

            chart3.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chart3.ChartAreas[0].AxisX.Title = "时间";
            chart3.ChartAreas[0].AxisY.Title = "流量（m³）";
            chart3.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
            chart3.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
            chart3.Series.Clear();

            chart4.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chart4.ChartAreas[0].AxisX.Title = "时间";
            chart4.ChartAreas[0].AxisY.Title = "位移（m）";
            chart4.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
            chart4.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
            chart4.Series.Clear();

            double[] showdata = new double[51];
            for (int i = 0; i < 51; i++)
            {
             //   showdata[i] = peakhelper.AllValue[i];
            }
            F1 = showdata[4];
            //主泵1压力曲线f1绘制
            f1 = new Series();
            f1.ChartType = SeriesChartType.Spline;
            f1.BorderWidth = 3;
            f1.BorderColor = Color.Red;
            f1.LegendText = "主泵1压力";
            f1.XValueType = ChartValueType.DateTime;

            f2 = new Series();
            f2.ChartType = SeriesChartType.Spline;
            f2.BorderWidth = 3;
            f2.BorderColor = Color.Green;
            f2.LegendText = "主泵2压力";
            f2.XValueType = ChartValueType.DateTime;

            f3 = new Series();
            f3.ChartType = SeriesChartType.Spline;
            f3.BorderWidth = 3;
            f3.BorderColor = Color.Red;
            f3.LegendText = "大门架前倾进油压力损失";
            f3.XValueType = ChartValueType.DateTime;

            f4 = new Series();
            f4.ChartType = SeriesChartType.Spline;
            f4.BorderWidth = 3;
            f4.BorderColor = Color.Green;
            f4.LegendText = "大门架前倾回油压力损失";
            f4.XValueType = ChartValueType.DateTime;

            f5 = new Series();
            f5.ChartType = SeriesChartType.Spline;
            f5.BorderWidth = 3;
            f5.BorderColor = Color.Green;
            f5.LegendText = "主泵1流量";
            f5.XValueType = ChartValueType.DateTime;

            f6 = new Series();
            f6.ChartType = SeriesChartType.Spline;
            f6.BorderWidth = 3;
            f6.BorderColor = Color.Green;
            f6.LegendText = "小门架下降位移";
            f6.XValueType = ChartValueType.DateTime;

            chart1.Series.Add(f1);
            chart1.Series.Add(f2);
            chart2.Series.Add(f3);
            chart2.Series.Add(f4);
            chart3.Series.Add(f5);
            chart4.Series.Add(f6);

            addDataRunner.Start();
        }


        /// <summary>
        /// 委托的方法，实际绘制
        /// </summary>
        private void AddData()
        {
            DateTime timetemp = DateTime.Now;
            f1.Points.AddXY(timetemp.ToLocalTime(), 10);
            f2.Points.AddXY(timetemp.ToLocalTime(), 6);
            f3.Points.AddXY(timetemp.ToLocalTime(), 5);
            f4.Points.AddXY(timetemp.ToLocalTime(), 8);
            f5.Points.AddXY(timetemp.ToLocalTime(), 6);
            f6.Points.AddXY(timetemp.ToLocalTime(), 6);
            double removeBefore = timetemp.AddSeconds((double)(20) * (-1)).ToOADate();

            while (f1.Points[0].XValue < removeBefore)
            {
                f1.Points.RemoveAt(0);
                f2.Points.RemoveAt(0);
                f3.Points.RemoveAt(0);
                f4.Points.RemoveAt(0);
                f5.Points.RemoveAt(0);
                f6.Points.RemoveAt(0);
            }

            chart1.ChartAreas[0].AxisX.Minimum = f1.Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f1.Points[0].XValue).AddSeconds(30).ToOADate();

            chart1.Invalidate();

            chart2.ChartAreas[0].AxisX.Minimum = f1.Points[0].XValue;
            chart2.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f1.Points[0].XValue).AddSeconds(30).ToOADate();

            chart2.Invalidate();

            chart3.ChartAreas[0].AxisX.Minimum = f1.Points[0].XValue;
            chart3.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f1.Points[0].XValue).AddSeconds(30).ToOADate();

            chart3.Invalidate();

            chart4.ChartAreas[0].AxisX.Minimum = f1.Points[0].XValue;
            chart4.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f1.Points[0].XValue).AddSeconds(30).ToOADate();

            chart4.Invalidate();
        }
        private void AddDataThreadLoop()
        {
            try
            {
                while (true)
                {
                    chart1.Invoke(addDataDel);
                    Thread.Sleep(500);
                }
            }
            catch (Exception)
            { }
        }
        /// <summary>
        /// 结束绘制
        /// </summary>


        private void btnEndDraw_Click_1(object sender, EventArgs e)
        {
            if (addDataRunner != null)
            {
                addDataRunner.Abort();
                addDataRunner.Join();
                addDataRunner = null;
            }
            btnStartDraw.Enabled = true;
            btnEndDraw.Enabled = false;
        }

        private void CurveDrawing_Load(object sender, EventArgs e)
        {

        }
    }
}
