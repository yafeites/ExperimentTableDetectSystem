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

namespace ExperimentTableDetectSystem.Windows
{
    public partial class MainWin : MetroFramework.Forms.MetroForm
    {
        private UserRightManager rightManager;
        private string userName;
        public MainWin()
        {
            InitializeComponent();
            rightManager = UserRightManager.GetInstance();
            userName = UserRightManager.user.userName;

        }
        /// <summary>
        /// 手工试验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManualExperiment_Click(object sender, EventArgs e)
        {
            ManualNumberInput win = ManualNumberInput.getInstance();
            win.Show();
        }
        /// <summary>
        /// 自动试验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoExperiment_Click(object sender, EventArgs e)
        {
            AutoExperimentWin win = AutoExperimentWin.getInstance();
            win.Show();
        }
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
            DataSearchWin win = new DataSearchWin();
            win.Show();
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            try { DataStoreManager.Initialize(); }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "数据保存类初始化错误。");
            }
        }
    }
}
