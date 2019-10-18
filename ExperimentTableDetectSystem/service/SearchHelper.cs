using ExperimentTableDetectSystem.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.service
{
    public class SearchHelper

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
        public void loadData(string sql, DataGridView dgv)
        {
            dbhelper = DBHelper.GetInstance();
            DataTable dt = dbhelper.ExecuteSqlDataAdapter(sql, null, 0);
            adjustDgv(dt, dgv);
        }
        public void adjustDgv(DataTable dt, DataGridView dataGridView1)
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
        public  void SearchM1(string id, int n,  DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='主溢流阀调定试验'", id, n);
            loadData(sql, dgv);
           // return sql;
        }
        /// <summary>
        /// 转向溢流阀调定试验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchM2(string id, int n,  DataGridView dgv)
        {
            string sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,steerPressure as 转向压力,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='转向溢流阀调定试验'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 过载阀A1口阀调定试验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchOverloadA(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='过载阀A1口调定试验'", id, n);
            loadData(sql, dgv);
            // return sql;
        }
        /// <summary>
        /// 过载阀B1口阀调定试验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchOverloadB(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='过载阀B1口调定试验'", id, n);
            loadData(sql, dgv);
            // return sql;
        }

        /// <summary>
        /// 过载阀A2口阀调定试验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchOverloadA2(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='过载阀A2口调定试验'", id, n);
            loadData(sql, dgv);
            // return sql;
        }
        /// <summary>
        /// 过载阀B2口阀调定试验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchOverloadB2(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='过载阀B2口调定试验'", id, n);
            loadData(sql, dgv);
            // return sql;
        }

        /// <summary>
        /// 换向泄漏上升口试验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchM3(string id, int n,  DataGridView dgv)
        {
            string sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏上升口试验'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 换向泄漏前倾口试验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchM3A(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏前倾口试验'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 换向泄漏后倾口试验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchM3B(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏后倾口试验'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 换向泄漏备用1口试验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchM31(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏备用1口试验'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 换向泄漏备用2口试验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchM32(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏备用2口试验'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 换向泄漏备用3口试验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchM33(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏备用3口试验'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 换向泄漏备用4口试验
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchM34(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏备用4口试验'", id, n);
            loadData(sql, dgv);
        }

        /// <summary>
        /// 中位压力损失
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf1(string id, int n,  DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,systembackPressure as 系统背压,mediumPressureLoss as 中位压力损失,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='中位压力损失试验'", id, n);
            loadData(sql, dgv);
        }


        /// <summary>
        /// 泄漏保压升降测试
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf3(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderPressure as 升降阀压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='泄漏保压升降测试'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 倾斜阀A口内泄漏测试
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf3A(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderInPressure as 倾斜阀A口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='倾斜阀A口内泄漏测试'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 倾斜阀B口内泄漏测试
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf3B(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderOutPressure as 倾斜阀B口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='倾斜阀B口内泄漏测试'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 备用1口内泄漏测试
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchfb1(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderOutPressure as 阀口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='备用1口内泄漏测试'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 备用2口内泄漏测试
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchfb2(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderOutPressure as 阀口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='备用2口内泄漏测试'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 备用3口内泄漏测试
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchfb3(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderOutPressure as 阀口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='备用3口内泄漏测试'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 备用4口内泄漏测试
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchfb4(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderOutPressure as 阀口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='备用4口内泄漏测试'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 门架上升
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf6(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("  select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderPressure as 油缸压力,menjiaUpPreLoss as 上升压力损失,menjiaVerticalDis as 上升位移, menjiaUpV as 上升速度,forceOut  as 上升滑阀力,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架上升试验'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 门架下降
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf7(string id, int n,  DataGridView dgv)
        {

            string sql = string.Format(" select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderPressure as 油缸压力,systembackpressure as 系统背压, menjiaDownPreLoss as 下降压力损失,menjiaVerticalDis as 下降位移, menjiaDownV as 下降速度,forceOut  as 下降滑阀力,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架下降试验'", id, n);
            loadData(sql, dgv);
        }
        /// <summary>
        /// 门架前倾
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf10(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,menjiaForwardInLoss as 前倾进油压力损失,menjiaForwardOutLoss as 前倾回油压力损失,  menjiaLeanDis as 前倾位移, menjiaForwardV as 前倾速度,forceIn  as 前倾滑阀力,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架前倾试验'", id, n);
            loadData(sql, dgv);
        }        
        

        /// <summary>
        /// 门架后倾
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf11(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,menjiaBackInLoss as 后倾进油压力损失,menjiaBackOutLoss as 后倾回油压力损失,  menjiaLeanDis as 后倾位移, menjiaBackV as 后倾速度,forceIn  as 后倾滑阀力,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架后倾试验'", id, n);
            loadData(sql, dgv);
        }

        /// <summary>
        /// 门架前倾自锁
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void Searchf13(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,testUpDis as 上升回程位移, testForwardDis as 前倾回程位移, testBackDis as 后倾回程位移, pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,menjiaForwardInLoss as 前倾进油压力损失,menjiaForwardOutLoss as 前倾回油压力损失, forceIn  as 前倾自锁滑阀力,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架前倾自锁'", id, n);
            loadData(sql, dgv);
        }

        public void Searchfnew(string id, int n, DataGridView dgv)
        {
            string sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,menjiaForwardInLoss as 前倾进油压力损失,menjiaForwardOutLoss as 前倾回油压力损失,  menjiaLeanDis as 前倾位移, menjiaForwardV as 前倾速度,backflow  as 回油流量,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架前倾动作检测'", id, n);
            loadData(sql, dgv);
        }


        /// <summary>
        /// 按时间查询
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="dgv"></param>
        public void SearchByTime( string StartTime, string EndTime, DataGridView dgv)
        {
            string sql = string.Format("select Id as 阀编号,n as 测试次数,sendCompany as 发往厂家,currentTime as 测试时间 from tbProductId where  convert(varchar(10),currentTime,120) between '{0}'and '{1}' order by currentTime", StartTime, EndTime);
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
        //    string sql = string.Format("select productId as 编号,n as 次数,p1 as 主泵1压力,q1 as 主泵1流量,p2 as 主泵2压力,q2 as 主泵2流量,Pb as 系统背压,q3 as 泄漏流量,time as 时间 from valvef10 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        //public void Searchf11(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,p1 as 主泵1压力,q1 as 主泵1流量,p2 as 主泵2压力,q2 as 主泵2流量,Pb as 系统背压,P3 as 中位压力损失,time as 时间 from valvef11 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        //public void Searchf12(string id, int n, DataGridView dgv)
        //{
        //    string sql = string.Format("select productId as 编号,n as 次数,p1 as 供油压力,q2 as 供油流量,p2 as 升降阀压力,pa as 倾斜阀A口压力,Pb as 倾斜阀B口压力,Q3 as 泄漏流量,time as 时间 from valvef12 where productId='{0}' and n={1}", id, n);
        //    loadData(sql, dgv);
        //}
        #endregion
    }
}
