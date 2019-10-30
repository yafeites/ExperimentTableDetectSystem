using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.util;
using ExperimentTableDetectSystem.Windows.manual;
using MetroFramework.Controls;
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

namespace ExperimentTableDetectSystem.Windows.auto
{
    public partial class autoDataDisplayWin : MetroFramework.Forms.MetroForm
    {
        #region singleton
        private static autoDataDisplayWin instance;

        public static autoDataDisplayWin getInstance()
        {
            if (instance == null || instance.IsDisposed)
            {

                instance = new autoDataDisplayWin();

            }
            return instance;
        }
        #endregion
        #region Filed
        //  PeakHelper peakhelper;
        private string valveid;

        public string Valveid
        {
            get
            {
                return valveid;
            }

            set
            {
                valveid = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;
            }
        }

        private string company;

        private string menjiaType;

        public string MenjiaType
        {
            get
            {
                return menjiaType;
            }

            set
            {
                valveid = value;
            }
        }

        public int currentCount1 = 0;
        public int currentCount2 = 0;

        public int currentCount5 = 0;
        public int currentCount6 = 0;
        public int currentCount7 = 0;
        public int currentCount8 = 0;


        public double SmallDown2Dis = 0;
        public double SmallDown1Dis = 0;
        public static double SmallDownV = 0;
        public double SmallUp2Dis = 0;
        public double SmallUp1Dis = 0;
        public static double SmallUpV = 0;
        public double SmallForward2Dis = 0;
        public double SmallForward1Dis = 0;
        public static double SmallForwardV = 0;
        public double SmallBack2Dis = 0;
        public double SmallBack1Dis = 0;
        public static double SmallBackV = 0;


        public static double SmallUpDis = 0;
        public static double SmallDownDis = 0;
        public static double SmallForwardDis = 0;
        public static double SmallBackDis = 0;
        public static double mainPump1Pressure = 0;
        public static double mainPump2Pressure = 0;
        public static double mediumPressureLoss = 0;
        public static double pilotPressre = 0;
        public static double realPilotPressure = 0;
        public static double oilInPressure = 0;
        public static double leakageFlow = 0;
        public static double oilOutPressure = 0;
        public static double oilPressure = 0;
        public static double UpPressureLoss = 0;
        public static double DownPressureLoss = 0;
        public static double steerPressure = 0;


        PeakHelper peakhelper;
        DBHelper dbhelp;
        DataStoreManager datastoremanager;

        private Thread addDataRunner;
        private delegate void AddDataDelegate();
        private AddDataDelegate addDataDel;

        void AddDataThreadLoop()
        {
            try
            {
                while (true)
                {
                    chart1.Invoke(addDataDel);
                    chart2.Invoke(addDataDel);
                    Thread.Sleep(500);
                }
            }
            catch (Exception)
            { }
        }

        #endregion
        private autoDataDisplayWin()
        {
            InitializeComponent();
            dbhelp = DBHelper.GetInstance();
            peakhelper = PeakHelper.GetInstance();
            datastoremanager = DataStoreManager.GetInstance();
        }

        private void autoDataDisplayWin_Load(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.BackColor = Color.FromArgb(255, 50, 161, 206);
           // this.panel2.Width = this.panel1.Width / 2;
           // this.panel4.Height = this.panel2.Height / 2;
           // this.panel6.Height = this.panel4.Height;
            this.valveid = ManualNumberInput.id;
            this.company = ManualNumberInput.company;
            this.menjiaType = ManualNumberInput.menjiaType; 
            this.lblValveId.Text = "编号:" + valveid;
            this.txtinfo.Text = company;
            this.txtMenjiaType.Text = menjiaType;
            peakhelper.StartTimer(100);
            DataStoreManager.productId = this.valveid;
            DataStoreManager.n = ManualNumberInput.n;
            DataStoreManager.menjiaType = ManualNumberInput.menjiaType;
            DataStoreManager.valveType = ManualNumberInput.valveType;
            datastoremanager.startTimer2(100, 100);
            addDataRunner = new Thread(new ThreadStart(AddDataThreadLoop));
            addDataRunner.IsBackground = true;
            addDataRunner.Start();
        }
        private static object syncRoot = new Object();
        Series f1;
        Series f2;
        Series f3;
        Series f4;
        Series f5;
        int a = 0;
        int c = 0;
        int d = 0;
        int e = 0;
        int f = 0;
        int g = 0;
        int j = 0;
        int k = 0;
        int l = 0;
        int m = 0;
        int zhiling = 0;

        
        //中位压力损失画图
        void AddData0()
        {
            DateTime timetemp = DateTime.Now;
            f1.Points.AddXY(timetemp.ToLocalTime(), mainPump1Pressure);
            f2.Points.AddXY(timetemp.ToLocalTime(), mainPump2Pressure);
            f3.Points.AddXY(timetemp.ToLocalTime(), mediumPressureLoss);


            double removeBefore = timetemp.AddSeconds((double)(20) * (-1)).ToOADate();

            while (f1.Points[0].XValue < removeBefore)
            {
                f1.Points.RemoveAt(0);
                f2.Points.RemoveAt(0);
                f3.Points.RemoveAt(0);

            }

            chart1.ChartAreas[0].AxisX.Minimum = f1.Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f1.Points[0].XValue).AddSeconds(30).ToOADate();

            chart2.ChartAreas[0].AxisX.Minimum = f3.Points[0].XValue;
            chart2.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f3.Points[0].XValue).AddSeconds(30).ToOADate();

            chart1.Invalidate();
            chart2.Invalidate();
        }
        //内泄漏画图
        void AddData2()
        {
            DateTime timetemp = DateTime.Now;
            f1.Points.AddXY(timetemp.ToLocalTime(), realPilotPressure);
            // f2.Points.AddXY(timetemp.ToLocalTime(), oilPressure);
            f3.Points.AddXY(timetemp.ToLocalTime(), leakageFlow);


            double removeBefore = timetemp.AddSeconds((double)(20) * (-1)).ToOADate();

            while (f1.Points[0].XValue < removeBefore)
            {
                f1.Points.RemoveAt(0);
                //   f2.Points.RemoveAt(0);
                f3.Points.RemoveAt(0);

            }

            chart1.ChartAreas[0].AxisX.Minimum = f1.Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f1.Points[0].XValue).AddSeconds(30).ToOADate();

            chart2.ChartAreas[0].AxisX.Minimum = f3.Points[0].XValue;
            chart2.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f3.Points[0].XValue).AddSeconds(30).ToOADate();

            chart1.Invalidate();
            chart2.Invalidate();
        }
        //门架上升画图
        void AddData3()
        {
            DateTime timetemp = DateTime.Now;
            f1.Points.AddXY(timetemp.ToLocalTime(), SmallUpDis);
            f3.Points.AddXY(timetemp.ToLocalTime(), UpPressureLoss);


            double removeBefore = timetemp.AddSeconds((double)(20) * (-1)).ToOADate();

            while (f1.Points[0].XValue < removeBefore)
            {
                f1.Points.RemoveAt(0);
                f3.Points.RemoveAt(0);

            }

            chart1.ChartAreas[0].AxisX.Minimum = f1.Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f1.Points[0].XValue).AddSeconds(30).ToOADate();

            chart2.ChartAreas[0].AxisX.Minimum = f3.Points[0].XValue;
            chart2.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f3.Points[0].XValue).AddSeconds(30).ToOADate();

            chart1.Invalidate();
            chart2.Invalidate();
        }
        //门架下降画图
        void AddData4()
        {
            DateTime timetemp = DateTime.Now;
            f1.Points.AddXY(timetemp.ToLocalTime(), SmallDownDis);
            f3.Points.AddXY(timetemp.ToLocalTime(), DownPressureLoss);


            double removeBefore = timetemp.AddSeconds((double)(20) * (-1)).ToOADate();

            while (f1.Points[0].XValue < removeBefore)
            {
                f1.Points.RemoveAt(0);
                f3.Points.RemoveAt(0);

            }

            chart1.ChartAreas[0].AxisX.Minimum = f1.Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f1.Points[0].XValue).AddSeconds(30).ToOADate();

            chart2.ChartAreas[0].AxisX.Minimum = f3.Points[0].XValue;
            chart2.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f3.Points[0].XValue).AddSeconds(30).ToOADate();

            chart1.Invalidate();
            chart2.Invalidate();
        }
        //门架前倾画图
        void AddData7()
        {
            DateTime timetemp = DateTime.Now;
            f1.Points.AddXY(timetemp.ToLocalTime(), SmallForwardDis);
            f3.Points.AddXY(timetemp.ToLocalTime(), mainPump1Pressure);


            double removeBefore = timetemp.AddSeconds((double)(20) * (-1)).ToOADate();

            while (f1.Points[0].XValue < removeBefore)
            {
                f1.Points.RemoveAt(0);
                f3.Points.RemoveAt(0);

            }

            chart1.ChartAreas[0].AxisX.Minimum = f1.Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f1.Points[0].XValue).AddSeconds(30).ToOADate();

            chart2.ChartAreas[0].AxisX.Minimum = f3.Points[0].XValue;
            chart2.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f3.Points[0].XValue).AddSeconds(30).ToOADate();

            chart1.Invalidate();
            chart2.Invalidate();
        }
        //门架后倾画图
        void AddData8()
        {
            DateTime timetemp = DateTime.Now;
            f1.Points.AddXY(timetemp.ToLocalTime(), SmallBackDis);
            f3.Points.AddXY(timetemp.ToLocalTime(), mainPump1Pressure);


            double removeBefore = timetemp.AddSeconds((double)(20) * (-1)).ToOADate();

            while (f1.Points[0].XValue < removeBefore)
            {
                f1.Points.RemoveAt(0);
                f3.Points.RemoveAt(0);

            }

            chart1.ChartAreas[0].AxisX.Minimum = f1.Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f1.Points[0].XValue).AddSeconds(30).ToOADate();

            chart2.ChartAreas[0].AxisX.Minimum = f3.Points[0].XValue;
            chart2.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f3.Points[0].XValue).AddSeconds(30).ToOADate();

            chart1.Invalidate();
            chart2.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refresh();
        }
        double[] nowdata = new double[76];
        int count = 0;
        int[] pump1 = new int[5];
        int[] pump2 = new int[5];
        int[] steerPump = new int[5];
        private void refresh()
        {
            for (int i = 0; i < 76; i++)
            {
                nowdata[i] = peakhelper.AllValue[i];
            }

            pump1[count] = (int)nowdata[10];
            pump2[count] = (int)nowdata[11];
            steerPump[count] = (int)nowdata[12];

            if (count < 4)
            {
                count++;
            }
            else
            {
                count = 0;
            }
            mainPump1Pressure = (pump1[0] + pump1[1] + pump1[2] + pump1[3] + pump1[4]) / 5; 
            mainPump2Pressure = (pump2[0] + pump2[1] + pump2[2] + pump2[3] + pump2[4]) / 5;
            mediumPressureLoss = nowdata[19];
            //pilotPressre = nowdata[35];
            oilInPressure = nowdata[17];
            leakageFlow = nowdata[39];
            oilOutPressure = nowdata[18];
            oilPressure = nowdata[16];
            UpPressureLoss = nowdata[22];
            DownPressureLoss = nowdata[23];
            steerPressure= (steerPump[0] + steerPump[1] + steerPump[2] + steerPump[3] + steerPump[4]) / 5;
            //填表
            txttankTemp.Text = nowdata[44].ToString();
            txtpump1OutTemp.Text = nowdata[45].ToString();
            txtpump2OutTemp.Text = nowdata[46].ToString();

            txtpilotPressure.Text = pilotPressre.ToString();
            txtmainPumpP1.Text = mainPump1Pressure.ToString();
            txtMainPumpP2.Text = mainPump2Pressure.ToString();
            txtpumpFlow1.Text = nowdata[36].ToString();
            txtPumpFlow2.Text = nowdata[37].ToString();
            txtsteeringFlow.Text = nowdata[38].ToString();

            pilotPressre = nowdata[35];
            if (leakageFlow != 0)
            {
                txtLeakageFlow.Text = leakageFlow.ToString();
            }
            
            txtSystemBackPressure.Text = nowdata[15].ToString();
            txtMediumPressureLoss.Text = mediumPressureLoss.ToString();
            txtOilPressure.Text = oilPressure.ToString();
            setValue(txtoilInPressure, oilInPressure);
            setValue(txtoilOutPressure, oilOutPressure);
            txtSteerPressure.Text = steerPressure.ToString();
         
             if (nowdata[0] == 1)//中位压力损失
            {   //foreach(Control c in Controls)
                //   if(c is TextBox) { c.Text = ""; }
                if (a < 3)
                {
                    a += 1;
                }

                txtTestCourse.Text = "中位压力损失实验";

                if (a == 1)
                {
                    addDataRunner.Abort();
                    addDataRunner = new Thread(new ThreadStart(AddDataThreadLoop));
                    addDataRunner.IsBackground = true;
                    addDataDel = new AddDataDelegate(AddData0);

                    DateTime timeValue = DateTime.Now;
                    DateTime minValue = timeValue.ToLocalTime();
                    DateTime maxValue = timeValue.AddSeconds(30).ToLocalTime();

                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart1.ChartAreas[0].AxisX.Title = "时间";
                    chart1.ChartAreas[0].AxisY.Title = "压力(bar）";
                    chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart1.Series.Clear();

                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart2.ChartAreas[0].AxisX.Title = "时间";
                    chart2.ChartAreas[0].AxisY.Title = "压力(bar）";
                    chart2.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart2.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart2.Series.Clear();

                    f1 = new Series();
                    f1.ChartType = SeriesChartType.Spline;
                    f1.BorderWidth = 3;
                    f1.BorderColor = Color.Red;
                    f1.LegendText = "泵1压力";
                    f1.XValueType = ChartValueType.DateTime;
                    f2 = new Series();
                    f2.ChartType = SeriesChartType.Spline;
                    f2.BorderWidth = 3;
                    f2.BorderColor = Color.Blue;
                    f2.LegendText = "泵2压力";
                    f2.XValueType = ChartValueType.DateTime;

                    f3 = new Series();
                    f3.ChartType = SeriesChartType.Spline;
                    f3.BorderWidth = 3;
                    f3.BorderColor = Color.Red;
                    f3.LegendText = "中位压损";
                    f3.XValueType = ChartValueType.DateTime;


                    chart1.Series.Add(f1);
                    chart1.Series.Add(f2);
                    chart2.Series.Add(f3);

                    addDataRunner.Start();
                }
            }

            else if (nowdata[7] == 1)//内泄漏测试
            {
                    
                txtTestCourse.Text = "倾斜阀A口内泄漏测试";
     
            }
            else if (nowdata[8] == 1)//内泄漏测试
            {
                
                txtTestCourse.Text = "倾斜阀B口内泄漏测试";
            }
            else if (nowdata[49] == 1)//内泄漏测试
            {
                lock (datastoremanager)
                {
                    realPilotPressure = pilotPressre;
                    pilotPressre = nowdata[40];
                    txtTestCourse.Text = "B3口内泄漏测试";
                }
                
            }
            else if (nowdata[50] == 1)//内泄漏测试
            {
                lock (datastoremanager)
                {
                    realPilotPressure = pilotPressre;
                    pilotPressre = nowdata[40];
                    txtTestCourse.Text = "A3口内泄漏测试";
                }
                
            }
            else if (nowdata[51] == 1)//内泄漏测试
            {
                lock (datastoremanager)
                {
                    realPilotPressure = pilotPressre;
                    pilotPressre = nowdata[40];
                    txtTestCourse.Text = "B4口内泄漏测试";
                }
                
            }
            else if (nowdata[52] == 1)//内泄漏测试
            {
                lock (datastoremanager)
                {
                    realPilotPressure = pilotPressre;
                    pilotPressre = nowdata[40];
                    txtTestCourse.Text = "A4口内泄漏测试";
                }
               
            }
            else if (nowdata[6] == 1)//内泄漏测试
            {
                //clearBox();
                //  ???
                if (e < 3)
                {
                    e += 1;
                }

                txtTestCourse.Text = "泄漏保压升降测试";

                if (e == 1)
                {
                    addDataRunner.Abort();
                    addDataRunner = new Thread(new ThreadStart(AddDataThreadLoop));
                    addDataRunner.IsBackground = true;
                    addDataDel = new AddDataDelegate(AddData2);

                    DateTime timeValue = DateTime.Now;
                    DateTime minValue = timeValue.ToLocalTime();
                    DateTime maxValue = timeValue.AddSeconds(30).ToLocalTime();

                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart1.ChartAreas[0].AxisX.Title = "时间";
                    chart1.ChartAreas[0].AxisY.Title = "压力(bar）";
                    chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart1.Series.Clear();

                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart2.ChartAreas[0].AxisX.Title = "时间";
                    chart2.ChartAreas[0].AxisY.Title = "流量(m³）";
                    chart2.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart2.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart2.Series.Clear();

                    f1 = new Series();
                    f1.ChartType = SeriesChartType.Spline;
                    f1.BorderWidth = 3;
                    f1.BorderColor = Color.Red;
                    f1.LegendText = "供油压力";
                    f1.XValueType = ChartValueType.DateTime;
                    /*f2 = new Series();
                    f2.ChartType = SeriesChartType.Spline;
                    f2.BorderWidth = 3;
                    f2.BorderColor = Color.Blue;
                    f2.LegendText = "升降压力";
                    f2.XValueType = ChartValueType.DateTime;*/

                    f3 = new Series();
                    f3.ChartType = SeriesChartType.Spline;
                    f3.BorderWidth = 3;
                    f3.BorderColor = Color.Red;
                    f3.LegendText = "泄漏流量";
                    f3.XValueType = ChartValueType.DateTime;


                    chart1.Series.Add(f1);
                    //chart1.Series.Add(f2);
                    chart2.Series.Add(f3);

                    addDataRunner.Start();
                }

            }
            
            else if (nowdata[1] == 1)//门架上升
            {
                if (f < 3)
                {
                    f += 1;
                }
                txtTestCourse.Text = "门架上升";
                txtTestCourse.ForeColor = Color.Black;
                txtSmallUpPreLoss.Text = nowdata[22].ToString();
                SmallUpDis = nowdata[20];
                txtSmallUpDis.Text = SmallUpDis.ToString();
                //??速度
                currentCount1 += 1;
                if (currentCount1 % 20 == 0)
                {
                    SmallUp2Dis = nowdata[20];
                }
                if (currentCount1 % 20 == 10)
                {
                    SmallUp1Dis = nowdata[20];
                }
                SmallUpV = Math.Abs(SmallUp2Dis - SmallUp1Dis);
                txtSmallUpV.Text = SmallUpV.ToString();

                if (f == 1)
                {
                    addDataRunner.Abort();
                    addDataRunner = new Thread(new ThreadStart(AddDataThreadLoop));
                    addDataRunner.IsBackground = true;
                    addDataDel = new AddDataDelegate(AddData3);

                    DateTime timeValue = DateTime.Now;
                    DateTime minValue = timeValue.ToLocalTime();
                    DateTime maxValue = timeValue.AddSeconds(30).ToLocalTime();

                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart1.ChartAreas[0].AxisX.Title = "时间";
                    chart1.ChartAreas[0].AxisY.Title = "位移(mm）";
                    chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart1.Series.Clear();

                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart2.ChartAreas[0].AxisX.Title = "时间";
                    chart2.ChartAreas[0].AxisY.Title = "压力(bar）";
                    chart2.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart2.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart2.Series.Clear();

                    f1 = new Series();
                    f1.ChartType = SeriesChartType.Spline;
                    f1.BorderWidth = 3;
                    f1.BorderColor = Color.Red;
                    f1.LegendText = "上升位移";
                    f1.XValueType = ChartValueType.DateTime;
                    f2 = new Series();


                    f3 = new Series();
                    f3.ChartType = SeriesChartType.Spline;
                    f3.BorderWidth = 3;
                    f3.BorderColor = Color.Red;
                    f3.LegendText = "上升压损";
                    f3.XValueType = ChartValueType.DateTime;


                    chart1.Series.Add(f1);
                    chart2.Series.Add(f3);

                    addDataRunner.Start();
                }
                //？？
                //  ??
            }
            else if (nowdata[9] == 1)
            {
                 clearBox();
                if (g < 3)
                {
                    g += 1;
                }

                txtTestCourse.Text = "门架下降";                                                     
                //算速度
                currentCount2 += 1;
                if (currentCount2 % 20 == 0)
                {
                    SmallDown2Dis = nowdata[20];
                }
                if (currentCount2 % 20 == 10)
                {
                    SmallDown1Dis = nowdata[20];
                }
                SmallDownV = Math.Abs(SmallDown2Dis - SmallDown1Dis);
                txtSmallDownV.Text = SmallDownV.ToString();
                SmallDownDis = nowdata[20];
                txtSmallDownDis.Text = SmallDownDis.ToString();
                txtSmallDownPressureLoss.Text = nowdata[23].ToString();
                if (g == 1)
                {
                    addDataRunner.Abort();
                    addDataRunner = new Thread(new ThreadStart(AddDataThreadLoop));
                    addDataRunner.IsBackground = true;
                    addDataDel = new AddDataDelegate(AddData4);

                    DateTime timeValue = DateTime.Now;
                    DateTime minValue = timeValue.ToLocalTime();
                    DateTime maxValue = timeValue.AddSeconds(30).ToLocalTime();

                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart1.ChartAreas[0].AxisX.Title = "时间";
                    chart1.ChartAreas[0].AxisY.Title = "位移(mm)";
                    chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart1.Series.Clear();

                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart2.ChartAreas[0].AxisX.Title = "时间";
                    chart2.ChartAreas[0].AxisY.Title = "压力(bar）";
                    chart2.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart2.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart2.Series.Clear();

                    f1 = new Series();
                    f1.ChartType = SeriesChartType.Spline;
                    f1.BorderWidth = 3;
                    f1.BorderColor = Color.Red;
                    f1.LegendText = "下降位移";
                    f1.XValueType = ChartValueType.DateTime;
                    f2 = new Series();


                    f3 = new Series();
                    f3.ChartType = SeriesChartType.Spline;
                    f3.BorderWidth = 3;
                    f3.BorderColor = Color.Red;
                    f3.LegendText = "下降压损";
                    f3.XValueType = ChartValueType.DateTime;


                    chart1.Series.Add(f1);
                    chart2.Series.Add(f3);

                    addDataRunner.Start();
                }
                //速度，推动滑阀力，推动滑阀时间？？？
            }

            else if (nowdata[3] == 1)//小门架前倾
            {
                clearBox();
                if (j < 3)
                {
                    j += 1;
                }

                txtTestCourse.Text = "门架前倾";
                setValue(txtSmallForwardInPreLoss, nowdata[24]);
                setValue(txtSmallForwardOutPreLoss, nowdata[25]);
                SmallForwardDis = nowdata[21];
                setValue(txtSmallForwardDis, SmallForwardDis);
                //速度
                currentCount5 += 1;
                if (currentCount5 % 20 == 0)
                {
                    SmallForward2Dis = nowdata[21];
                }
                if (currentCount5 % 20 == 10)
                {
                    SmallForward1Dis = nowdata[21];
                }
                SmallForwardV = Math.Abs(SmallForward2Dis - SmallForward1Dis);
                txtSmallForwardV.Text = SmallForwardV.ToString();
                if (j == 1)
                {
                    addDataRunner.Abort();
                    addDataRunner = new Thread(new ThreadStart(AddDataThreadLoop));
                    addDataRunner.IsBackground = true;
                    addDataDel = new AddDataDelegate(AddData7);

                    DateTime timeValue = DateTime.Now;
                    DateTime minValue = timeValue.ToLocalTime();
                    DateTime maxValue = timeValue.AddSeconds(30).ToLocalTime();

                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart1.ChartAreas[0].AxisX.Title = "时间";
                    chart1.ChartAreas[0].AxisY.Title = "位移(mm）";
                    chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart1.Series.Clear();

                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart2.ChartAreas[0].AxisX.Title = "时间";
                    chart2.ChartAreas[0].AxisY.Title = "流量(l/min）";
                    chart2.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart2.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart2.Series.Clear();

                    f1 = new Series();
                    f1.ChartType = SeriesChartType.Spline;
                    f1.BorderWidth = 3;
                    f1.BorderColor = Color.Red;
                    f1.LegendText = "前倾位移";
                    f1.XValueType = ChartValueType.DateTime;
                    f2 = new Series();


                    f3 = new Series();
                    f3.ChartType = SeriesChartType.Spline;
                    f3.BorderWidth = 3;
                    f3.BorderColor = Color.Red;
                    f3.LegendText = "流量";
                    f3.XValueType = ChartValueType.DateTime;


                    chart1.Series.Add(f1);
                    chart2.Series.Add(f3);

                    addDataRunner.Start();
                }
                //???
            }
            else if (nowdata[4] == 1)//门架前倾动作检测
            {
                clearBox();
                if (m < 3)
                {
                    m += 1;
                }
                txtTestCourse.Text = "门架前倾动作检测";
                setValue(txtSmallForwardInPreLoss, nowdata[24]);
                setValue(txtSmallForwardOutPreLoss, nowdata[25]);
                SmallForwardDis = nowdata[21];
                setValue(txtSmallForwardDis, SmallForwardDis);
                //速度
                currentCount8 += 1;
                if (currentCount8 % 20 == 0)
                {
                    SmallForward2Dis = nowdata[21];
                }
                if (currentCount8 % 20 == 10)
                {
                    SmallForward1Dis = nowdata[21];
                }
                SmallForwardV =Math.Abs(SmallForward2Dis - SmallForward1Dis);
                txtSmallForwardV.Text = SmallForwardV.ToString();
                if (m == 1)
                {
                    addDataRunner.Abort();
                    addDataRunner = new Thread(new ThreadStart(AddDataThreadLoop));
                    addDataRunner.IsBackground = true;
                    addDataDel = new AddDataDelegate(AddData7);

                    DateTime timeValue = DateTime.Now;
                    DateTime minValue = timeValue.ToLocalTime();
                    DateTime maxValue = timeValue.AddSeconds(30).ToLocalTime();

                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart1.ChartAreas[0].AxisX.Title = "时间";
                    chart1.ChartAreas[0].AxisY.Title = "位移(mm）";
                    chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart1.Series.Clear();

                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart2.ChartAreas[0].AxisX.Title = "时间";
                    chart2.ChartAreas[0].AxisY.Title = "流量(l/min）";
                    chart2.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart2.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart2.Series.Clear();

                    f1 = new Series();
                    f1.ChartType = SeriesChartType.Spline;
                    f1.BorderWidth = 3;
                    f1.BorderColor = Color.Red;
                    f1.LegendText = "前倾位移";
                    f1.XValueType = ChartValueType.DateTime;
                    f2 = new Series();


                    f3 = new Series();
                    f3.ChartType = SeriesChartType.Spline;
                    f3.BorderWidth = 3;
                    f3.BorderColor = Color.Red;
                    f3.LegendText = "流量";
                    f3.XValueType = ChartValueType.DateTime;


                    chart1.Series.Add(f1);
                    chart2.Series.Add(f3);

                    addDataRunner.Start();
                }
                //???
            }
            else if (nowdata[5] == 1)//小门架前倾自锁
            {
                 clearBox();
                if (k < 3)
                {
                    k += 1;
                }
                txtTestCourse.Text = "门架前倾自锁";
                setValue(txtSmallForwardInPreLoss, nowdata[24]);
                setValue(txtSmallForwardOutPreLoss, nowdata[25]);
                SmallForwardDis = nowdata[21];
                setValue(txtSmallForwardDis, SmallForwardDis);
                //速度
                currentCount6 += 1;
                if (currentCount6 % 20 == 0)
                {
                    SmallForward2Dis = nowdata[21];
                }
                if (currentCount6 % 20 == 10)
                {
                    SmallForward1Dis = nowdata[21];
                }
                SmallForwardV = Math.Abs(SmallForward2Dis - SmallForward1Dis);
                txtSmallForwardV.Text = SmallForwardV.ToString();
                if (k == 1)
                {
                    addDataRunner.Abort();
                    addDataRunner = new Thread(new ThreadStart(AddDataThreadLoop));
                    addDataRunner.IsBackground = true;
                    addDataDel = new AddDataDelegate(AddData7);

                    DateTime timeValue = DateTime.Now;
                    DateTime minValue = timeValue.ToLocalTime();
                    DateTime maxValue = timeValue.AddSeconds(30).ToLocalTime();

                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart1.ChartAreas[0].AxisX.Title = "时间";
                    chart1.ChartAreas[0].AxisY.Title = "位移(mm）";
                    chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart1.Series.Clear();

                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart2.ChartAreas[0].AxisX.Title = "时间";
                    chart2.ChartAreas[0].AxisY.Title = "流量(l/min）";
                    chart2.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart2.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart2.Series.Clear();

                    f1 = new Series();
                    f1.ChartType = SeriesChartType.Spline;
                    f1.BorderWidth = 3;
                    f1.BorderColor = Color.Red;
                    f1.LegendText = "前倾位移";
                    f1.XValueType = ChartValueType.DateTime;
                    f2 = new Series();


                    f3 = new Series();
                    f3.ChartType = SeriesChartType.Spline;
                    f3.BorderWidth = 3;
                    f3.BorderColor = Color.Red;
                    f3.LegendText = "流量";
                    f3.XValueType = ChartValueType.DateTime;


                    chart1.Series.Add(f1);
                    chart2.Series.Add(f3);

                    addDataRunner.Start();
                }
                //???
            }
            else if (nowdata[2] == 1)
            {
                if (l < 3)
                {
                    l += 1;
                }
                txtTestCourse.Text = "门架后倾";
                setValue(txtSmallBackInPreLoss, nowdata[26]);
                setValue(txtSmallBackOutPreLoss, nowdata[27]);
                SmallBackDis = nowdata[21];
                setValue(txtSmallBackDis, SmallBackDis);

                currentCount7 += 1;
                if (currentCount7 % 20 == 0)
                {
                    SmallBack2Dis = nowdata[21];
                }
                if (currentCount7 % 20 == 10)
                {
                    SmallBack1Dis = nowdata[21];
                }
                SmallBackV = Math.Abs(SmallBack2Dis - SmallBack1Dis);
                txtSmallBackV.Text = SmallBackV.ToString();
                if (l == 1)
                {
                    addDataRunner.Abort();
                    addDataRunner = new Thread(new ThreadStart(AddDataThreadLoop));
                    addDataRunner.IsBackground = true;
                    addDataDel = new AddDataDelegate(AddData8);

                    DateTime timeValue = DateTime.Now;
                    DateTime minValue = timeValue.ToLocalTime();
                    DateTime maxValue = timeValue.AddSeconds(30).ToLocalTime();

                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart1.ChartAreas[0].AxisX.Title = "时间";
                    chart1.ChartAreas[0].AxisY.Title = "门架后倾位移(mm）";
                    chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart1.Series.Clear();

                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
                    chart2.ChartAreas[0].AxisX.Title = "时间";
                    chart2.ChartAreas[0].AxisY.Title = "流量(l/min）";
                    chart2.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
                    chart2.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
                    chart2.Series.Clear();

                    f1 = new Series();
                    f1.ChartType = SeriesChartType.Spline;
                    f1.BorderWidth = 3;
                    f1.BorderColor = Color.Red;
                    f1.LegendText = "后倾位移";
                    f1.XValueType = ChartValueType.DateTime;
                    f2 = new Series();


                    f3 = new Series();
                    f3.ChartType = SeriesChartType.Spline;
                    f3.BorderWidth = 3;
                    f3.BorderColor = Color.Red;
                    f3.LegendText = "流量";
                    f3.XValueType = ChartValueType.DateTime;


                    chart1.Series.Add(f1);
                    chart2.Series.Add(f3);

                    addDataRunner.Start();
                }
                //???
            }
            else if (nowdata[0] != 1 && nowdata[1] != 1 && nowdata[2] != 1 && nowdata[3] != 1 && nowdata[4] != 1 && nowdata[5] != 1 && nowdata[6] != 1 && nowdata[7] != 1 && nowdata[8] != 1 && nowdata[9] != 1 && nowdata[52] != 1 && nowdata[51] != 1 && nowdata[50] != 1 && nowdata[49] != 1)
            {
                txtTestCourse.Text = "中间准备阶段";

            }
            realPilotPressure = pilotPressre;

            if (nowdata[59] == 2)
            {

                if (addDataRunner != null)
                {
                    addDataRunner.Abort();
                    addDataRunner.Join();
                    addDataRunner = null;
                }

                TPCANMsg canmsg101 = new TPCANMsg();
                canmsg101.ID = 0x101;
                canmsg101.LEN = Convert.ToByte(8);
                canmsg101.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                canmsg101.DATA = new byte[8];
                for (int i = 0; i < 8; i++)
                {
                    canmsg101.DATA[i] = 0;
                }


                TPCANMsg canmsg108 = new TPCANMsg();
                canmsg108.ID = 0x108;
                canmsg108.LEN = Convert.ToByte(8);
                canmsg108.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                canmsg108.DATA = new byte[8];
                canmsg108.DATA[3] = 1;//自动测试结束复位标志

                zhiling += 1;
                if (zhiling == 1)
                {
                    try
                    {
                        TPCANStatus sts3 = peakhelper.write(canmsg108);
                        TPCANStatus sts4 = peakhelper.write(canmsg101);
                        if (sts3 == TPCANStatus.PCAN_ERROR_OK && sts4 == TPCANStatus.PCAN_ERROR_OK)
                        {
                            MessageBox.Show("试验已结束");
                            this.Close();

                        }
                        TestFinishedWin win = new TestFinishedWin();
                        win.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("试验结束失败" + ex.Message);
                    }
                }




            }

        }



        private void clearBox()
        {

            foreach (Control c in Controls)
                if (c is MetroTextBox) { c.Text = ""; }
        }

        private void setValue(MetroTextBox tb, double a)
        {
            tb.Text = a.ToString();

        }


        private void autoDataDisplayWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datastoremanager != null)
            {
                datastoremanager.StopTimer1();
            }
            if (peakhelper != null)
            {
                peakhelper.StopTimer();
            }
        }



        private void button2_Click_1(object sender, EventArgs e)
        {

        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            if (addDataRunner != null)
            {
                addDataRunner.Abort();
                addDataRunner.Join();
                addDataRunner = null;
            }
            TPCANMsg canmsg108 = new TPCANMsg();
            canmsg108.ID = 0x108;
            canmsg108.LEN = Convert.ToByte(8);
            canmsg108.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg108.DATA = new byte[8];
            canmsg108.DATA[7] = 1;//中止试验

            TPCANMsg canmsg101 = new TPCANMsg();
            canmsg101.ID = 0x101;
            canmsg101.LEN = Convert.ToByte(8);
            canmsg101.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg101.DATA = new byte[8];
            for (int i = 0;i<8;i++)
            {
                canmsg101.DATA[i] = 0;
            }

            try
            {
                TPCANStatus sts3 = peakhelper.write(canmsg108);
                TPCANStatus sts4 = peakhelper.write(canmsg101);
                if (sts3 == TPCANStatus.PCAN_ERROR_OK && sts4 == TPCANStatus.PCAN_ERROR_OK)
                {
                    MessageBox.Show("试验已被成功中止");
                    this.Close();

                }
                    TestFinishedWin win = new TestFinishedWin();
                    win.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("试验中止失败" + ex.Message);
            }
        }

        private void timer12_Tick(object sender, EventArgs e)
        {
            double[] alarmdata = new double[6];
            alarmdata[0] = peakhelper.AllValue[53];
            alarmdata[1] = peakhelper.AllValue[54];
            alarmdata[2] = peakhelper.AllValue[55];
            alarmdata[3] = peakhelper.AllValue[32];
            alarmdata[4] = peakhelper.AllValue[33];
            alarmdata[5] = peakhelper.AllValue[34];
            string name = UserRightManager.user.userName;//得到操作人的名字
            if (alarmdata[0] == 1)
            {
                timer12.Enabled = false;
                DialogResult dr = MessageBox.Show("注意！主泵1压力已超限，请及时处理", "", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    timer12.Enabled = true;
                }
                string sql = string.Format("insert into Alarm values ('{0}','{1}','{2}')", name, DateTime.Now, "主泵1压力超限");
                dbhelp.ExecuteNonQuery(sql);
            }
            if (alarmdata[1] == 1)
            {
                timer12.Enabled = false;
                DialogResult dr = MessageBox.Show("注意！主泵2压力已超限，请及时处理", "", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    timer12.Enabled = true;
                }
                string sql = string.Format("insert into Alarm values ('{0}','{1}','{2}')", name, DateTime.Now, "主泵2压力超限");
                dbhelp.ExecuteNonQuery(sql);
            }
            if (alarmdata[2] == 1)
            {
                timer12.Enabled = false;
                DialogResult dr = MessageBox.Show("注意！内泄漏流量已超限，请及时处理", "", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    timer12.Enabled = true;
                }
                string sql = string.Format("insert into Alarm values ('{0}','{1}','{2}')", name, DateTime.Now, "内泄漏流量超限");
                dbhelp.ExecuteNonQuery(sql);
            }
            if (alarmdata[3] == 1)
            {
                timer12.Enabled = false;
                DialogResult dr = MessageBox.Show("注意！滤油器1报警，请及时处理", "", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    timer12.Enabled = true;
                }
                string sql = string.Format("insert into Alarm values ('{0}','{1}','{2}')", name, DateTime.Now, "滤油器1报警");
                dbhelp.ExecuteNonQuery(sql);
            }
            if (alarmdata[4] == 1)
            {
                timer12.Enabled = false;
                DialogResult dr = MessageBox.Show("注意！滤油器2报警，请及时处理", "", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    timer12.Enabled = true;
                }
                string sql = string.Format("insert into Alarm values ('{0}','{1}','{2}')", name, DateTime.Now, "滤油器2报警");
                dbhelp.ExecuteNonQuery(sql);
            }
            if (alarmdata[5] == 1)
            {
                timer12.Enabled = false;
                DialogResult dr = MessageBox.Show("注意！滤油器3报警，请及时处理", "", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    timer12.Enabled = true;
                }
                string sql = string.Format("insert into Alarm values ('{0}','{1}','{2}')", name, DateTime.Now, "滤油器3报警");
                dbhelp.ExecuteNonQuery(sql);
            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void unloading_valve_1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ParameterizedThreadStart(send));
            t.Start("A1");
        }

        private void unloading_valve_2_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ParameterizedThreadStart(send));
            t.Start("B1");
        }

        private void unloading_valve_3_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ParameterizedThreadStart(send));
            t.Start("A2");
        }
        private void send(Object str)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("A1",1 );
            dic.Add("B1",2 );
            dic.Add("A2",3 );
            int i = dic[(string)str];
            TPCANMsg canmsg108 = new TPCANMsg();
            canmsg108.ID = 0x108;
            canmsg108.LEN = Convert.ToByte(8);
            canmsg108.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg108.DATA = new byte[8];
            int res = 0;
           
           
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            lock (syncRoot)
            {
                foreach (var n in list)
                {
                    String name = "unloading_valve_" + n;
                    Control[] arr = this.Controls.Find(name, true);
                    if (n != i)
                    {
                        if (arr[0].Text.Contains("关闭"))
                        {
                            int num = (int)Math.Pow(2, n - 1);
                            res = res | num;
                        }
                    }
                    else
                    {
                        if (arr[0].Text.Contains("打开"))
                        {
                            int num = (int)Math.Pow(2, n - 1);
                            res = res | num;
                        }
                    }
                }
                canmsg108.DATA[0] = (byte)res;
                canmsg108.DATA[2] = 1;
                TPCANStatus sts = peakhelper.write(canmsg108);
                if (sts != TPCANStatus.PCAN_ERROR_OK)
                {
                    MessageBox.Show("发送错误");
                }
                else
                {
                    Control c = this.Controls.Find("unloading_valve_" + i, true)[0];
                   // MessageBox.Show(c.Text);
                    if (c.Text.Contains("关闭"))
                    {
                       //c.Text = "卸荷阀" + i + "_打开";
                        c.Invoke(new EventHandler(delegate
                        {

                            c.Text =  "打开"+ "卸荷阀" + str ;

                        }));
                    }
                    else
                    {
                        //c.Text = "卸荷阀" + i + "_关闭";
                        c.Invoke(new EventHandler(delegate

                        {
                            c.Text = "关闭" + "卸荷阀" + str;
                        }));
                    }
                }
            }
        }
    }
}
