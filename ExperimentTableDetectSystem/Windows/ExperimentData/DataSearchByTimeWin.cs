using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows.ExperimentData
{
    public partial class DataSearchByTimeWin : MetroFramework.Forms.MetroForm
    {
        public static string startTime;
        public static string endTime;

        public DataSearchByTimeWin()
        {
            InitializeComponent();
        }

        private static string ConvertToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        private void DataSearchByTimeWin_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            startTime = txtStart.Text;//起始时间
            endTime = txtEnd.Text;//终止时间

            this.Close();
            ValveListWin win = new ValveListWin();
            win.Show();
        }
    }
}
