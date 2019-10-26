using ExperimentTableDetectSystem.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows.SinglePoint
{
    public partial class SinglePointDebuggingWin : MetroFramework.Forms.MetroForm
    {
        PeakHelper peakhelper;

        private void SinglePointDebuggingWin_Load(object sender, EventArgs e)
        {
            
            peakhelper.StartTimer(100);

        }

        public SinglePointDebuggingWin()
        {
            InitializeComponent();
            peakhelper = PeakHelper.GetInstance();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Fresh();
        }
        private void Fresh()
        {
            TPCANMsg canmsg109;
            canmsg109 = new TPCANMsg();
            canmsg109.ID = 0x109;
            canmsg109.LEN = Convert.ToByte(8);
            canmsg109.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg109.DATA = new byte[8];
            if (metroToggle1.Checked) { canmsg109.DATA[0] = 1; }
            else { canmsg109.DATA[0] = 0; }
            if (metroToggle5.Checked) { canmsg109.DATA[1] = 1; }
            else { canmsg109.DATA[1] = 0; }
            if (metroToggle9.Checked) { canmsg109.DATA[2] = 1; }
            else { canmsg109.DATA[2] = 0; }
            if (metroToggle13.Checked) { canmsg109.DATA[3] = 1; }
            else { canmsg109.DATA[3] = 0; }
            if (metroToggle2.Checked) { canmsg109.DATA[4] = 1; }
            else { canmsg109.DATA[4] = 0; }
            if (metroToggle6.Checked) { canmsg109.DATA[5] = 1; }
            else { canmsg109.DATA[5] = 0; }
            if (metroToggle10.Checked) { canmsg109.DATA[6] = 1; }
            else { canmsg109.DATA[6] = 0; }
            if (metroToggle14.Checked) { canmsg109.DATA[7] = 1; }
            else { canmsg109.DATA[7] = 0; }
            peakhelper.write(canmsg109);

            TPCANMsg canmsg110;
            canmsg110 = new TPCANMsg();
            canmsg110.ID = 0x110;
            canmsg110.LEN = Convert.ToByte(8);
            canmsg110.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg110.DATA = new byte[8];
            if (metroToggle18.Checked) { canmsg110.DATA[0] = 1; }
            else { canmsg110.DATA[0] = 0; }
            if (metroToggle23.Checked) { canmsg110.DATA[1] = 1; }
            else { canmsg110.DATA[1] = 0; }
            if (metroToggle3.Checked) { canmsg110.DATA[2] = 1; }
            else { canmsg110.DATA[2] = 0; }
            if (metroToggle7.Checked) { canmsg110.DATA[3] = 1; }
            else { canmsg110.DATA[3] = 0; }
            if (metroToggle11.Checked) { canmsg110.DATA[4] = 1; }
            else { canmsg110.DATA[4] = 0; }
            if (metroToggle15.Checked) { canmsg110.DATA[5] = 1; }
            else { canmsg110.DATA[5] = 0; }
            if (metroToggle19.Checked) { canmsg110.DATA[6] = 1; }
            else { canmsg110.DATA[6] = 0; }
            if (metroToggle24.Checked) { canmsg110.DATA[7] = 1; }
            else { canmsg110.DATA[7] = 0; }
            peakhelper.write(canmsg110);

          /*  TPCANMsg canmsg111;
            canmsg111 = new TPCANMsg();
            canmsg111.ID = 0x111;
            canmsg111.LEN = Convert.ToByte(8);
            canmsg111.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg111.DATA = new byte[8];
            if (metroToggle4.Checked) { canmsg111.DATA[0] = 1; }
            else { canmsg111.DATA[0] = 0; }
            if (metroToggle8.Checked) { canmsg111.DATA[1] = 1; }
            else { canmsg111.DATA[1] = 0; }
            if (metroToggle12.Checked) { canmsg111.DATA[2] = 1; }
            else { canmsg111.DATA[2] = 0; }
            if (metroToggle16.Checked) { canmsg111.DATA[3] = 1; }
            else { canmsg111.DATA[3] = 0; }
            peakhelper.write(canmsg111);*/

            TPCANMsg canmsg106;
            canmsg106 = new TPCANMsg();
            canmsg106.ID = 0x106;
            canmsg106.LEN = Convert.ToByte(8);
            canmsg106.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg106.DATA= new byte[8];
            if (metroToggle8.Checked) { canmsg106.DATA[0] = 1; }
            else { canmsg106.DATA[0] = 0; }
            if (metroToggle12.Checked) { canmsg106.DATA[1] = 1; }
            else { canmsg106.DATA[1] = 0; }
            if (metroToggle16.Checked) { canmsg106.DATA[2] = 1; }
            else { canmsg106.DATA[2] = 0; }
            if (metroToggle4.Checked) { canmsg106.DATA[3] = 1; }
            else { canmsg106.DATA[3] = 0; }
           // if (metroToggle17.Checked) { canmsg203.DATA[4] = 1; }
            //else { canmsg203.DATA[4] = 0; }
          //  if (metroToggle22.Checked) { canmsg203.DATA[5] = 1; }
           // else { canmsg203.DATA[5] = 0; }
            peakhelper.write(canmsg106);

            TPCANMsg canmsg203;
            canmsg203 = new TPCANMsg();
            canmsg203.ID = 0x203;
            canmsg203.LEN = Convert.ToByte(8);
            canmsg203.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg203.DATA = new byte[8];
            if (metroToggle27.Checked) { canmsg203.DATA[0] = 1; }
            else { canmsg203.DATA[0] = 0; }
            if (metroToggle28.Checked) { canmsg203.DATA[1] = 1; }
            else { canmsg203.DATA[1] = 0; }
            if (metroToggle29.Checked) { canmsg203.DATA[2] = 1; }
            else { canmsg203.DATA[2] = 0; }
            if (metroToggle30.Checked) { canmsg203.DATA[3] = 1; }
            else { canmsg203.DATA[3] = 0; }
            if (metroToggle17.Checked) { canmsg203.DATA[4] = 1; }
            else { canmsg203.DATA[4] = 0; }
            if (metroToggle20.Checked) { canmsg203.DATA[5] = 1; }
            else { canmsg203.DATA[5] = 0; }
            if (metroToggle21.Checked) { canmsg203.DATA[6] = 1; }
            else { canmsg203.DATA[6] = 0; }
            peakhelper.write(canmsg203);

            //数据显示部分
            double[] singledata = new double[73];
            for (int i = 0; i < 73; i++)
            {
                singledata[i] = peakhelper.AllValue[i];
            }
            txttankTemp.Text = singledata[44].ToString();
            txtpump1OutTemp.Text = singledata[45].ToString();
            txt_backfow.Text = singledata[41].ToString();
            txtpump2OutTemp.Text = singledata[46].ToString();

            txtmainPumpP1.Text = singledata[10].ToString();
            txtMainPumpP2.Text = singledata[11].ToString();
            txtpumpFlow1.Text = singledata[36].ToString();
            txtPumpFlow2.Text = singledata[37].ToString();
            txtSteerPressure.Text = singledata[12].ToString();
            txtsteeringFlow.Text = singledata[38].ToString();
            if (singledata[39] != 0)
            {
                txtLeakageFlow.Text = singledata[39].ToString();
            }
            
            txtSystemBackPressure.Text = singledata[15].ToString();
            txtMediumPressureLoss.Text = singledata[19].ToString();
            txtpilotPressure.Text = singledata[35].ToString();
            txtOilPressure.Text = singledata[16].ToString();
            txtoilInPressure.Text = singledata[17].ToString();
            txtoilOutPressure.Text = singledata[18].ToString();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            TPCANMsg canmsg108;
            canmsg108 = new TPCANMsg();
            canmsg108.ID = 0x108;
            canmsg108.LEN = Convert.ToByte(8);
            canmsg108.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            canmsg108.DATA = new byte[8];
            canmsg108.DATA[6] = 0;
            try
            {
                TPCANStatus res1 = peakhelper.write(canmsg108);
                if (res1 == TPCANStatus.PCAN_ERROR_OK)
                {
                    MessageBox.Show("成功退出单点模式");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("退出单点模式失败" + ex.Message);
            }
            this.Close();
        }

        private void metroLabel60_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel41_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel44_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel17_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel_backflow_Click(object sender, EventArgs e)
        {

        }

        private void txtpump1OutTemp_Click(object sender, EventArgs e)
        {

        }
    }
}
