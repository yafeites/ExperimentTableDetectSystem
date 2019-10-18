using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.Windows.manual;
using ExperimentTableDetectSystem.Windows.setParameterWin;
using ExperimentTableDetectSystem.Windows.UserWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExperimentTableDetectSystem.entity;
using ExperimentTableDetectSystem.Windows.ExperimentData;
using ExperimentTableDetectSystem.Windows.SinglePoint;

namespace ExperimentTableDetectSystem.Windows
{
    public partial class MainWin : MetroFramework.Forms.MetroForm
    {
        PeakHelper peakHelperer;
        private UserRightManager rightManager;
        private string userName;
        public MainWin()
        {
            InitializeComponent();
            rightManager = UserRightManager.GetInstance();
            userName = UserRightManager.user.userName;
            peakHelperer = PeakHelper.GetInstance();

        }
        /// <summary>
        /// 手工试验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*
        private void btnManualExperiment_Click(object sender, EventArgs e)
        {
            ManualNumberInput win = ManualNumberInput.getInstance();
            win.Show();
           // btnManualExperiment.Enabled = false;
            btnAutoExperiment.Enabled = true;
        }
        */

        /// <summary>
        /// 自动试验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       /* private void btnAutoExperiment_Click(object sender, EventArgs e)
        {
            btnManualExperiment.Enabled = true;
          //  btnAutoExperiment.Enabled = false;
            AutoExperimentWin win = AutoExperimentWin.getInstance();
            win.Show();
        }
        */
        /// <summary>
        /// 参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetParameter_Click(object sender, EventArgs e)
        {
            if (!rightManager.CanDoThis(UserRightConstraint.RingParameterSetLeastLevel))
            {
                new UserPrivilegeException();
            }
            else
            {
                SetParameterWin win = SetParameterWin.getInstance();
                win.Show();
            }
        }
        /// <summary>
        /// 系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserSet_Click(object sender, EventArgs e)
        {
            if (!rightManager.CanDoThis(UserRightConstraint.SystemSetLeastLevel))
            {
                new UserPrivilegeException();
            }
            else
            {
                UserRightWin win = UserRightWin.getInstance();
                win.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定退出吗？ ",
                                   " 提示",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
               
                System.Environment.Exit(0);
            }
        }

        private void btnCurrentData_Click(object sender, EventArgs e)
        {
            if(!rightManager.CanDoThis(UserRightConstraint.RecordCheckAndExportLeastLevel))
            {
                new UserPrivilegeException();
            }
            else
            {

                DataSearchWin win = new DataSearchWin();
                win.Show();
            }

        }


        private void MainWin_Load(object sender, EventArgs e)
        {
            // peakhelper = PeakHelper.GetInstance();
            peakHelperer.StartTimer(100);

            try
            {
                DataStoreManager.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "数据保存类初始化错误。");
            }


        }
        /// <summary>
        /// 实验参数设置，发给plc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnexpPara_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 报警参数设置 存数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWarningPara_Click(object sender, EventArgs e)
        {
            if (!rightManager.CanDoThis(UserRightConstraint.RingParameterSetLeastLevel))
            {
                new UserPrivilegeException();
            }
            else
            {
                SetParameterWin win = SetParameterWin.getInstance();
                win.Show();
            }
        }

        private void btnByDate_Click(object sender, EventArgs e)
        {
            if (!rightManager.CanDoThis(UserRightConstraint.RecordCheckAndExportLeastLevel))
            {
                new UserPrivilegeException();
            }
            else
            {
                DataSearchByTimeWin win = new DataSearchByTimeWin();
                win.Show();
            }

        }

        private void btnSinglePoint_Click(object sender, EventArgs e)
        {
            TPCANMsg canmsg108;
            canmsg108 = new TPCANMsg();
            canmsg108.ID = 0x108;
            canmsg108.LEN = Convert.ToByte(8);
            canmsg108.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg108.DATA = new byte[8];
            canmsg108.DATA[6] = 1;
            try
            {
                TPCANStatus res1 = peakHelperer.write(canmsg108);
                if (res1 == TPCANStatus.PCAN_ERROR_OK)
                {
                    MessageBox.Show("进入单点模式");
                    SinglePointDebuggingWin win = new SinglePointDebuggingWin();
                    win.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("进入单点模式失败" + ex.Message);
            }
           
        }

        private void btnExperiment_Click(object sender, EventArgs e)
        {
           // ManualExperimentWin win = ManualExperimentWin.getInstance();

            ManualNumberInput win = ManualNumberInput.getInstance();
            win.Show();
            // btnManualExperiment.Enabled = false;
            //btnAutoExperiment.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTempNow.Text = peakHelperer.AllValue[44].ToString()+"摄氏度";
        }
    }
}
