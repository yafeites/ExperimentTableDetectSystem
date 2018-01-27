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
        public string productId;
        public int N;

        
        public HistoryDataWin()
        {
            InitializeComponent();

        }

        private void HistoryDataWin_Load(object sender, EventArgs e)
        {
            this.productId = DataSearchWin.id;
            this.N = DataSearchWin.n;
          //  string sqlstr = "select * from tbProductId where Id=" + "'" + txtValveId.Text + "'";
            string sql = string.Format("select * from valvef1 where productId="+"'"+productId+"'" +"and n={0}",N);
            try
            {
              DataTable dt= OperateDb.LoadData(sql, dgv);
                if (dt.Rows.Count == 0) { MessageBox.Show("不存在此项测试数据"); }
            }
            catch(Exception ex)
            {
                MessageBox.Show("搜素数据失败，请检查输入合适；或未进行此项测试。" + ex.Message);
            }


        }

       

        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
