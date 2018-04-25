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

        #region 查询数据库
        /// <summary>
        /// 主溢流阀调定试验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchM1(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,ai1 as 主泵1压力,pump1flow as 主泵1流量,ai2 as 主泵2压力,pump2flow as 主泵2流量 from allData where productId='{0}' and n={1} and testName='主溢流阀调定试验'", id, n);
            loadData(sql, dgv);

        }
        /// <summary>
        /// 转向溢流阀调定试验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchM2(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("  select productId as 编号,n as 次数,ai1 as 主泵1压力,testName as 测试项目,pump1flow as 主泵1流量,ai2 as 主泵2压力,pump2flow as 主泵2流量,ai3 as 转向压力 from allData where productId='{0}' and n={1} and testName='转向溢流阀调定试验'", id, n);
            loadData(sql, dgv);
        }


        /// <summary>
        /// 中位压力损失
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf1(string id,int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,ai1 as 主泵1压力,pump1flow as 主泵1流量,ai2 as 主泵2压力,pump2flow as 主泵2流量,systembackPressure as 系统背压,ai4 as 中位压力损失 from allData where productId='{0}' and n={1} and testName='中位压力损失试验'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 转向优先阀流量测试
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void  Searchf2(string id ,int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,ai1 as 主泵1压力,pump1flow as 主泵1流量,ai2 as 主泵2压力,pump2flow as 主泵2流量,ai3 as 转向压力,steerflow as 转向流量 from allData where productId='{0}' and n={1} and testName='转向优先阀流量试验'", id, n);
            loadData(sql, dgv);
        }

        /// <summary>
        /// 内泄漏测试？？？？？？？？？
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf3(string id, int n,DataGridView dgv)
        {//内泄漏测试
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,p as 主泵压力,q as 主泵流量,Pi as 油缸压力,Pb as 系统背压,P-Pi as 压力损失,S as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef3 where productId='{0}' and n={1}and testName='内泄漏试验'", id, n);
            loadData(sql, dgv);
        }


        /// <summary>
        /// 小门架上升
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
       public void Searchf4(string id,int n,DataGridView dgv)
        {//小上升
            string sql = string.Format(" select productId as 编号,n as 次数,testName as 测试项目,ai1 as 主泵1压力,pump1flow as 主泵1流量,cylinderPressure as 油缸压力,ai7 as 压力损失,ai5 as 油缸位移, ai6 as 油缸速度,pushvalvef1  as 推动滑阀力,pushvalveTime1 as 推动滑阀时间,ai3 as 转向压力,steerflow as 转向流量 from allData where productId='{0}' and n={1} and testName='小门架上升'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 小门架下降
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf5(string id,int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,ai1 as 主泵1压力,pump1flow as 主泵1流量,cylinderPressure as 油缸压力,systembackpressure as 系统背压, ai10 as 压力损失,ai8 as 油缸位移, ai9 as 油缸速度,pushvalvef1  as 推动滑阀力,pushvalveTime2 as 推动滑阀时间,ai3 as 转向压力,steerflow as 转向流量 from allData  where productId='{0}' and n={1} and testName='小门架下降'", id, n);
            loadData(sql, dgv);
        }
         /// <summary>
/// 大门架上升
/// </summary>
/// <param name="id"></param>
/// <param name="n"></param>
/// <param name="dgv"></param>
        public void Searchf6(string id,int n,DataGridView dgv)
        {
            string sql = string.Format("  select productId as 编号,n as 次数,testName as 测试项目,ai1 as 主泵1压力,pump1flow as 主泵1流量,ai2 as 主泵2压力,pump2flow as 主泵2流量,cylinderPressure as 油缸压力,ai13 as 压力损失,ai11 as 油缸位移, ai12 as 油缸速度,pushvalvef2  as 推动滑阀力,pushvalveTime3 as 推动滑阀时间,ai3 as 转向压力,steerflow as 转向流量 from allData where productId='{0}' and n={1} and testName='大门架上升'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 大门架下降
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf7(string id,int n,DataGridView dgv)
        {

            string sql = string.Format(" select productId as 编号,n as 次数,testName as 测试项目,ai1 as 主泵1压力,pump1flow as 主泵1流量,ai2 as 主泵2压力,pump2flow as 主泵2流量,cylinderPressure as 油缸压力,systembackpressure as 系统背压, ai16 as 压力损失,ai14 as 油缸位移, ai15 as 油缸速度,pushvalvef2  as 推动滑阀力,pushvalveTime4 as 推动滑阀时间,ai3 as 转向压力,steerflow as 转向流量 from allData where productId='{0}' and n={1} and testName='大门架下降'", id, n);
            loadData(sql, dgv);
        }


        /// <summary>
        /// 小门架前倾
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf8(string id,int n,DataGridView dgv)
        {
            string sql = string.Format(" select productId as 编号,n as 次数,testName as 测试项目,ai1 as 主泵1压力,pump1flow as 主泵1流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,ai19 as 进油压力损失,ai20 as 回油压力损失,  ai17 as 油缸位移, ai18 as 油缸速度,pushvalvef1  as 推动滑阀力,pushvalveTime5 as 推动滑阀时间,ai3 as 转向压力,steerflow as 转向流量 from allData where productId='{0}' and n={1} and testName='小门架前倾'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 小门架后倾
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf9(string id,int n,DataGridView dgv)
        {
            string sql = string.Format(" select productId as 编号,n as 次数,testName as 测试项目,ai1 as 主泵1压力,pump1flow as 主泵1流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,ai23 as 进油压力损失,ai24 as 回油压力损失,  ai21 as 油缸位移, ai22 as 油缸速度,pushvalvef1  as 推动滑阀力,pushvalveTime6 as 推动滑阀时间,ai3 as 转向压力,steerflow as 转向流量 from allData where productId='{0}' and n={1} and testName='小门架后倾'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 大门架前倾
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf10(string id,int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,ai1 as 主泵1压力,pump1flow as 主泵1流量,ai2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,ai27 as 进油压力损失,ai28 as 回油压力损失,  ai25 as 油缸位移, ai26 as 油缸速度,pushvalvef1  as 推动滑阀力,pushvalveTime7 as 推动滑阀时间,ai3 as 转向压力,steerflow as 转向流量 from allData where productId='{0}' and n={1} and testName='大门架前倾'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 大门架后倾
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf11(string id,int n,DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,ai1 as 主泵1压力,pump1flow as 主泵1流量,ai2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,ai31 as 进油压力损失,ai32 as 回油压力损失,  ai29 as 油缸位移, ai30 as 油缸速度,pushvalvef1  as 推动滑阀力,pushvalveTime8 as 推动滑阀时间,ai3 as 转向压力,steerflow as 转向流量 from allData where productId='{0}' and n={1} and testName='大门架后倾'", id, n);
            loadData(sql, dgv);
        }

        /// <summary>
        /// 小门架前倾自锁
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf12(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,ai1 as 主泵1压力,pump1flow as 主泵1流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,ai19 as 进油压力损失,ai20 as 回油压力损失,  ai17 as 油缸位移, ai18 as 油缸速度,pushvalvef1  as 推动滑阀力,pushvalveTime5 as 推动滑阀时间,ai3 as 转向压力,steerflow as 转向流量 from allData where productId='{0}' and n={1} and testName='小门架前倾自锁'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 大门架前倾自锁
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf13(string id,int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,ai1 as 主泵1压力,pump1flow as 主泵1流量,ai2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,ai27 as 进油压力损失,ai28 as 回油压力损失,  ai25 as 油缸位移, ai26 as 油缸速度,pushvalvef1  as 推动滑阀力,pushvalveTime7 as 推动滑阀时间,ai3 as 转向压力,steerflow as 转向流量 from allData where productId='{0}' and n={1} and testName='大门架前倾自锁'", id, n);
            loadData(sql, dgv);
        }
        #endregion
        #region 副本
        //public void SearchM1(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,P1 as 主泵1压力,Q1 as 主泵1流量,P2 as 主泵2压力,Q2 as 主泵2流量,time as 时间 from valveM1 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);

        //}
        //public void SearchM2(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,P1 as 主泵1压力,Q1 as 主泵1流量,P2 as 主泵2压力,Q2 as 主泵2流量,P as 转向压力,time as 时间 from valveM2 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}

        //public void Searchf1(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,P1 as 主泵1压力,Q1 as 主泵1流量,P2 as 主泵2压力, Q2 as 主泵2流量 ,p3 as 转向压力,q3 as 转向流量,v1 as 升降阀,v2 as 倾斜阀 ,time as 时间 from valvef1 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        //public void Searchf2(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,p as 主泵压力,q as 主泵流量,Pi as 油缸压力,[P-Pi] as 压力损失,S as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef2 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        //public void Searchf3(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,p as 主泵压力,q as 主泵流量,Pi as 油缸压力,Pb as 系统背压,P-Pi as 压力损失,S as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef3 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        //public void Searchf4(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,p1 as 主泵1压力,q1 as 主泵1流量,p2 as 主泵2压力,q2 as 主泵2流量,Pi as 油缸压力,p3 as 压力损失,S as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef4 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        //public void Searchf5(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,p1 as 主泵1压力,q1 as 主泵1流量,p2 as 主泵2压力,q2 as 主泵2流量,Pi as 油缸压力,Pb as 系统背压,Pi-Pb as 压力损失,S as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef5 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        //public void Searchf6(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,p as 主泵压力,q as 主泵流量,pi as 油缸进油压力,Po as 油缸回油压力,Pb as 系统背压,P-Pi as 进油压力损失,Po-Pb as 回油压力损失,s as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef6 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        //public void Searchf7(string id, int n, DataGridView dgv)
        //{

        //    string sql = string.Format("select productId as 编号,n as 次数,p as 主泵压力,q as 主泵流量,pi as 油缸进油压力,Po as 油缸回油压力,Pb as 系统背压,P-Pi as 进油压力损失,Po-Pb as 回油压力损失,s as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef7 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        //public void Searchf8(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,p1 as 主泵1压力,q1 as 主泵1流量,p2 as 主泵2压力,q2 as 主泵2流量,pi as 油缸进油压力,Po as 油缸回油压力,Pb as 系统背压,[P-Pi] as 进油压力损失,Po-Pb as 回油压力损失,s as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef8 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        //public void Searchf9(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,p1 as 主泵1压力,q1 as 主泵1流量,p2 as 主泵2压力,q2 as 主泵2流量,pi as 油缸进油压力,Po as 油缸回油压力,Pb as 系统背压,[P-Pi] as 进油压力损失,Po-Pb as 回油压力损失,s as 油缸位移,v as 油缸速度,f as 推动滑阀力,t as 推动滑阀时间,time as 时间 from valvef9 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        //public void Searchf10(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,p1 as 主泵1压力,q1 as 主泵1流量,p2 as 主泵2压力,q2 as 主泵2流量,Pb as 系统背压,q3 as 泄露流量,time as 时间 from valvef10 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        //public void Searchf11(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,p1 as 主泵1压力,q1 as 主泵1流量,p2 as 主泵2压力,q2 as 主泵2流量,Pb as 系统背压,P3 as 中位压力损失,time as 时间 from valvef11 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        //public void Searchf12(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,p1 as 供油压力,q2 as 供油流量,p2 as 升降阀压力,pa as 倾斜阀A口压力,Pb as 倾斜阀B口压力,Q3 as 泄露流量,time as 时间 from valvef12 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        #endregion
    }
}
