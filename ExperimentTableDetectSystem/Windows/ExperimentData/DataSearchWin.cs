using ExperimentTableDetectSystem.service;
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
    public partial class DataSearchWin : MetroFramework.Forms.MetroForm
    {

        public static string id;
        public static string startTime;
        public static string endTime;
        public static string date;
        public static int n;
        public static int test;



        public DataSearchWin()
        {
            InitializeComponent();
        }

        private static string ConvertToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

      //  private void btnSearch_Click(object sender, EventArgs e)
       // {
          /*  if (txtDate.Text == "")
            {
                date = ConvertToString(DateTime.Now);
            }
            else
            {
                date = txtDate.Text;//日期
            }
            if (txtStart.Text == "")
            {
                startTime = "00:00:01";
            }
            else
            {
                startTime = txtStart.Text;//起始时间
            }
            if (txtEnd.Text == "")
            {
                endTime = "23:59:59";
            }
            else
            {
                endTime = txtEnd.Text;//终止时间
            }*/
        //    id = txtId.Text;//编号
       //     n = lstN.SelectedIndex + 1;//测试次数
          //  test = lstSelection.SelectedIndex + 1;//试验项目
                                                  //textBox1.Text = n.ToString();
                                                  //textBox2.Text = test.ToString();

         //   HistoryDataWin win = new HistoryDataWin();
         //   win.Show();
     //   }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            id = txtId.Text;//编号
            n = lstN.SelectedIndex + 1;//测试次数
                                       //  test = lstSelection.SelectedIndex + 1;//试验项目
                                       //textBox1.Text = n.ToString();
                                       //textBox2.Text = test.ToString();

            this.Close();
            HistoryDataWin win = new HistoryDataWin();
            win.Show();
        }
    }
}

