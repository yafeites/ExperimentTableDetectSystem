using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.util;
using ExperimentTableDetectSystem.Windows.auto;
using ExperimentTableDetectSystem.Windows.manual;
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
        double[] nowAlldata = new double[59];
        private string company;
        DBHelper dbhelper;
        PeakHelper peakHelperer;
        DataStoreManager dataStoreManager;
        ConfigManager config;

        #endregion

        #region singleton 
        private static ManualExperimentWin instance;
        public static ManualExperimentWin getInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ManualExperimentWin();
            }
            return instance;
        }
        #endregion


        int a = 0;
        int b = 0;
        int h = 0;
        int j = 0;
        int k = 0;
        int l = 0;
        int m = 0;
        int n = 0;
        int o = 0;
        int p = 0;
        int q = 0;
        int r = 0;
        int s = 0;
        int t = 0;

        int a21 = 0;
        int a22 = 0;
        int b22 = 0;
        int b21 = 0;
        int qb1 = 0;

        int l2 = 0;
        int a23 = 0;
        int m2 = 0;
        int b23 = 0;
        int oo = 0;
        double mainPump1Pressure = 0;
        double mainPump2Pressure = 0;
        double pump1Flow = 0;
        double pump2Flow = 0;
        double steerPressure = 0;
        double leakageFlow = 0;
        public ManualExperimentWin()
        {
            InitializeComponent();
            dbhelper = DBHelper.GetInstance();
            peakHelperer = PeakHelper.GetInstance();
            dataStoreManager = DataStoreManager.GetInstance();
            config = ConfigManager.GetInstance();
             
        }



        private void ManualExperimentWin_Load(object sender, EventArgs e)
        {
            
            

            this.tableLayoutPanel1.BackColor = Color.FromArgb(255, 50, 161, 206);
            this.valveid = ManualNumberInput.id;
            this.company = ManualNumberInput.company;
            lblValveId.Font= new Font("宋体", 18);
            lblValveId.Text = "编号:" + this.valveid;
            txtinfo.Text = this.company;
            //获得配置项的值，赋予报警参数? ? ?
            timer1.Enabled = true;
            //    timer2.Enabled = false;
            peakHelperer.StartTimer(100);

            DataStoreManager.productId = this.valveid;
            DataStoreManager.n = ManualNumberInput.n;
            DataStoreManager.menjiaType = ManualNumberInput.menjiaType;
            DataStoreManager.valveType = ManualNumberInput.valveType;
            dataStoreManager.StartTimer1(100, 100);

            TPCANMsg canmsg108 = new TPCANMsg();
            canmsg108.ID = 0x108;
            canmsg108.LEN = Convert.ToByte(8);
            canmsg108.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg108.DATA = new byte[8];
            canmsg108.DATA[4] = 1;
            try
            {
                TPCANStatus sts3 = peakHelperer.write(canmsg108);
                if (sts3 == TPCANStatus.PCAN_ERROR_OK)
                {
                   // MessageBox.Show("手动实验开始" );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("手动实验开始信号发送失败" + ex.Message);
            }

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
        int count = 0;
        int[] pump1 = new int[5];
        int[] pump2 = new int[5];
        int[] steerPump = new int[5];
        double[] showdata = new double[76];
        private void refreshData()
        {
            
            for (int i = 0; i < 76; i++)
            {
                showdata[i] = peakHelperer.AllValue[i];
            }
            mainPump1Pressure = (pump1[0]+ pump1[1]+ pump1[2]+ pump1[3]+ pump1[4])/5;
            mainPump2Pressure = (pump2[0] + pump2[1] + pump2[2] + pump2[3] + pump2[4]) / 5;
            pump1Flow = showdata[36];
            pump2Flow = showdata[37];
            steerPressure = (steerPump[0] + steerPump[1] + steerPump[2] + steerPump[3] + steerPump[4]) / 5;
            leakageFlow = showdata[39];

            pump1[count] = (int)showdata[10];
            pump2[count] = (int)showdata[11];
            steerPump[count] = (int)showdata[12];

            ///数据显示实现代码？？?
            if (count < 4)
            {
                count ++;
            }
            else
            {
                count = 0;
            }

            txttankTemp.Text = showdata[44].ToString();
            txtpump1OutTemp.Text = showdata[45].ToString();
            txtpump2OutTemp.Text = showdata[46].ToString();

            txtmainPumpP1.Text = mainPump1Pressure.ToString();
            txtMainPumpP2.Text = mainPump2Pressure.ToString();
            txtpumpFlow1.Text = showdata[36].ToString();
            txtpumpFlow2.Text = showdata[37].ToString();
            txtSteerPressure.Text = steerPressure.ToString();
            txtsteeringFlow.Text = showdata[38].ToString();
            txtLeakageFlow.Text = showdata[39].ToString();
            txtbackFlow.Text = showdata[41].ToString();

            if (showdata[56] == 1)
            {
                txtTestCourse.Text = "转向溢流阀调定";
                txtsteeringFlow.Text = "0";

            }
            else
            {
                txtsteeringFlow.Text = showdata[38].ToString();

            }
            //   if(ManualSelectWin.chkSteerYiliu.Checked)
            if (showdata[56] == 2&&ManualSelectWin.steer==1)
            {
                if (h < 3)
                {
                    h += 1;
                }
                if(h == 1)
                {
                    DialogResult dr = MessageBox.Show("转向溢流阀调定完成，压力调低后点击确定进入启闭特性测试", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        #region 0x113
                        TPCANMsg canmsg113 = new TPCANMsg();
                        canmsg113.ID = 0x113;
                        canmsg113.LEN = Convert.ToByte(8);
                        canmsg113.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                        canmsg113.DATA = new byte[8];
                        canmsg113.DATA[7] = 1;
                        TPCANStatus res1 = peakHelperer.write(canmsg113);
                        #endregion
                    }
                }
            }
            if (showdata[74] == 1)
            {
                txtTestCourse.Text = "转向阀启闭特性试验";

            }
            if (showdata[74] == 2 && ManualSelectWin.steer == 1)
            {
                if (qb1 < 3)
                {
                    qb1 += 1;
                }
                if (qb1 == 1)
                {
                    DialogResult dr = MessageBox.Show("转向阀启闭特性试验已做完，请将压力调高后点击确定进行下一步", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        #region 0x113
                        TPCANMsg canmsg113 = new TPCANMsg();
                        canmsg113.ID = 0x113;
                        canmsg113.LEN = Convert.ToByte(8);
                        canmsg113.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                        canmsg113.DATA = new byte[8];
                        canmsg113.DATA[0] = 1;
                        TPCANStatus res1 = peakHelperer.write(canmsg113);
                        #endregion
                    }
                }
            }
            if (showdata[63] == 1)
            {
                txtTestCourse.Text = "过载阀B3口调定试验";

            }
            if (showdata[63] == 2&&ManualSelectWin.over == 1)
            {
                if (l < 3)
                {
                    l += 1;
                }
                if (l == 1)
                {
                    DialogResult dr = MessageBox.Show("过载阀B3口调定完成，请将压力调低后点击确定进入启闭特性测试", "提示", MessageBoxButtons.OKCancel);
                    
                    if (dr == DialogResult.OK)
                    {
                        #region 0x114
                        TPCANMsg canmsg114 = new TPCANMsg();
                        canmsg114.ID = 0x114;
                        canmsg114.LEN = Convert.ToByte(8);
                        canmsg114.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                        canmsg114.DATA = new byte[8];
                        canmsg114.DATA[0] = 1;
                        TPCANStatus res1 = peakHelperer.write(canmsg114);
                        #endregion
                    }
                }
            }

            if (showdata[28] == 1)
            {
                txtTestCourse.Text = "过载阀B3口启闭特性试验";

            }
            if (showdata[28] == 2 && ManualSelectWin.over == 1)
            {
                if (l2 < 3)
                {
                    l2 += 1;
                }
                if (l2 == 1)
                {
                    DialogResult dr = MessageBox.Show("过载阀B3口启闭特性试验已做完，请将压力调高后点击确定进入下一步", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        #region 0x113
                        TPCANMsg canmsg113 = new TPCANMsg();
                        canmsg113.ID = 0x113;
                        canmsg113.LEN = Convert.ToByte(8);
                        canmsg113.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                        canmsg113.DATA = new byte[8];
                        canmsg113.DATA[4] = 1;
                        TPCANStatus res1 = peakHelperer.write(canmsg113);
                        #endregion
                    }
                }
            }

            if (showdata[71] == 1)
            {


                txtTestCourse.Text = "过载阀A3口调定试验";

            }
            if (showdata[71] == 2 && ManualSelectWin.over2 == 1)
            {
                if (a22 < 3)
                {
                    a22 += 1;
                }
                if (a22 == 1)
                {
                    DialogResult dr = MessageBox.Show("过载阀A3口调定完成，请将压力调低后点击确定进入启闭特性测试", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        #region 0x114
                        TPCANMsg canmsg114 = new TPCANMsg();
                        canmsg114.ID = 0x114;
                        canmsg114.LEN = Convert.ToByte(8);
                        canmsg114.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                        canmsg114.DATA = new byte[8];
                        canmsg114.DATA[1] = 1;
                        TPCANStatus res1 = peakHelperer.write(canmsg114);
                        #endregion
                    }
                }
            }
            if (showdata[29] == 1)
            {
                txtTestCourse.Text = "过载阀A3口启闭特性试验";

            }
            if (showdata[29] == 2 && ManualSelectWin.over2 == 1)
            {
                if (a23 < 3)
                {
                    a23 += 1;
                }
                if (a23 == 1)
                {
                    DialogResult dr = MessageBox.Show("过载阀A3口启闭特性试验已做完，请将压力调高后点击确定进入下一步", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        #region 0x113
                        TPCANMsg canmsg113 = new TPCANMsg();
                        canmsg113.ID = 0x113;
                        canmsg113.LEN = Convert.ToByte(8);
                        canmsg113.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                        canmsg113.DATA = new byte[8];
                        canmsg113.DATA[1] = 1;
                        TPCANStatus res1 = peakHelperer.write(canmsg113);
                        #endregion
                    }
                }
            }
            if (showdata[64] == 1)
            {

                txtTestCourse.Text = "过载阀B4口调定试验";
            }
            if (showdata[64] == 2 && ManualSelectWin.over3 == 1)
            {
                if (m < 3)
                {
                    m += 1;
                }
                if (m == 1)
                {
                    DialogResult dr = MessageBox.Show("过载阀B4口调定完成，请将压力调低后点击确定进入启闭特性测试", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        #region 0x114
                        TPCANMsg canmsg114 = new TPCANMsg();
                        canmsg114.ID = 0x114;
                        canmsg114.LEN = Convert.ToByte(8);
                        canmsg114.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                        canmsg114.DATA = new byte[8];
                        canmsg114.DATA[2] = 1;
                        TPCANStatus res1 = peakHelperer.write(canmsg114);
                        #endregion
                    }
                }
            }
            if (showdata[30] == 1)
            {
                txtTestCourse.Text = "过载阀B4口启闭特性试验";

            }
            if (showdata[30] == 2 && ManualSelectWin.over3 == 1)
            {
                if (m2 < 3)
                {
                    m2 += 1;
                }
                if (m2 == 1)
                {
                    DialogResult dr = MessageBox.Show("过载阀B4口启闭特性试验已做完，请将压力调高后点击确定进入下一步", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        #region 0x113
                        TPCANMsg canmsg113 = new TPCANMsg();
                        canmsg113.ID = 0x113;
                        canmsg113.LEN = Convert.ToByte(8);
                        canmsg113.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                        canmsg113.DATA = new byte[8];
                        canmsg113.DATA[5] = 1;
                        TPCANStatus res1 = peakHelperer.write(canmsg113);
                        #endregion
                    }
                }
            }
            if (showdata[72] == 1)
            {
                txtTestCourse.Text = "过载阀A4口调定试验";

            }
            if (showdata[72] == 2 && ManualSelectWin.over4 == 1)
            {
                if (b22 < 3)
                {
                    b22 += 1;
                }
                if (b22 == 1)
                {
                    DialogResult dr = MessageBox.Show("过载阀A4口调定完成，请将压力调低后点击确定进入启闭特性测试", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        #region 0x114
                        TPCANMsg canmsg114 = new TPCANMsg();
                        canmsg114.ID = 0x114;
                        canmsg114.LEN = Convert.ToByte(8);
                        canmsg114.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                        canmsg114.DATA = new byte[8];
                        canmsg114.DATA[3] = 1;
                        TPCANStatus res1 = peakHelperer.write(canmsg114);
                        #endregion
                    }
                }
            }
            if (showdata[31] == 1)
            {
                txtTestCourse.Text = "过载阀A4口启闭特性试验";

            }
            if (showdata[31] == 2 && ManualSelectWin.over4 == 1)
            {
                if (b23 < 3)
                {
                    b23 += 1;
                }
                if (b23 == 1)
                {
                    DialogResult dr = MessageBox.Show("过载阀A4口启闭特性试验已做完，请将压力调高后点击确定进入下一步", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        #region 0x113
                        TPCANMsg canmsg113 = new TPCANMsg();
                        canmsg113.ID = 0x113;
                        canmsg113.LEN = Convert.ToByte(8);
                        canmsg113.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                        canmsg113.DATA = new byte[8];
                        canmsg113.DATA[2] = 1;
                        TPCANStatus res1 = peakHelperer.write(canmsg113);
                        #endregion
                    }
                }
            }
            if (showdata[57] == 1)
            {
                txtTestCourse.Text = "主溢流阀调定";

            }
            if (showdata[57] == 2 && ManualSelectWin.main == 1)
            {
                if (o < 3)
                {
                    o += 1;
                }
                if (o == 1)
                {
                    DialogResult dr = MessageBox.Show("主溢流阀调定完成，请将压力调低后点击确定进入启闭特性测试", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        #region 0x114
                        TPCANMsg canmsg114 = new TPCANMsg();
                        canmsg114.ID = 0x114;
                        canmsg114.LEN = Convert.ToByte(8);
                        canmsg114.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                        canmsg114.DATA = new byte[8];
                        canmsg114.DATA[4] = 1;
                        TPCANStatus res1 = peakHelperer.write(canmsg114);
                        #endregion
                    }
                }
            }
            if (showdata[75] == 1)
            {
                txtTestCourse.Text = "主溢流阀启闭特性试验";

            }
            if (showdata[75] == 2 && ManualSelectWin.main == 1)
            {
                if (oo < 3)
                {
                    oo += 1;
                }
                if (oo == 1)
                {
                    DialogResult dr = MessageBox.Show("主溢流阀启闭特性试验已做完，请将压力调高后点击确定进入下一步", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        #region 0x113
                        TPCANMsg canmsg113 = new TPCANMsg();
                        canmsg113.ID = 0x113;
                        canmsg113.LEN = Convert.ToByte(8);
                        canmsg113.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                        canmsg113.DATA = new byte[8];
                        canmsg113.DATA[3] = 1;
                        TPCANStatus res1 = peakHelperer.write(canmsg113);
                        #endregion
                        if (ManualSelectWin.change == 1)
                        {
                            txtTestCourse.Text = "换向泄漏压力调定过程";
                        }
                        txtTestCourse.ForeColor = Color.Red;
                    }
                }
            }
            if (showdata[58] == 2 && ManualSelectWin.change == 1)
            {
                if (o < 5)
                {
                    o += 1;
                }
                if (o == 4)
                {
                    DialogResult dr = MessageBox.Show("换向压力调定完成后，点击确定进行下一步", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        #region 0x113
                        TPCANMsg canmsg113 = new TPCANMsg();
                        canmsg113.ID = 0x113;
                        canmsg113.LEN = Convert.ToByte(8);
                        canmsg113.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                        canmsg113.DATA = new byte[8];
                        canmsg113.DATA[6] = 1;
                        TPCANStatus res1 = peakHelperer.write(canmsg113);
                        #endregion
                    }
                }
            }

            if (showdata[73] == 1)
            {
                //this.txtBigBackDis
                if (a < 3)
                {
                    a += 1;
                }

                txtTestCourse.Text = "换向泄漏上升口试验";
                txtTestCourse.ForeColor = Color.Black;

            }
            if (showdata[65] == 1)
            {
                //this.txtBigBackDis
                if (p < 3)
                {
                    p += 1;
                }

                txtTestCourse.Text = "换向泄漏前倾口试验";
                txtTestCourse.ForeColor = Color.Black;

            }
            if (showdata[67] == 1)
            {
                //this.txtBigBackDis
                if (q < 3)
                {
                    q += 1;
                }

                txtTestCourse.Text = "换向泄漏B3口试验";
                txtTestCourse.ForeColor = Color.Black;

            }
            if (showdata[68] == 1)
            {
                //this.txtBigBackDis
                if (r < 3)
                {
                    r += 1;
                }

                txtTestCourse.Text = "换向泄漏A3口试验";
                txtTestCourse.ForeColor = Color.Black;

            }
            if (showdata[69] == 1)
            {
                //this.txtBigBackDis
                if (s < 3)
                {
                    s += 1;
                }

                txtTestCourse.Text = "换向泄漏B4口试验";
                txtTestCourse.ForeColor = Color.Black;

            }
            if (showdata[70] == 1)
            {
                //this.txtBigBackDis
                if (t < 3)
                {
                    t += 1;
                }

                txtTestCourse.Text = "换向泄漏A4口试验";
                txtTestCourse.ForeColor = Color.Black;

            }
            if (showdata[66] == 1)
            {
                //this.txtBigBackDis
                if (n < 3)
                {
                    n += 1;
                }

                txtTestCourse.Text = "换向泄漏后倾口试验";
                txtTestCourse.ForeColor = Color.Black;

            }
            if (showdata[70] == 2)
            {
                timer1.Enabled = false;
                //txtTestCourse.Text = "换向泄漏压力调定过程";
                TPCANMsg canmsg108 = new TPCANMsg();
                canmsg108.ID = 0x108;
                canmsg108.LEN = Convert.ToByte(8);
                canmsg108.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                canmsg108.DATA = new byte[8];
                canmsg108.DATA[4] = 0;
                canmsg108.DATA[5] = 1;
                peakHelperer.write(canmsg108);

                #region 0x113
                TPCANMsg canmsg113 = new TPCANMsg();
                canmsg113.ID = 0x113;
                canmsg113.LEN = Convert.ToByte(8);
                canmsg113.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                canmsg113.DATA = new byte[8];
                for(int i = 0; i < 8; i++)
                {
                    canmsg113.DATA[i] = 0;
                }
                TPCANStatus res1 = peakHelperer.write(canmsg113);
                #endregion
                #region 0x114
                TPCANMsg canmsg114 = new TPCANMsg();
                canmsg114.ID = 0x114;
                canmsg114.LEN = Convert.ToByte(8);
                canmsg114.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                canmsg114.DATA = new byte[8];
                for (int i = 0; i < 8; i++)
                {
                    canmsg114.DATA[i] = 0;
                }
                #endregion
                TPCANStatus res2 = peakHelperer.write(canmsg114);
                DialogResult dr = MessageBox.Show("手动试验已做完,下面进行自动测试。");
                if (dr == DialogResult.OK)
                {
                     ManualEnd();
                    /*if (addDataRunner != null)
                    {
                        addDataRunner.Abort();
                        addDataRunner.Join();
                        addDataRunner = null;
                    }*/
                    
                    this.Close();
                    AutoExperimentWin win = AutoExperimentWin.getInstance();
                    win.Show();
                }
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


          private void ManualEnd()
          {
            TPCANMsg canmsg108 = new TPCANMsg();
            canmsg108.ID = 0x108;
            canmsg108.LEN = Convert.ToByte(8);
            canmsg108.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg108.DATA = new byte[8];
            canmsg108.DATA[4] = 0;
            canmsg108.DATA[5] = 0;

            try
            {
                TPCANStatus sts3 = peakHelperer.write(canmsg108);
                if (sts3 == TPCANStatus.PCAN_ERROR_OK)
                {
                   // MessageBox.Show("手动实验结束");

                 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("手动实验结束信号发送失败" + ex.Message);
            }

        }



        private void timer2_Tick(object sender, EventArgs e)
        {
            double[] alarmdata = new double[6];
            alarmdata[0] = peakHelperer.AllValue[53];
            alarmdata[1] = peakHelperer.AllValue[54];
            alarmdata[2] = peakHelperer.AllValue[55];
            alarmdata[3] = peakHelperer.AllValue[32];
            alarmdata[4] = peakHelperer.AllValue[33];
            alarmdata[5] = peakHelperer.AllValue[34];
            string name = UserRightManager.user.userName;//得到操作人的名字
            if (alarmdata[0] == 1)
            {
                timer2.Enabled = false;
                DialogResult dr = MessageBox.Show("注意！主泵1压力已超限，请及时处理", "", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    timer2.Enabled = true;
                }
                string sql = string.Format("insert into Alarm values ('{0}','{1}','{2}')", name, DateTime.Now, "主泵1压力超限");
                dbhelper.ExecuteNonQuery(sql);
            }
            if (alarmdata[1] == 1)
            {
                timer2.Enabled = false;
                DialogResult dr = MessageBox.Show("注意！主泵2压力已超限，请及时处理", "", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    timer2.Enabled = true;
                }
                string sql = string.Format("insert into Alarm values ('{0}','{1}','{2}')", name, DateTime.Now, "主泵2压力超限");
                dbhelper.ExecuteNonQuery(sql);
            }
            if (alarmdata[2] == 1)
            {
                timer2.Enabled = false;
                DialogResult dr = MessageBox.Show("注意！内泄漏流量已超限，请及时处理", "", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    timer2.Enabled = true;
                }
                string sql = string.Format("insert into Alarm values ('{0}','{1}','{2}')", name, DateTime.Now, "内泄漏流量超限");
                dbhelper.ExecuteNonQuery(sql);
            }
            if (alarmdata[3] == 1)
            {
                timer2.Enabled = false;
                DialogResult dr = MessageBox.Show("注意！滤油器1报警，请及时处理", "", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    timer2.Enabled = true;
                }
                string sql = string.Format("insert into Alarm values ('{0}','{1}','{2}')", name, DateTime.Now, "滤油器1报警");
                dbhelper.ExecuteNonQuery(sql);
            }
            if (alarmdata[4] == 1)
            {
                timer2.Enabled = false;
                DialogResult dr = MessageBox.Show("注意！滤油器2报警，请及时处理", "", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    timer2.Enabled = true;
                }
                string sql = string.Format("insert into Alarm values ('{0}','{1}','{2}')", name, DateTime.Now, "滤油器2报警");
                dbhelper.ExecuteNonQuery(sql);
            }
            if (alarmdata[5] == 1)
            {
                timer2.Enabled = false;
                DialogResult dr = MessageBox.Show("注意！滤油器3报警，请及时处理", "", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    timer2.Enabled = true;
                }
                string sql = string.Format("insert into Alarm values ('{0}','{1}','{2}')", name, DateTime.Now, "滤油器3报警");
                dbhelper.ExecuteNonQuery(sql);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            TPCANMsg canmsg108 = new TPCANMsg();
            canmsg108.ID = 0x108;
            canmsg108.LEN = Convert.ToByte(8);
            canmsg108.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg108.DATA = new byte[8];
            canmsg108.DATA[7] = 1;//中止试验

            #region 0x113
            TPCANMsg canmsg113 = new TPCANMsg();
            canmsg113.ID = 0x113;
            canmsg113.LEN = Convert.ToByte(8);
            canmsg113.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg113.DATA = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                canmsg113.DATA[i] = 0;
            }
            #endregion
            #region 0x114
            TPCANMsg canmsg114 = new TPCANMsg();
            canmsg114.ID = 0x114;
            canmsg114.LEN = Convert.ToByte(8);
            canmsg114.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg114.DATA = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                canmsg114.DATA[i] = 0;
            }
            #endregion

            TPCANMsg canmsg112 = new TPCANMsg();
            canmsg112.ID = 0x112;
            canmsg112.LEN = Convert.ToByte(8);
            canmsg112.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg112.DATA = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                canmsg112.DATA[i] = 0;
            }

            try
            {
                TPCANStatus sts3 = peakHelperer.write(canmsg108);
                TPCANStatus sts4 = peakHelperer.write(canmsg112);
                TPCANStatus res1 = peakHelperer.write(canmsg113);
                TPCANStatus res2 = peakHelperer.write(canmsg114);
                if (sts3 == TPCANStatus.PCAN_ERROR_OK && sts4 == TPCANStatus.PCAN_ERROR_OK && res1 == TPCANStatus.PCAN_ERROR_OK && res2 == TPCANStatus.PCAN_ERROR_OK)
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

        /*private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            TPCANMsg canmsg108 = new TPCANMsg();
            canmsg108.ID = 0x108;
            canmsg108.LEN = Convert.ToByte(8);
            canmsg108.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg108.DATA = new byte[8];
            canmsg108.DATA[4] = 0;
            canmsg108.DATA[5] = 1;
            peakHelperer.write(canmsg108);
            DialogResult dr = MessageBox.Show("跳转到自动测试阶段。");
            if (dr == DialogResult.OK)
            {
                ManualEnd();
                if (addDataRunner != null)
                {
                    addDataRunner.Abort();
                    addDataRunner.Join();
                    addDataRunner = null;
                }

                this.Close();
                AutoExperimentWin win = AutoExperimentWin.getInstance();
                win.Show();
            }
        }*/
    }
}
