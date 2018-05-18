using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.Windows.manual;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows.auto
{
    public partial class autoDataDisplayWin : MetroFramework.Forms.MetroForm
    {
        #region singleton
        private static autoDataDisplayWin instance;
    
        public static autoDataDisplayWin getInstance()
        {
            if (instance == null||instance.IsDisposed)
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
        PeakHelper peakhelper;
        DataStoreManager datastoremanager;

        #endregion
        private autoDataDisplayWin()
        {
            InitializeComponent();

            peakhelper = PeakHelper.GetInstance();
            datastoremanager = DataStoreManager.GetInstance();
        }
        
        private void autoDataDisplayWin_Load(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.FromArgb(255, 50, 161, 206);
            this.panel2.Width = this.panel1.Width / 2;
            this.panel4.Height = this.panel2.Height / 2;
            this.panel6.Height = this.panel4.Height;
            this.valveid = ManualNumberInput.id;
            this.company = ManualNumberInput.company;
            this.lblValveId.Text ="阀编号"+ valveid;
            this.txtinfo.Text ="发往公司名"+ company;
            peakhelper.StartTimer(250);
            DataStoreManager.productId = this.valveid;
            DataStoreManager.n = ManualNumberInput.n;
            datastoremanager.startTimer2(500,1000);

         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            TestFinishedWin win = new TestFinishedWin();
            win.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // refresh();
            testRefresh();
        }
        private void refresh()
        {
            double[] nowdata = new double[51];
            for (int i = 0; i <51; i++)
            {
                nowdata[i] = peakhelper.AllValue[i];
            }
            if (nowdata[30] == 1)//中位压力损失
            {   //foreach(Control c in Controls)
                 //   if(c is TextBox) { c.Text = ""; }
                txtmainPumpP1.Text = nowdata[4].ToString();
                txtMainPumpP2.Text = nowdata[5].ToString();
                txtpumpFlow1.Text = nowdata[0].ToString();
                txtPumpFlow2.Text = nowdata[1].ToString();
                txtSystemBackPressure.Text = nowdata[47].ToString();//系统背压
                txtMediumPressureLoss.Text = nowdata[7].ToString();
            }
            if (nowdata[31] == 1)//转向优先阀流量测试
            {
              //  foreach (Control c in Controls)
                  //  if (c is TextBox) { c.Text = ""; }
                txtmainPumpP1.Text = nowdata[4].ToString();
                txtMainPumpP2.Text = nowdata[5].ToString();
                txtpumpFlow1.Text = nowdata[0].ToString();
                txtPumpFlow2.Text = nowdata[1].ToString();
                txtsteeringFlow.Text= nowdata[2].ToString();
                txtSteerPressure.Text = nowdata[6].ToString();

            }
            if (nowdata[40] == 1)//内泄漏测试
            {
                clearBox();
              //  ???

            }
            if (nowdata[32] == 1)//小门架上升
            {
              //  clearBox();
                txtmainPumpP1.Text = nowdata[4].ToString();
                txtpumpFlow1.Text = nowdata[0].ToString();
                txtOilPressure.Text = nowdata[48].ToString();
                txtSmallUpPreLoss.Text= nowdata[9].ToString();
                txtSmallUpDis.Text = nowdata[8].ToString();
                txtSmallUpPreLoss.Text = nowdata[9].ToString();
                txtsteeringFlow.Text = nowdata[2].ToString();
                txtSteerPressure.Text = nowdata[6].ToString();
                //??速度
                //？？
                //  ??
            }
            if (nowdata[33] == 1)
            {
               // clearBox();
                txtmainPumpP1.Text = nowdata[4].ToString();
                txtpumpFlow1.Text = nowdata[0].ToString();
                txtOilPressure.Text = nowdata[48].ToString();
                txtSystemBackPressure.Text = nowdata[47].ToString();//系统背压

                txtSmallDownDis.Text = nowdata[10].ToString();
                txtSmallDownPressureLoss.Text = nowdata[11].ToString();
                txtsteeringFlow.Text = nowdata[2].ToString();
                txtSteerPressure.Text = nowdata[6].ToString();
                //速度，推动滑阀力，推动滑阀时间？？？
            }
            if (nowdata[34] == 1)//大门架上升
            {
              //  clearBox();
                txtmainPumpP1.Text = nowdata[4].ToString();
                txtMainPumpP2.Text = nowdata[5].ToString();
                txtpumpFlow1.Text = nowdata[0].ToString();
                txtPumpFlow2.Text = nowdata[1].ToString();
                txtOilPressure.Text = nowdata[48].ToString();
                txtsteeringFlow.Text = nowdata[2].ToString();
                txtSteerPressure.Text = nowdata[6].ToString();

                txtBigUpDis.Text = nowdata[12].ToString();
                txtBigUpPressureLoss.Text = nowdata[13].ToString();
                ////速度，推动滑阀力，推动滑阀时间？？？
            }
            if (nowdata[35] == 1)
            {
                //clearBox();
                txtmainPumpP1.Text = nowdata[4].ToString();
                txtMainPumpP2.Text = nowdata[5].ToString();
                txtpumpFlow1.Text = nowdata[0].ToString();
                txtPumpFlow2.Text = nowdata[1].ToString();
                txtOilPressure.Text = nowdata[48].ToString();
                txtsteeringFlow.Text = nowdata[2].ToString();
                txtSteerPressure.Text = nowdata[6].ToString();

                txtBigDownDis.Text = nowdata[14].ToString();
                txtBigDownPressureLoss.Text = nowdata[15].ToString();
                setValue(txtSystemBackPressure, nowdata[47]);
                //??
               // ??
               //??
            }
            if (nowdata[36] == 1||nowdata[41]==1)//小门架前倾
            {
               // clearBox();
                setValue(txtmainPumpP1, nowdata[4]);
                setValue(txtpumpFlow1, nowdata[0]);
                setValue(txtoilInPressure, nowdata[49]);
                setValue(txtoilOutPressure, nowdata[50]);
                setValue(txtSystemBackPressure, nowdata[47]);
                txtsteeringFlow.Text = nowdata[2].ToString();
                txtSteerPressure.Text = nowdata[6].ToString();

                setValue(txtSmallForwardInPreLoss, nowdata[17]);
                setValue(txtSmallForwardOutPreLoss,nowdata[18]);
                setValue(txtBigForwardDis, nowdata[16]);
                //???
            }
            if (nowdata[37] == 1)
            {
               // clearBox();
                setValue(txtmainPumpP1, nowdata[4]);
                setValue(txtpumpFlow1, nowdata[0]);
                setValue(txtoilInPressure, nowdata[49]);
                setValue(txtoilOutPressure, nowdata[50]);
                setValue(txtSystemBackPressure, nowdata[47]);
                txtsteeringFlow.Text = nowdata[2].ToString();
                txtSteerPressure.Text = nowdata[6].ToString();

                setValue(txtSmallBackInPreLoss, nowdata[20]);
                setValue(txtSmallBackOutPreLoss, nowdata[21]);
                setValue(txtSmallBackDis, nowdata[19]);
                //???
            }
            if (nowdata[38] == 1||nowdata[42]==1)
            {
               // clearBox();
                setValue(txtmainPumpP1, nowdata[4]);
                setValue(txtpumpFlow1, nowdata[0]);
                setValue(txtoilInPressure, nowdata[49]);
                setValue(txtoilOutPressure, nowdata[50]);
                setValue(txtSystemBackPressure, nowdata[47]);
                setValue(txtMainPumpP2, nowdata[5]);
                setValue(txtPumpFlow2, nowdata[1]);
                txtsteeringFlow.Text = nowdata[2].ToString();
                txtSteerPressure.Text = nowdata[6].ToString();

                setValue(txtBigForwardDis, nowdata[22]);
                setValue(txtBigForwardOutPressureLoss, nowdata[24]);
                setValue(txtBigForwardInPressureLoss, nowdata[23]);

            }
            if (nowdata[39] == 1)
            {
              //  clearBox();
                setValue(txtmainPumpP1, nowdata[4]);
                setValue(txtpumpFlow1, nowdata[0]);
                setValue(txtoilInPressure, nowdata[49]);
                setValue(txtoilOutPressure, nowdata[50]);
                setValue(txtSystemBackPressure, nowdata[47]);
                setValue(txtMainPumpP2, nowdata[5]);
                setValue(txtPumpFlow2, nowdata[1]);
                txtsteeringFlow.Text = nowdata[2].ToString();
                txtSteerPressure.Text = nowdata[6].ToString();

                setValue(txtBigBackDis, nowdata[25]);
                setValue(txtBIgBackInPressureLoss, nowdata[26]);
                setValue(txtBigBackOutPressureLoss, nowdata[27]);

            }
            

        }

        private void testRefresh()
        {
            double[] showdata = new double[11];
            for (int i = 0; i < 11; i++)
            {
                showdata[i] = peakhelper.AllValue[i];
            }
            ///数据显示实现代码？？?
            if (showdata[9] == 0)//正在做中位压力损失试验
            {
                txtTestCourse.Text = "中位压力测试";
                txtmainPumpP1.Text = showdata[0].ToString();
                txtMainPumpP2.Text = showdata[1].ToString();
                txtpumpFlow1.Text = showdata[2].ToString();
                txtPumpFlow2.Text = showdata[3].ToString();
                txtSystemBackPressure.Text = showdata[4].ToString();
                txtMediumPressureLoss.Text = showdata[5].ToString();
            }
            if (showdata[9] == 1)//正在做转向压力测试
            {
               
                txtTestCourse.Text = "转向优先阀流量测试";
                txtSystemBackPressure.Text ="";
                txtMediumPressureLoss.Text ="";
                txtmainPumpP1.Text = showdata[0].ToString();
                txtMainPumpP2.Text = showdata[1].ToString();
                txtpumpFlow1.Text = showdata[2].ToString();
                txtPumpFlow2.Text = showdata[3].ToString();
                txtsteeringFlow.Text = showdata[7].ToString();
                txtSteerPressure.Text = showdata[6].ToString();
            }
            if (showdata[10] == 1)
            {
                this.Close();
                TestFinishedWin win = new TestFinishedWin();
                win.Show();
            }

        }

        private void showAll()
        {

        }

        private void clearBox()
        {

            foreach (Control c in Controls)
                if (c is TextBox) { c.Text = ""; }
        }

        private void setValue(MetroTextBox tb,double a)
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

      
    }
}
