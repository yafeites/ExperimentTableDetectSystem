using ExperimentTableDetectSystem.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.service
{
   public  class SearchHelper

    {
        DBHelper dbhelper;
        #region 单例
        private static volatile SearchHelper instance;
        private SearchHelper()
        {

        }
        private static object syncRoot = new Object();
        public static SearchHelper GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new SearchHelper();
                    }
                }
            }
            return instance;
        }
        #endregion
        public void adjustDgv(DataTable dt,DataGridView dataGridView1)
        {
            dataGridView1.DataSource = dt;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//标题居中
        }
        public void Searchf1(string id,int n,DataGridView dataGridView1)
        {
            string sql = string.Format("select productId as 编号,n as 次数,P1 as 主泵1压力,Q1 as 主泵1流量,P2 as 主泵2压力, Q2 as 主泵2流量 ,p3 as 转向压力,q3 as 转向流量,v1 as 升降阀,v2 as 倾斜阀 ,time as 时间 from valvef1 where productId='{0}' and n={1}",id, n);
            dbhelper = DBHelper.GetInstance();
            DataTable dt = dbhelper.ExecuteSqlDataAdapter(sql, null, 0);
            adjustDgv(dt, dataGridView1);
        }
        public void  Searchf2(string sql,DataGridView dgv)
        {
            dbhelper = DBHelper.GetInstance();
            DataTable dt = dbhelper.ExecuteSqlDataAdapter(sql, null, 0);
            adjustDgv(dt, dgv);
        }

    }
}
