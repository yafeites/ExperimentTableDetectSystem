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
        public void loadData(string sql,DataGridView dgv)
        {
            dbhelper = DBHelper.GetInstance();
            DataTable dt = dbhelper.ExecuteSqlDataAdapter(sql, null, 0);
            adjustDgv(dt, dgv);
        }
        public void adjustDgv(DataTable dt,DataGridView dataGridView1)
        {
            dataGridView1.DataSource = dt;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//标题居中
        }

        public void SearchM1(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,P1 as 主泵1压力,Q1 as 主泵1流量,P2 as 主泵2压力,Q2 as 主泵2流量,time as 时间 from valveM1 where productId='{0}' and n={1}", id, n);
            loadData(sql, dgv);

        }
        public void SearchM2(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,P1 as 主泵1压力,Q1 as 主泵1流量,P2 as 主泵2压力,Q2 as 主泵2流量,P as 转向压力,time as 时间 from valveM2 where productId='{0}' and n={1}", id, n);
            loadData(sql, dgv);
        }

        public void Searchf1(string id,int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,P1 as 主泵1压力,Q1 as 主泵1流量,P2 as 主泵2压力, Q2 as 主泵2流量 ,p3 as 转向压力,q3 as 转向流量,v1 as 升降阀,v2 as 倾斜阀 ,time as 时间 from valvef1 where productId='{0}' and n={1}",id, n);
            loadData(sql, dgv);
        }
        public void  Searchf2(string id ,int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,p as 主泵压力,q as 主泵流量,Pi as 油缸压力,[P-Pi] as 压力损失,S as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef2 where productId='{0}' and n={1}", id, n);
            loadData(sql, dgv);
        }
        public void Searchf3(string id, int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,p as 主泵压力,q as 主泵流量,Pi as 油缸压力,Pb as 系统背压,P-Pi as 压力损失,S as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef3 where productId='{0}' and n={1}", id, n);
            loadData(sql, dgv);
        }
       public void Searchf4(string id,int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,p1 as 主泵1压力,q1 as 主泵1流量,p2 as 主泵2压力,q2 as 主泵2流量,Pi as 油缸压力,p3 as 压力损失,S as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef4 where productId='{0}' and n={1}", id, n);
            loadData(sql, dgv);
        }
        public void Searchf5(string id,int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,p1 as 主泵1压力,q1 as 主泵1流量,p2 as 主泵2压力,q2 as 主泵2流量,Pi as 油缸压力,Pb as 系统背压,Pi-Pb as 压力损失,S as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef5 where productId='{0}' and n={1}", id, n);
            loadData(sql, dgv);
        }
        public void Searchf6(string id,int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,p as 主泵压力,q as 主泵流量,pi as 油缸进油压力,Po as 油缸回油压力,Pb as 系统背压,P-Pi as 进油压力损失,Po-Pb as 回油压力损失,s as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef6 where productId='{0}' and n={1}", id, n);
            loadData(sql, dgv);
        }
        public void Searchf7(string id,int n,DataGridView dgv)
        {

            string sql = string.Format("select productId as 编号,n as 次数,p as 主泵压力,q as 主泵流量,pi as 油缸进油压力,Po as 油缸回油压力,Pb as 系统背压,P-Pi as 进油压力损失,Po-Pb as 回油压力损失,s as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef7 where productId='{0}' and n={1}", id, n);
            loadData(sql, dgv);
        }
        public void Searchf8(string id,int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,p1 as 主泵1压力,q1 as 主泵1流量,p2 as 主泵2压力,q2 as 主泵2流量,pi as 油缸进油压力,Po as 油缸回油压力,Pb as 系统背压,[P-Pi] as 进油压力损失,Po-Pb as 回油压力损失,s as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef8 where productId='{0}' and n={1}", id, n);
            loadData(sql, dgv);
        }
        public void Searchf9(string id,int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,p1 as 主泵1压力,q1 as 主泵1流量,p2 as 主泵2压力,q2 as 主泵2流量,pi as 油缸进油压力,Po as 油缸回油压力,Pb as 系统背压,[P-Pi] as 进油压力损失,Po-Pb as 回油压力损失,s as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef9 where productId='{0}' and n={1}", id, n);
            loadData(sql, dgv);
        }
        public void Searchf10(string id,int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,p1 as 主泵1压力,q1 as 主泵1流量,p2 as 主泵2压力,q2 as 主泵2流量,Pb as 系统背压,q3 as 泄露流量,time as 时间 from valvef10 where productId='{0}' and n={1}", id, n);
            loadData(sql, dgv);
        }
        public void Searchf11(string id,int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,p1 as 主泵1压力,q1 as 主泵1流量,p2 as 主泵2压力,q2 as 主泵2流量,Pb as 系统背压,P3 as 中位压力损失,time as 时间 from valvef11 where productId='{0}' and n={1}", id, n);
            loadData(sql, dgv);
        }
        public void Searchf12(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,p1 as 供油压力,q2 as 供油流量,p2 as 升降阀压力,pa as 倾斜阀A口压力,Pb as 倾斜阀B口压力,Q3 as 泄露流量,time as 时间 from valvef12 where productId='{0}' and n={1}", id, n);
            loadData(sql, dgv);
        }
    }
}
