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
        private SetParameterWin()
        {
            InitializeComponent();
            configManager = ConfigManager.GetInstance();
            textList = new List<TextBox>()
            {   txtMaxTemp,
                txtMinTemp,
                txtAtime,
                txtBtime,
                txtLeakageLiftTime,
                txtMainP,
                txtSteeringP,
                txtMediumPTime,
                txtSteerTestTime,

                txtSmallBackS,
                txtSmallDownS,
                txtSmallForwardS,
                txtSmallSelfLockS,
                txtSmallUpS,

                 txtBigBackS,
                 txtBigDownS,
                 txtBigForwardS,
                 txtBigSelfLockS,
                 txtBigUpS,
                 


            };
            configKeysList = new List<ConfigManager.ConfigKeys>()
            {  ConfigManager.ConfigKeys.MaxTemp,
              ConfigManager.ConfigKeys.MinTemp,
               ConfigManager.ConfigKeys.Atime,
             ConfigManager.ConfigKeys.Btime,
             ConfigManager.ConfigKeys.LeakageLiftTime,
              ConfigManager.ConfigKeys.MainP,
             ConfigManager.ConfigKeys.SteeringValveP,
              ConfigManager.ConfigKeys.MediumPTime,
               ConfigManager.ConfigKeys.SteerPreesureTestTime,

             ConfigManager.ConfigKeys.SmallBackS,
             ConfigManager.ConfigKeys.SmallDownS,
             ConfigManager.ConfigKeys.SmallForwardS,
             ConfigManager.ConfigKeys.SmallSelfLockS,
             ConfigManager.ConfigKeys.SmallUpS,//5

             ConfigManager.ConfigKeys.BigBackS,
             ConfigManager.ConfigKeys.BigDownS,
             ConfigManager.ConfigKeys.BigForwardS,
             ConfigManager.ConfigKeys.BigSelfLockS,
             ConfigManager.ConfigKeys.BigUpS,//10
            
           
            
              
                

            };
            SetNumericValue(textList, configKeysList);//文本框与配置相对应


        }
        #region singleton
     
        private static SetParameterWin instance;
        public static SetParameterWin getInstance()
        {
            if (instance == null||instance.IsDisposed)
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

        /// <summary>
        /// 实验参数应该发给plc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetConfigValue();
                configManager.StoreConfigToDb();
                //WriteToPlc();
                writeTest();
                MessageBox.Show("参数发送给plc成功.");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void WriteToPlc()
        {
            #region 0x180
            TPCANMsg canmsg180;
            
            canmsg180 = new TPCANMsg();
            canmsg180.ID = 0x180;
            canmsg180.LEN = Convert.ToByte(8);
            canmsg180.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg180.DATA = new byte[8];

            int MaxTemp = 0;
            int MinTemp = 0;
            int timeofA = 0;// 泄露倾斜阀A口保压时间
            int timeofB = 0; //泄露倾斜阀B口保压时间
           int liftTime = 0;//泄露升降阀口保压时间
            try
            {
                int.TryParse(txtMaxTemp.Text.Trim(), out MaxTemp);
                int.TryParse(txtMinTemp.Text.Trim(), out MinTemp);
                int.TryParse(txtAtime.Text.Trim(), out timeofA);
                int.TryParse(txtBtime.Text.Trim(), out timeofB);
                int.TryParse(txtLeakageLiftTime.Text.Trim(), out liftTime);
            }catch(Exception ex)
            {
                throw ex;
            }
            canmsg180.DATA[0] = Convert.ToByte(MaxTemp);
            canmsg180.DATA[1] = Convert.ToByte(MinTemp);
            canmsg180.DATA[2] = Convert.ToByte(timeofA);
            canmsg180.DATA[3] = Convert.ToByte(timeofB);
            canmsg180.DATA[4] = Convert.ToByte(liftTime);
            for(int i = 5; i < 8; i++)
            {
                canmsg180.DATA[i] = 0;
            }
            #endregion

            #region 0x182
            TPCANMsg canmsg182 = new TPCANMsg();
            canmsg182.ID = 0x182;
            canmsg182.LEN = Convert.ToByte(8);
            canmsg182.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg182.DATA = new byte[8];
            int[] a = new int[5] { 0, 0, 0, 0,0 };
            try
            {
                int.TryParse(txtMainP.Text.Trim(), out a[0]);
                int.TryParse(txtSteeringP.Text.Trim(), out a[1]);
                int.TryParse(txtMediumPTime.Text.Trim(), out a[2]);
                int.TryParse(txtSteerTestTime.Text.Trim(), out a[3]);
                int.TryParse(txtSmallUpS.Text.Trim(), out a[4]);
                canmsg182.DATA[0] = Convert.ToByte(a[0] / 100);
                canmsg182.DATA[1] = Convert.ToByte(a[0] % 100);
                canmsg182.DATA[2] = Convert.ToByte(a[1] / 100);
                canmsg182.DATA[3] = Convert.ToByte(a[1] % 100);
                canmsg182.DATA[4] = Convert.ToByte(a[2]);
                canmsg182.DATA[5] = Convert.ToByte(a[3]);
                canmsg182.DATA[6] = Convert.ToByte(a[4] / 100);
                canmsg182.DATA[7] = Convert.ToByte(a[4] % 100);
            }catch(Exception ex)
            {
                MessageBox.Show("0x182参数转换失败"+ex.Message);
            }
            //手动测试实验的主溢流阀调定压力高位  a[0]
            //手动测试实验的主溢流阀调定压力低位
            // 手动测试实验的转向溢流阀调定压力高位a[1]
            //手动测试实验的转向溢流阀调定压力低位
            //中位压力损失时间                    a[2]
            // 转向压力测试时间                   a[3]
            // 小门架油缸停止上升位移高位         a[4]
            // 小门架油缸停止上升位移低位



            #endregion

            #region 0x183
            TPCANMsg canmsg183 = new TPCANMsg();
            canmsg183.ID = 0x183;
            canmsg183.LEN = Convert.ToByte(8);
            canmsg183.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg183.DATA = new byte[8];
            //0   小门架油缸停止下降位移高位
            //1   小门架油缸停止下降位移低位
            //2   大门架油缸停止上升位移高位
            //3   大门架油缸停止上升位移低位
            //4   大门架油缸停止下降位移高位
            //5   大门架油缸停止下降位移低位
            //6   小门架油缸停止前倾位移高位
            //7   小门架油缸停止前倾位移低位
            int[] b = new int[4] { 0, 0, 0, 0 };
            try
            {
                int.TryParse(txtSmallDownS.Text.Trim(), out b[0]);
                int.TryParse(txtBigUpS.Text.Trim(), out b[1]);
                int.TryParse(txtBigDownS.Text.Trim(), out b[2]);
                int.TryParse(txtSmallForwardS.Text.Trim(), out b[3]);
                for(int i = 0; i < 4; i =i++)
                {
                    canmsg183.DATA[2*i] = Convert.ToByte(b[i] / 100);
                    canmsg183.DATA[2*i + 1] = Convert.ToByte(b[i] % 100);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"0x183数据转换信息帧失败");
            }
            #endregion

            #region 0x184
            //0   小门架油缸停止后倾位移高位
            //1   小门架油缸停止后倾位移低位
            //2   大门架油缸停止前倾位移高位
            //3   大门架油缸停止前倾位移低位
            //4   大门架油缸停止后倾位移高位
            //5   大门架油缸停止后倾位移低位
            //6   小门架油缸前倾自锁位移高位
            //7   小门架油缸前倾自锁位移低位
            TPCANMsg canmsg184 = new TPCANMsg();
            canmsg184.ID = 0x184;
            canmsg184.LEN = Convert.ToByte(8);
            canmsg184.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg184.DATA = new byte[8];
            int[] c = new int[4] { 0, 0, 0, 0 };
            try
            {
                int.TryParse(txtSmallBackS.Text.Trim(), out c[0]);
                int.TryParse(txtBigForwardS.Text.Trim(), out c[1]);
                int.TryParse(txtBigBackS.Text.Trim(), out c[2]);
                int.TryParse(txtSmallSelfLockS.Text.Trim(),out c[3]);
               for(int i = 0; i < 4; i++)
                {
                    canmsg184.DATA[2*i] = Convert.ToByte( c[i]/100);
                    canmsg184.DATA[2 * i + 1] =Convert.ToByte( c[i] % 100);
                }
            }
            catch (Exception ex)
            {

            }
            #endregion

            #region 0x185
            //0   大门架油缸前倾自锁位移高位
            //1   大门架油缸前倾自锁位移低位
            TPCANMsg canmsg185 = new TPCANMsg();
            canmsg185.ID = 0x185;
            canmsg185.LEN = Convert.ToByte(8);
            canmsg185.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg185.DATA = new byte[8];
            int s = 0;
            try
            {
                int.TryParse(txtBigSelfLockS.Text.Trim(), out s);
                canmsg185.DATA[0] =Convert.ToByte( s/100);
                canmsg185.DATA[1] = Convert.ToByte(s % 100);
                for(int i=2;i<8; i++)
                {
                    canmsg185.DATA[i] = 0;
                }
            }
            catch (Exception ex)
            {

            }
            #endregion

            try
            {
             TPCANStatus res1= peakhelper.write(canmsg180);
              TPCANStatus res2= peakhelper.write(canmsg182);
            TPCANStatus res3= peakhelper.write(canmsg183);
             TPCANStatus res4=peakhelper.write(canmsg184);
             TPCANStatus res5=   peakhelper.write(canmsg185);
                if (res1 == TPCANStatus.PCAN_ERROR_OK && res2 == TPCANStatus.PCAN_ERROR_OK && res3 == TPCANStatus.PCAN_ERROR_OK && res4 == TPCANStatus.PCAN_ERROR_OK && res5 == TPCANStatus.PCAN_ERROR_OK)
                {
                    MessageBox.Show("实验参数写入成功");
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
        /// 试验发送参数。
        /// </summary>
        public void writeTest()
        {
            TPCANMsg canmsg183;

            canmsg183 = new TPCANMsg();
            canmsg183.ID = 0x183;
            canmsg183.LEN = Convert.ToByte(8);
            canmsg183.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg183.DATA = new byte[8];
            int mainP;
            int mediumtime;
            int steerTime;
            int.TryParse(txtMainP.Text.Trim(), out mainP);
            int.TryParse(txtMediumPTime.Text.Trim(), out mediumtime);
            int.TryParse(txtSteerTestTime.Text.Trim(), out steerTime);
            for(int i = 0; i < 8; i++)
            {
                canmsg183.DATA[i] = 0;
            }
         //   canmsg183.DATA[1] = 1;
            canmsg183.DATA[0] = Convert.ToByte( mainP);
            canmsg183.DATA[4] =Convert.ToByte( 20);
            canmsg183.DATA[6] = Convert.ToByte(20);
            TPCANStatus sts = peakhelper.write(canmsg183);
        }
    }
}
