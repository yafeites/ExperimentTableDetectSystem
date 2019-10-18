using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.util;
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
        DBHelper dbhelper;
        PeakHelper peakhelper;
        public TestFinishedWin()
        {
            InitializeComponent();
            peakhelper = PeakHelper.GetInstance();
        }
        private string valveid;
        public static int n = 1;

        private void TestFinishedWin_Load(object sender, EventArgs e)
        {
            this.valveid = ManualNumberInput.id;
            lblCon.Text = this.valveid + "已完成测试";



            TPCANMsg canmsg108 = new TPCANMsg();
            canmsg108.ID = 0x108;
            canmsg108.LEN = Convert.ToByte(8);
            canmsg108.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg108.DATA = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                canmsg108.DATA[i] = 0;
            }
            TPCANStatus sts3 = peakhelper.write(canmsg108);
            if (sts3 == TPCANStatus.PCAN_ERROR_OK)
            { /*MessageBox.Show("置0发送成功");*/ }
        }

        private void btnRetest_Click(object sender, EventArgs e)
        {
         /*   TPCANMsg canmsg183;

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
            */ 
            this.Close();
            ManualNumberInput win = ManualNumberInput.getInstance();
            win.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            RetestConfirmWin win = RetestConfirmWin.getInstance();
            win.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            dbhelper = DBHelper.GetInstance();

            string sqlstr = "select * from tbProductId where Id=" + "'" + this.valveid + "'";
            if (!OperateDb.IsTableNull(sqlstr))

            {
                DataTable dt1 = OperateDb.readTableN(sqlstr);
                n = dt1.Rows.Count;
            }

            String Sql = string.Format("select backflow as 回油流量 ,mainPumpP1 as 泵1压力, mainPumpP2 as 泵2压力 from allData where productId='{0}' and n={1} and testName='门架前倾动作检测'",this.valveid,n);
            DataTable dt = dbhelper.ExecuteSqlDataAdapter(Sql, null, 0);
            ExportToExcel.ExportDataTest(dt);
        }
    }
}
