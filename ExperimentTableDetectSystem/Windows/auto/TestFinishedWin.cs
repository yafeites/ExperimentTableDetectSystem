using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.Windows.manual;
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
    public partial class TestFinishedWin : MetroFramework.Forms.MetroForm
    {
        PeakHelper peakhelper;
        public TestFinishedWin()
        {
            InitializeComponent();
            peakhelper = PeakHelper.GetInstance();
        }
        private string valveid;

        private void TestFinishedWin_Load(object sender, EventArgs e)
        {
            this.valveid = ManualNumberInput.id;
            lblCon.Text = this.valveid + "已完成测试";
        }

        private void btnRetest_Click(object sender, EventArgs e)
        {
            TPCANMsg canmsg283;

            canmsg283 = new TPCANMsg();
            canmsg283.ID = 0x283;
            canmsg283.LEN = Convert.ToByte(8);
            canmsg283.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg283.DATA = new byte[8];
            canmsg283.DATA[0] = 1;
            for (int i = 1; i < 8; i++)
            {
                canmsg283.DATA[i] = 1;
            }
            peakhelper.write(canmsg283);
            this.Close();
            ManualNumberInput win = ManualNumberInput.getInstance();
            win.Show();
        }

      
       
    }
}
