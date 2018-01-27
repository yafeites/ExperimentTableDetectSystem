using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.util;
using ExperimentTableDetectSystem.Windows.ExperimentData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem
{
    public partial class testWin : Form
    {
        public string productId;
        public int N;
        DBHelper dbhelper;
        public testWin()
        {
            InitializeComponent();
        }

        private void testWin_Load(object sender, EventArgs e)
        {
           // dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.productId = DataSearchWin.id;
            this.N = DataSearchWin.n;
            //  string sql = string.Format("select * from valvef1 where productId=" + "'" + productId + "'" + "and n={0}", N);
            string sql = string.Format("select productId as 编号,n as 次数,P1 as 主泵1压力,Q1 as 主泵1流量,P2 as 主泵2压力, Q2 as 主泵2流量 ,p3 as 转向压力,q3 as 转向流量,v1 as 升降阀,v2 as 倾斜阀 ,time as 时间 from valvef1 where productId='{0}' and n={1}",productId,N);
            dbhelper = DBHelper.GetInstance();
            DataTable dt = dbhelper.ExecuteSqlDataAdapter(sql, null, 0);
            dataGridView1.DataSource = dt;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//标题居中
            //            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            //{
            //                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //            }
           
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

       
    }
}
