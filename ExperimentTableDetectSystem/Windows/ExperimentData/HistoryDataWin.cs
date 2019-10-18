using ExperimentTableDetectSystem.NPOI;
using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExperimentTableDetectSystem.Windows.ExperimentData
{
    public partial class HistoryDataWin : MetroFramework.Forms.MetroForm
    {//时间列应为datetime类型
        public string Sql;
        public string sql;
        public static string productId;
        public static int N;
        public string Date;
        public string StartTime;
        public string EndTime;
        public int testSelection;
        SearchHelper searchhelper;
        DBHelper dbhelper;
        NPOIHelper npoi = new NPOIHelper();

        public HistoryDataWin()
        {
            InitializeComponent();

        }

        private void HistoryDataWin_Load(object sender, EventArgs e)
        {
            searchhelper = SearchHelper.GetInstance();
            productId = DataSearchWin.id;
            N = DataSearchWin.n;




        }



        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        /// <summary>
        /// 导出到excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            dbhelper = DBHelper.GetInstance();

            DataTable dt = dbhelper.ExecuteSqlDataAdapter(Sql, null, 0);
            ExportToExcel.ExportData1(dt);
        }

        /// <summary>
        /// 数据分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //dataAnalysisWin win = new dataAnalysisWin();

        }

        /// <summary>
        /// 导出到excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            dbhelper = DBHelper.GetInstance();

            DataTable dt = dbhelper.ExecuteSqlDataAdapter(Sql, null, 0);
            ExportToExcel.ExportData1(dt);
        }

        //手动试验
        // 主溢流阀调定
        private  void btnUserSet_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='主溢流阀调定试验'", productId, N);
            searchhelper.SearchM1(productId, N, dgv);
        }
        //转向溢流阀调定
        private void btnM2_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,steerPressure as 转向压力,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='转向溢流阀调定试验'", productId, N);
            searchhelper.SearchM2(productId, N, dgv);
        }
        //换向泄漏上升口试验
        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏上升口试验'", productId, N);
            searchhelper.SearchM3(productId, N, dgv);
        }
        //换向泄漏前倾口试验
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏前倾口试验'", productId, N);
            searchhelper.SearchM3A(productId, N, dgv);
        }
        //换向泄漏后倾口试验
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏后倾口试验'", productId, N);
            searchhelper.SearchM3B(productId, N, dgv);
        }
        //换向泄漏备用1口试验
        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏备用1口试验'", productId, N);
            searchhelper.SearchM31(productId, N, dgv);
        }
        //换向泄漏备用2口试验
        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏备用2口试验'", productId, N);
            searchhelper.SearchM32(productId, N, dgv);
        }
        //换向泄漏备用3口试验
        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏备用3口试验'", productId, N);
            searchhelper.SearchM33(productId, N, dgv);
        }
        //换向泄漏备用4口试验
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏备用4口试验'", productId, N);
            searchhelper.SearchM34(productId, N, dgv);
        }
        //过载阀A1口调定试验
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='过载阀A1口调定试验'", productId, N);
            searchhelper.SearchOverloadA(productId, N, dgv);
        }
        //过载阀A2口调定试验
        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='过载阀A2口调定试验'", productId, N);
            searchhelper.SearchOverloadA2(productId, N, dgv);
        }
        //过载阀B1口调定试验
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='过载阀B1口调定试验'", productId, N);
            searchhelper.SearchOverloadB(productId, N, dgv);
        }
        //过载阀B2口调定试验
        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='过载阀B2口调定试验'", productId, N);
            searchhelper.SearchOverloadB2(productId, N, dgv);
        }
        //自动试验
        //中位压力损失
        private void btnF1_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,systembackPressure as 系统背压,mediumPressureLoss as 中位压力损失,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='中位压力损失试验'", productId, N);
            searchhelper.Searchf1(productId, N, dgv);
        }
        //门架上升
        private void btnF4_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderPressure as 油缸压力,menjiaUpPreLoss as 上升压力损失,menjiaVerticalDis as 上升位移, menjiaUpV as 上升速度,forceIn  as 上升滑阀力,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架上升试验'", productId, N);
            searchhelper.Searchf6(productId, N, dgv);
        }
        //门架下降
        private void btnF5_Click(object sender, EventArgs e)
        {
            Sql = string.Format(" select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderPressure as 油缸压力,systembackpressure as 系统背压, menjiaDownPreLoss as 下降压力损失,menjiaVerticalDis as 下降位移, menjiaDownV as 下降速度, forceOut  as 下降滑阀力 ,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架下降试验'", productId, N);
            searchhelper.Searchf7(productId, N, dgv);
        }
        //门架前倾
        private void btnF6_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,menjiaForwardInLoss as 前倾进油压力损失,menjiaForwardOutLoss as 前倾回油压力损失,  menjiaLeanDis as 前倾位移, menjiaForwardV as 前倾速度,forceIn  as 前倾滑阀力,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架前倾试验'", productId, N);
            searchhelper.Searchf10(productId, N, dgv);
        }
        //门架后倾
        private void btnF7_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,menjiaBackInLoss as 后倾进油压力损失,menjiaBackOutLoss as 后倾回油压力损失,  menjiaLeanDis as 后倾位移, menjiaBackV as 后倾速度,forceIn  as 后倾滑阀力,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架后倾试验'", productId, N);
            searchhelper.Searchf11(productId, N, dgv);
        }
        //门架前倾自锁
        private void btnF8_Click(object sender, EventArgs e)
        {
            Sql = Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,testUpDis as 上升回程位移, testForwardDis as 前倾回程位移, testBackDis as 后倾回程位移, pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,menjiaForwardInLoss as 前倾进油压力损失,menjiaForwardOutLoss as 前倾回油压力损失, forceIn  as 前倾自锁滑阀力,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架前倾自锁'", productId, N);
            searchhelper.Searchf13(productId, N, dgv);
        }
        //门架前倾动作检测
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,menjiaForwardInLoss as 前倾进油压力损失,menjiaForwardOutLoss as 前倾回油压力损失,  menjiaLeanDis as 前倾位移, menjiaForwardV as 前倾速度,backflow  as 回油流量,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架前倾动作检测'", productId, N);
            searchhelper.Searchfnew(productId, N, dgv);
        }
        //泄漏保压升降测试
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderPressure as 升降阀压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='泄漏保压升降测试'", productId, N);
            searchhelper.Searchf3(productId, N, dgv);
        }
        //倾斜阀B口内泄漏测试
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderOutPressure as 倾斜阀B口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='倾斜阀B口内泄漏测试'", productId, N);
            searchhelper.Searchf3B(productId, N, dgv);
        }
        //倾斜阀A口内泄漏测试
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderInPressure as 倾斜阀A口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='倾斜阀A口内泄漏测试'", productId, N);
            searchhelper.Searchf3A(productId, N, dgv);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //备用1口内泄漏测试
        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderInPressure as 阀口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName=备用1口内泄漏测试'", productId, N);
            searchhelper.Searchfb1(productId, N, dgv);
        }
        //2
        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderInPressure as 阀口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName=备用2口内泄漏测试'", productId, N);
            searchhelper.Searchfb2(productId, N, dgv);

        }
        //3
        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderInPressure as 阀口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName=备用3口内泄漏测试'", productId, N);
            searchhelper.Searchfb3(productId, N, dgv);

        }
        //4
        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderInPressure as 阀口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName=备用4口内泄漏测试'", productId, N);
            searchhelper.Searchfb4(productId, N, dgv);

        }
    }
}
