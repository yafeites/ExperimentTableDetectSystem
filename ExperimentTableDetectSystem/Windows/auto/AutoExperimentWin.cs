using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.Windows.auto;
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
    public partial class AutoExperimentWin : MetroFramework.Forms.MetroForm
    {
        #region singleton
        private static AutoExperimentWin instance;
     //   private static object obj = new object();
        public static AutoExperimentWin getInstance()
       {
            if (instance == null||instance.IsDisposed)
            { //lock (obj)
               // {
                  //  if (instance == null)
                   // {
                        instance = new AutoExperimentWin();
                   // }
               // }
             }
            return instance;
        }
        #endregion
        private AutoExperimentWin()
        {
            InitializeComponent();
        }

        #region 字段
        PeakHelper peakHelper;

        #endregion
      
        private void AutoExperimentWin_Load(object sender, EventArgs e)
        {
            peakHelper= PeakHelper.GetInstance();
        }
        private void btnStartTest_Click(object sender, EventArgs e)
        {
            select();
            this.Close();
            autoDataDisplayWin win = autoDataDisplayWin.getInstance();
            win.Show();
        }

        private void select()
        {
            #region canmsg 0x186
            TPCANMsg canmsg186 = new TPCANMsg();
            canmsg186.ID = 0x186;
            canmsg186.LEN = Convert.ToByte(8);
            canmsg186.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg186.DATA = new byte[8];
            if (chkMediumPressureLoss.Checked == true)
            {
                canmsg186.DATA[0] = 1;
            }
            else { canmsg186.DATA[0] = 0; }

            if (chkSteerValveQ.Checked == true)
            {
                canmsg186.DATA[1] = 1;
            }
            else { canmsg186.DATA[1] = 0; }

            if (chkSmallMenjiaUp.Checked == true)
            {
                canmsg186.DATA[2] = 1;
            }
           else { canmsg186.DATA[2] = 0; }

            if (chkSmallMenjiaDown.Checked == true)
            {
                canmsg186.DATA[3] = 1;
            }
            else
            {
                canmsg186.DATA[3] = 0;
            }
            if (chkBigMenjiaUp.Checked == true)
            {
                canmsg186.DATA[4] = 1;
            }
            else { canmsg186.DATA[4] = 0; }
            if (chkBigMenjiaDown.Checked == true)
            {
                canmsg186.DATA[5] = 1;
            }
            else
            {
                canmsg186.DATA[5] = 0;
            }
            if (chkSmallMenjiaForward.Checked == true)
            {
                canmsg186.DATA[6] = 1;
            }
            else
            {
                canmsg186.DATA[6] = 0;
            }
            if (chkSmallMenjiaBack.Checked == true)
            {
                canmsg186.DATA[7] = 1;
            }
            else
            {
                canmsg186.DATA[7] = 0;
            }
            #endregion


            #region 0x187
            TPCANMsg canmsg187 = new TPCANMsg();
            canmsg187.ID = 0x187;
            canmsg187.LEN = Convert.ToByte(8);
            canmsg187.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg187.DATA = new byte[8];
          
           
            if (chkBigMenjiaForward.Checked == true) { canmsg187.DATA[0] = 1; }
            else { canmsg187.DATA[0] = 0; }
            if (chkBigMenjiaBack.Checked == true) { canmsg187.DATA[1] = 1; }
            else { canmsg187.DATA[1] = 0; }
            if (chkLeakageHoldPresssure.Checked == true)
            {
                canmsg187.DATA[2] = 1;
            }
            else { canmsg187.DATA[2] = 0; }
            if (chkSmallSelfLock.Checked == true)
            {
                canmsg187.DATA[3] = 1;
            }
            else { canmsg187.DATA[3] = 0; }

            if (chkBigSelfLock.Checked == true)
            { canmsg187.DATA[4] = 1; }
            else { canmsg187.DATA[4] = 0; }
            canmsg187.DATA[5] = 1;//自动测试开始
            canmsg187.DATA[6] = 0;
            canmsg187.DATA[7] = 0;

            #endregion

            TPCANStatus sts1=  peakHelper.write(canmsg186);
            TPCANStatus sts2= peakHelper.write(canmsg187);
            if (sts1 == TPCANStatus.PCAN_ERROR_OK && sts2 == TPCANStatus.PCAN_ERROR_OK)
            {
                MessageBox.Show("实验项目选择成功，即将开始自动实验");
            } 
        }

    }
}
