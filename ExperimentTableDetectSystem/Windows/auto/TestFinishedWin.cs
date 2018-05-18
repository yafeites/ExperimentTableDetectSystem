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
            TPCANMsg canmsg183;

            canmsg183 = new TPCANMsg();
            canmsg183.ID = 0x183;
            canmsg183.LEN = Convert.ToByte(8);
            canmsg183.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg183.DATA = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                canmsg183.DATA[i] = 0;
            }
            canmsg183.DATA[0] = 50;
            canmsg183.DATA[2] = 0;
            canmsg183.DATA[3] = 0;
            canmsg183.DATA[5] = 0;
         TPCANStatus sts=   peakhelper.write(canmsg183);
            if (sts ==TPCANStatus.PCAN_ERROR_OK) { MessageBox.Show("置0发送成功"); }
            this.Close();
            ManualNumberInput win = ManualNumberInput.getInstance();
            win.Show();
        }

      
       
    }
}
