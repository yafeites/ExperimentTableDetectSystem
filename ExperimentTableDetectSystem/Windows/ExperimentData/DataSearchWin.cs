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
        public static int n;
        public static int test;

       

        public DataSearchWin()
        {
            InitializeComponent();
        }

       

        private void btnSearch_Click(object sender, EventArgs e)
        {
             id= txtId.Text;//编号
             n= lstN.SelectedIndex+1;//测试次数
             test = lstSelection.SelectedIndex+1;//试验项目
                                                   //textBox1.Text = n.ToString();
                                                  //textBox2.Text = test.ToString();
         
          HistoryDataWin win = new HistoryDataWin();
           win.Show();
        }

    }
}
