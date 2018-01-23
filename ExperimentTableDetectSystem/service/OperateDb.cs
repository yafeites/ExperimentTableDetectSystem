using ExperimentTableDetectSystem.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.service
{
    public static class OperateDb
    {
       

        /// <summary>
        /// 判断表是否为空
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool IsTableNull(string sql)
        {

            DBHelper dbhelper = DBHelper.GetInstance();
            DataTable dt = dbhelper.ExecuteSqlDataAdapter(sql, null, 0);
            if (dt.Rows.Count == 0) { return true; }//是空表
            else { return false; }
        }
        /// <summary>
        /// 空列视为不可见
        /// </summary>
        /// <param name="dgv"></param>
        public static void RemoveNULL(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Rows[0].Cells[i].Value == System.DBNull.Value)
                {
                    dgv.Columns[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// 加载数据表，按时间降序排列
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="dgv">控件datagridview</param>
        public static DataTable LoadData(string sql, DataGridView dgv)
        {
            DBHelper dbhelper = DBHelper.GetInstance();
            DataTable dt = dbhelper.ExecuteSqlDataAdapter(sql, null, 0);
            DataView dv = dt.DefaultView;
            dv.Sort = "time desc";//按时间降序
            dt = dv.ToTable();
            dgv.DataSource = dt;
            OperateDb.RemoveNULL(dgv);
            dgv.AutoGenerateColumns = false;
            dgv.Invalidate();
            return dt;
        }

        public static  DataTable readTableN(string sql)
        {
            DBHelper dbhelper = DBHelper.GetInstance();
            DataTable dt = dbhelper.ExecuteSqlDataAdapter(sql, null, 0);

            return dt;
        }

    }
}
