using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.Windows.drawing;
using ExperimentTableDetectSystem.Windows.manual;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows
{
    public partial class ManualExperimentWin : MetroFramework.Forms.MetroForm
    {
        #region 字段
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
        double[] nowAlldata = new double[51];
        private string company;
        PeakHelper peakHelperer;
        DataStoreManager dataStoreManager;
        ConfigManager config;

        #endregion

        #region singleton 
        private static ManualExperimentWin instance;
        public static ManualExperimentWin getInstance()
        {
            if (instance == null||instance.IsDisposed)
            {
            instance = new ManualExperimentWin();
            }
            return instance;
        }
        #endregion

        public ManualExperimentWin()
        {
            InitializeComponent();
            peakHelperer = PeakHelper.GetInstance();
            dataStoreManager = DataStoreManager.GetInstance();
            config = ConfigManager.GetInstance();
           
        }
       

        private void ManualExperimentWin_Load(object sender, EventArgs e)
        {
           
            this.panel1.BackColor = Color.FromArgb(255, 50, 161, 206);
            this.panel2.Width = this.panel1.Width / 2;
            this.panel4.Height = this.panel2.Height / 2;
            this.panel6.Height = this.panel4.Height;
            this.valveid = ManualNumberInput.id;
            this.company = ManualNumberInput.company;
            lblValveId.Text = "编号:" + this.valveid.ToString();
            txtinfo.Text="  发往厂家:" + this.company.ToString();
            //获得配置项的值，赋予报警参数? ? ?
            timer1.Enabled = true;
            timer2.Enabled = false;
       
            peakHelperer.StartTimer(250);

            DataStoreManager.productId = this.valveid;
            DataStoreManager.n = ManualNumberInput.n;
           dataStoreManager.StartTimer1(500, 1000);
        }

        /// <summary>
        /// 数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshData();

        }


        /// <summary>
        /// 数据显示
        /// </summary>
        private void refreshData()
        {
            double[] showdata = new double[51];
            for (int i = 0; i < 51; i++)
            {
                showdata[i] = peakHelperer.AllValue[i];
            }
            ///数据显示实现代码？？?
            if (showdata[8] == 0)
            {
                txtmainPumpP1.Text = showdata[0].ToString();

                txtMainPumpP2.Text = showdata[1].ToString();
                txtpumpFlow1.Text = showdata[2].ToString();
                txtPumpFlow2.Text = showdata[3].ToString();
            }

            if (showdata[8] == 1)
            {
                timer1.Enabled = false;
                DialogResult dr = MessageBox.Show("主溢流阀调定试验已做完，请进行转向溢流阀调定测试", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {

                    this.Close();
                }
             //   else { timer1.Enabled = true; }

            }




        }

        
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualExperimentWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataStoreManager != null)
            {
                dataStoreManager.StopTimer1();
            }
            if (peakHelperer != null)
            {
                peakHelperer.StopTimer();
            }
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            double[] showdata = new double[51];
            for (int i = 0; i < 51; i++)
            {
                showdata[i] = peakHelperer.AllValue[i];
            }
            txtmainPumpP1.Text = showdata[4].ToString();
            txtMainPumpP2.Text = showdata[5].ToString();
            txtpumpFlow1.Text = showdata[0].ToString();
            txtPumpFlow2.Text = showdata[1].ToString();
            txtSteerPressure.Text = showdata[6].ToString();
            if (showdata[29] == 1)
            {
                timer2.Enabled = false;
                DialogResult dr=   MessageBox.Show("转向溢流阀调定试验已做完,下面进行自动测试。");
                if (dr == DialogResult.OK)
                {
                    ManualEnd();
                    this.Close();
                }
            }
        }
        private void ManualEnd()
        {
            #region
            TPCANMsg canmsg181;

            canmsg181 = new TPCANMsg();
            canmsg181.ID = 0x181;
            canmsg181.LEN = Convert.ToByte(8);
            canmsg181.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg181.DATA = new byte[8];
            canmsg181.DATA[0] = 1;//结束
            for (int i = 1; i < 8; i++)
            {
                canmsg181.DATA[i] = 0;
            }
            peakHelperer.write(canmsg181);
            #endregion
        }

        private void btnRetest_Click(object sender, EventArgs e)
        {
            TPCANMsg CANMsg;
            TPCANStatus stsResult;

            //创建一帧信息
            CANMsg = new TPCANMsg();
            CANMsg.ID = 0x183;
            CANMsg.LEN = Convert.ToByte(8);
            CANMsg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            CANMsg.DATA = new byte[8];
            for (int i = 0; i < 6; i++)
            {
                CANMsg.DATA[i] = 1;
            }
            CANMsg.DATA[6] = 0;
            CANMsg.DATA[7] = 0;
            peakHelperer.write(CANMsg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TPCANMsg CANMsg;
            TPCANStatus stsResult;

            //创建一帧信息
            CANMsg = new TPCANMsg();
            CANMsg.ID = 0x183;
            CANMsg.LEN = Convert.ToByte(8);
            CANMsg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            CANMsg.DATA = new byte[8];
            for (int i = 0; i < 6; i++)
            {
                CANMsg.DATA[i] = 0;
            }
            CANMsg.DATA[6] = 0;
            CANMsg.DATA[7] = 0;

            TPCANMsg msg = new TPCANMsg();
            msg.ID = 0x183;
            msg.LEN = Convert.ToByte(8);
            msg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            msg.DATA = new byte[8];
            msg.DATA[0] = 1;
            msg.DATA[1] = 0;
            peakHelperer.write(msg);
            peakHelperer.write(CANMsg);
        }

        private void btnStartDraw_Click(object sender, EventArgs e)
        {
            CurveDrawing win = new CurveDrawing();
            win.Show();
        }

        private void btnStartDraw_Click_1(object sender, EventArgs e)
        {

            CurveDrawing win = new CurveDrawing();
            win.Show();
        }
    }
}
