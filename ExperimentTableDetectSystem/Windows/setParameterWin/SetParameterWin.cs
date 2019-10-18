using ExperimentTableDetectSystem.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows.setParameterWin
{
    public partial class SetParameterWin : MetroFramework.Forms.MetroForm
    {
        PeakHelper peakhelper;
        ConfigManager configManager;
        List<TextBox> textList;
        List<ConfigManager.ConfigKeys> configKeysList;
        public static int main1;
        public static int steer1;
        public static int over;
        private SetParameterWin()
        {
            InitializeComponent();
            configManager = ConfigManager.GetInstance();
            textList = new List<TextBox>()
            {   txtMaxTemp,
                txtMinTemp,
               // txtAtime,
               // txtBtime,
               // txtLeakageLiftTime,
                txtMainP,
                txtSteeringP,
                txtMediumPTime,
               // txtSteerTestTime,

                txtSmallBackS,
                txtSmallDownS,
                txtSmallForwardS,
              //  txtSmallSelfLockS,
                txtSmallUpS,

                 txtBigBackS,
                 txtBigDownS,
                 txtBigForwardS,
              //   txtBigSelfLockS,
                 txtBigUpS,

                 txtPump1Pressure,
                 txtPump2Pressure,
                 txtLeakageFlow,

                txtP1Speed,
                txtP2Speed,
                txtHotMoterSpeed,
                txtLeadPumpSpeed,
                txtChangeLeakageP,
                txtOverloadP,
             //   txtBackMoterSpeed,



            };
            configKeysList = new List<ConfigManager.ConfigKeys>()
            {  ConfigManager.ConfigKeys.MaxTemp,
              ConfigManager.ConfigKeys.MinTemp,
             //  ConfigManager.ConfigKeys.Atime,
           //  ConfigManager.ConfigKeys.Btime,
            // ConfigManager.ConfigKeys.LeakageLiftTime,
              ConfigManager.ConfigKeys.MainP,
             ConfigManager.ConfigKeys.SteeringValveP,
              ConfigManager.ConfigKeys.MediumPTime,
             //  ConfigManager.ConfigKeys.SteerPreesureTestTime,

             ConfigManager.ConfigKeys.SmallBackS,
             ConfigManager.ConfigKeys.SmallDownS,
             ConfigManager.ConfigKeys.SmallForwardS,
           //  ConfigManager.ConfigKeys.SmallSelfLockS,
             ConfigManager.ConfigKeys.SmallUpS,//5

             ConfigManager.ConfigKeys.BigBackS,
             ConfigManager.ConfigKeys.BigDownS,
             ConfigManager.ConfigKeys.BigForwardS,
            // ConfigManager.ConfigKeys.BigSelfLockS,
             ConfigManager.ConfigKeys.BigUpS,//10
            
             ConfigManager.ConfigKeys.Pump1Pressure,
             ConfigManager.ConfigKeys.Pump2Pressure,
             ConfigManager.ConfigKeys.LeakageFlow,

             ConfigManager.ConfigKeys.P1Speed,
             ConfigManager.ConfigKeys.P2Speed,
             ConfigManager.ConfigKeys.HotMoterSpeed,
             ConfigManager.ConfigKeys.LeadPumpSpeed,

             ConfigManager.ConfigKeys.ChangeLeakageP,
             ConfigManager.ConfigKeys.OverloadP,
           //  ConfigManager.ConfigKeys.BackMoterSpeed,
           
            
              
                

            };
            SetNumericValue(textList, configKeysList);//文本框与配置相对应


        }
        #region singleton

        private static SetParameterWin instance;
        public static SetParameterWin getInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new SetParameterWin();

            }
            return instance;
        }
        #endregion

        #region
        private void SetNumericValue(List<TextBox> numericList, List<ConfigManager.ConfigKeys> configKeysList)
        {
            for (int i = 0; i < numericList.Count; i++)
            {

                numericList[i].Text = configManager.Get(configKeysList[i]).ToString();
            }
        }


        private void SetConfigValue()
        {
            for (int i = 0; i < textList.Count; i++)
            {
                configManager.Set(configKeysList[i], Convert.ToDouble(textList[i].Text));
            }
        }
        #endregion


        private void WriteToPlc()
        {
            #region 0x204
            TPCANMsg canmsg204;

            canmsg204 = new TPCANMsg();
            canmsg204.ID = 0x204;
            canmsg204.LEN = Convert.ToByte(8);
            canmsg204.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg204.DATA = new byte[8];

            int MaxTemp = 0;
            int MinTemp = 0;


                int.TryParse(txtMaxTemp.Text.Trim(), out MaxTemp);
                int.TryParse(txtMinTemp.Text.Trim(), out MinTemp);

            canmsg204.DATA[0] = Convert.ToByte(MaxTemp);
            canmsg204.DATA[1] = Convert.ToByte(MinTemp);
            //邮箱临界最高温度
            //邮箱临界最低温度

            #endregion

            #region 0x102
            TPCANMsg canmsg102 = new TPCANMsg();
            canmsg102.ID = 0x102;
            canmsg102.LEN = Convert.ToByte(8);
            canmsg102.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg102.DATA = new byte[8];
            int[] a = new int[6] { 0, 0, 0, 0, 0, 0 };

                int.TryParse(txtMediumPTime.Text.Trim(), out a[0]);
             //   int.TryParse(txtAtime.Text.Trim(), out a[1]);
             //   int.TryParse(txtBtime.Text.Trim(), out a[2]);
              //  int.TryParse(txtLeakageLiftTime.Text.Trim(), out a[3]);
                int.TryParse(txtSmallUpS.Text.Trim(), out a[4]);
                int.TryParse(txtBigUpS.Text.Trim(), out a[5]);

            canmsg102.DATA[0] = Convert.ToByte(a[0]);         //中位压力损失时间
          //  canmsg102.DATA[1] = Convert.ToByte(a[1]);         //泄露倾斜阀A口保压时间
          //  canmsg102.DATA[2] = Convert.ToByte(a[2]);         //泄露倾斜阀B口保压时间
          //  canmsg102.DATA[3] = Convert.ToByte(a[3]);         //泄露升降阀口保压时间
            canmsg102.DATA[4] = Convert.ToByte(a[4] / 100);   //小门架油缸停止上升位移高两位
            canmsg102.DATA[5] = Convert.ToByte(a[4] % 100);   //小门架油缸停止上升位移低两位
            canmsg102.DATA[6] = Convert.ToByte(a[5] / 100);   //大门架油缸停止上升位移高两位
            canmsg102.DATA[7] = Convert.ToByte(a[5] % 100);   //大门架油缸停止上升位移低两位



            #endregion

            #region 0x103
            TPCANMsg canmsg103 = new TPCANMsg();
            canmsg103.ID = 0x103    ;
            canmsg103.LEN = Convert.ToByte(8);
            canmsg103.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg103.DATA = new byte[8];
            int[] b = new int[4] { 0, 0, 0, 0 };

                int.TryParse(txtSmallBackS.Text.Trim(), out b[0]);
                int.TryParse(txtBigBackS.Text.Trim(), out b[1]);
                int.TryParse(txtSmallForwardS.Text.Trim(), out b[2]);
                int.TryParse(txtBigForwardS.Text.Trim(), out b[3]);
            for (int i = 0; i < 4; i++)
            {
                canmsg103.DATA[2 * i] = Convert.ToByte(b[i] / 100);
                canmsg103.DATA[2 * i + 1] = Convert.ToByte(b[i] % 100);
            }


            #endregion

            #region 0x104
            TPCANMsg canmsg104 = new TPCANMsg();
            canmsg104.ID = 0x104;
            canmsg104.LEN = Convert.ToByte(8);
            canmsg104.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg104.DATA = new byte[8];
            int[] c = new int[2] { 0, 0 };

                int.TryParse(txtSmallDownS.Text.Trim(), out c[0]);
                int.TryParse(txtBigDownS.Text.Trim(), out c[1]);
            for (int i = 0; i < 2; i++)
            {
                canmsg104.DATA[2 * i] = Convert.ToByte(c[i] / 100);
                canmsg104.DATA[2 * i + 1] = Convert.ToByte(c[i] % 100);
            }

            #endregion

            #region 0x111
            //0   手动测试实验的主溢流阀调定压力高位
            //1   手动测试实验的主溢流阀调定压力低位
            //2   手动测试实验的转向溢流阀调定压力高位
            //3   手动测试实验的转向溢流阀调定压力低位

            TPCANMsg canmsg111 = new TPCANMsg();
            canmsg111.ID = 0x111;
            canmsg111.LEN = Convert.ToByte(8);
            canmsg111.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg111.DATA = new byte[8];
            int[] d = new int[4] { 0, 0 ,0,0};
            int.TryParse(txtMainP.Text.Trim(), out d[0]);
            int.TryParse(txtSteeringP.Text.Trim(), out d[1]);
            int.TryParse(txtChangeLeakageP.Text.Trim(), out d[2]);
            int.TryParse(txtOverloadP.Text.Trim(), out d[3]);
            for (int i = 0; i < 4; i++)
            {
                canmsg111.DATA[2 * i] = Convert.ToByte(d[i] / 100);
                canmsg111.DATA[2 * i + 1] = Convert.ToByte(d[i] % 100);
            }    
    
                

            #endregion

            #region 0x201
            TPCANMsg canmsg201;

            canmsg201 = new TPCANMsg();
            canmsg201.ID = 0x201;
            canmsg201.LEN = Convert.ToByte(8);
            canmsg201.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg201.DATA = new byte[8];

                int[] e = new int[4] { 0, 0, 0,0 };
                int.TryParse(txtP1Speed.Text.Trim(), out e[1]);
                int.TryParse(txtP2Speed.Text.Trim(), out e[2]);
                int.TryParse(txtHotMoterSpeed.Text.Trim(), out e[3]);
                for (int i = 1; i < 4; i++)
                {
                    canmsg201.DATA[2 * i] = Convert.ToByte(e[i] / 100);
                    canmsg201.DATA[2 * i + 1] = Convert.ToByte(e[i] % 100);
                }


            #endregion

            #region 0x202
            TPCANMsg canmsg202;

            canmsg202 = new TPCANMsg();
            canmsg202.ID = 0x202;
            canmsg202.LEN = Convert.ToByte(8);
            canmsg202.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg202.DATA = new byte[8];

            int f = 0;
            int.TryParse(txtLeadPumpSpeed.Text.Trim(), out f);
            canmsg202.DATA[0] = Convert.ToByte(f / 100);
            canmsg202.DATA[1] = Convert.ToByte(f % 100);

            #endregion

            #region 0x107
            TPCANMsg canmsg107;
            canmsg107 = new TPCANMsg();
            canmsg107.ID = 0x107;
            canmsg107.LEN = Convert.ToByte(8);
            canmsg107.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg107.DATA = new byte[8];


                int[] g = new int[2] { 0, 0 };
                int.TryParse(txtPump1Pressure.Text.Trim(), out g[0]);
                int.TryParse(txtPump2Pressure.Text.Trim(), out g[1]);
                for (int i = 0; i < 2; i++)
                {
                    canmsg107.DATA[2 * i] = Convert.ToByte(g[i] / 100);
                    canmsg107.DATA[2 * i + 1] = Convert.ToByte(g[i] % 100);
                }         
            #endregion

            #region 0x205
            TPCANMsg canmsg205;
            canmsg205 = new TPCANMsg();
            canmsg205.ID = 0x205;
            canmsg205.LEN = Convert.ToByte(8);
            canmsg205.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg205.DATA = new byte[8];

                int h = 0;
                int.TryParse(txtLeakageFlow.Text.Trim(), out h);
                canmsg205.DATA[0] = Convert.ToByte(h / 100);
                canmsg205.DATA[1] = Convert.ToByte(h % 100);
            #endregion

            try
            {
                TPCANStatus res1 = peakhelper.write(canmsg204);
                TPCANStatus res2 = peakhelper.write(canmsg103);
                TPCANStatus res3 = peakhelper.write(canmsg104);
                TPCANStatus res4 = peakhelper.write(canmsg102);
                TPCANStatus res5 = peakhelper.write(canmsg111);
                TPCANStatus res6 = peakhelper.write(canmsg201);
                TPCANStatus res7 = peakhelper.write(canmsg202);
                TPCANStatus res8 = peakhelper.write(canmsg107);
                TPCANStatus res9 = peakhelper.write(canmsg205);
                if (res1 == TPCANStatus.PCAN_ERROR_OK && res2 == TPCANStatus.PCAN_ERROR_OK && res3 == TPCANStatus.PCAN_ERROR_OK && res4 == TPCANStatus.PCAN_ERROR_OK && res5 == TPCANStatus.PCAN_ERROR_OK && res6 == TPCANStatus.PCAN_ERROR_OK && res7 == TPCANStatus.PCAN_ERROR_OK && res8 == TPCANStatus.PCAN_ERROR_OK && res9 == TPCANStatus.PCAN_ERROR_OK)
                {
                    DialogResult dr = MessageBox.Show("实验参数写入成功");

                }

            }
            catch (Exception ex)
            { MessageBox.Show("写入数据失败" + ex.Message); }



        }

        private void SetParameterWin_Load(object sender, EventArgs e)
        {
            peakhelper = PeakHelper.GetInstance();

        }

        /// <summary>
        /// 实验参数应该发给plc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }


        private void metroTrackBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
            txtP1Speed.Text = metroTrackBar1.Value.ToString();
        }

        private void metroTrackBar2_Scroll_1(object sender, ScrollEventArgs e)
        {
            txtP2Speed.Text = metroTrackBar2.Value.ToString();
        }

        private void metroTrackBar3_Scroll_1(object sender, ScrollEventArgs e)
        {
            txtHotMoterSpeed.Text = metroTrackBar3.Value.ToString();
        }

        private void metroTrackBar4_Scroll_1(object sender, ScrollEventArgs e)
        {
            txtLeadPumpSpeed.Text = metroTrackBar4.Value.ToString();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(txtMainP.Text, out main1);
                int.TryParse(txtSteeringP.Text, out steer1);
                int.TryParse(txtOverloadP.Text, out over);
                SetConfigValue();
                configManager.StoreConfigToDb();
                WriteToPlc();
               // MessageBox.Show("参数发送给plc成功.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}