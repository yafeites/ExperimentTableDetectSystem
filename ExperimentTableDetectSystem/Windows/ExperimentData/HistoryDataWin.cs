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
    public partial class HistoryDataWin : MetroFramework.Forms.MetroForm
    {//时间列应为datetime类型
        public string strname;
        
        public HistoryDataWin()
        {
            InitializeComponent();

        }

        private void HistoryDataWin_Load(object sender, EventArgs e)
        {
            strname = CurrentDataWin.name;
            this.Text = strname + "的历史数据";
            string sql = string.Format("select * from {0}", strname);
            OperateDb.LoadData(sql, dgv);


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
