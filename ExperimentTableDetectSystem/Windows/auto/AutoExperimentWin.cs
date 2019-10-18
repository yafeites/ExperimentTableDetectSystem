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

        }

        private void select()
        {

            #region 0x108
            TPCANMsg canmsg108 = new TPCANMsg();
            canmsg108.ID = 0x108;
            canmsg108.LEN = Convert.ToByte(8);
            canmsg108.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg108.DATA = new byte[8];
            canmsg108.DATA[2] = 1; //自动实验开始
            #endregion


            #region 0x101
            TPCANMsg canmsg101 = new TPCANMsg();
            canmsg101.ID = 0x101;
            canmsg101.LEN = Convert.ToByte(8);
            canmsg101.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg101.DATA = new byte[8];
            if (chkMediumPressureLoss.Checked == true)
            {
                canmsg101.DATA[0] = 1;
            }
            else { canmsg101.DATA[0] = 0; }

            if (chkMenjiaUp.Checked == true)
            {
                canmsg101.DATA[1] = 1;
            }
            else { canmsg101.DATA[1] = 0; }
            if (chkMenjiaBack.Checked == true)
            {
 
                 canmsg101.DATA[2] = 1;
            }
            else { canmsg101.DATA[2] = 0; }
            if (chkMenjiaForward.Checked == true)
            {
                canmsg101.DATA[3] = 1;
            }
            else { canmsg101.DATA[3] = 0; }

            if (chkMenjiaForwardTest.Checked == true)
            {
                canmsg101.DATA[4] = 1;
            }
            else
            {
                canmsg101.DATA[4] = 0;
            }
            if (chkSelfLock.Checked == true)
            {
                canmsg101.DATA[5] = 1;
            }
            else { canmsg101.DATA[5] = 0; }
            if (chkLeakageHoldPresssure.Checked == true)
            {
                canmsg101.DATA[6] = 1;
            }
            else { canmsg101.DATA[6] = 0; }
            if (chkMenjiaDown.Checked == true)
            {
                canmsg101.DATA[7] = 1;
            }
            else { canmsg101.DATA[7] = 0; }

            #endregion


            TPCANStatus sts4 = peakHelper.write(canmsg101);
            TPCANStatus sts3 = peakHelper.write(canmsg108);

            if (sts3 == TPCANStatus.PCAN_ERROR_OK && sts4 == TPCANStatus.PCAN_ERROR_OK)
            {

                this.Close();
                autoDataDisplayWin win = autoDataDisplayWin.getInstance();
                win.Show();
                //MessageBox.Show("实验项目选择成功，即将开始自动实验");
            } 
        }

        private void chkMenjia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMenjia.Checked == false)
            {
                chkMenjiaBack.Checked = chkMenjiaDown.Checked = chkMenjiaForward.Checked = chkMenjiaForwardTest.Checked = chkMenjiaUp.Checked = chkSelfLock.Checked = false;
            }
            if (chkMenjia.Checked == true)
            {
                chkMenjiaBack.Checked = chkMenjiaDown.Checked = chkMenjiaForward.Checked = chkMenjiaForwardTest.Checked = chkMenjiaUp.Checked = chkSelfLock.Checked = true;
            }
        }
    }
}
