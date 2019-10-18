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
    public partial class HistoryDataWin2 : MetroFramework.Forms.MetroForm
    {//时间列应为datetime类型
        public string  Sql;
        public static string ProductId;
        public static int NN;

        SearchHelper SearchHelper;
        DBHelper DbHelper;
        NPOIHelper Npoi = new NPOIHelper();

        public HistoryDataWin2()
        {
            InitializeComponent();

        }

        private void HistoryDataWin2_Load(object sender, EventArgs e)
        {
            SearchHelper = SearchHelper.GetInstance();
            ProductId = ValveListWin.id;
            NN = ValveListWin.n;

        }



        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            DbHelper = DBHelper.GetInstance();

            DataTable dt = DbHelper.ExecuteSqlDataAdapter(Sql, null, 0);
            ExportToExcel.ExportData1(dt);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnM2_Click_1(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,steerPressure as 转向压力,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='转向溢流阀调定试验'", ProductId, NN);
            SearchHelper.SearchM2(ProductId, NN, dgv);
        }

        private void btnM1_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='主溢流阀调定试验'", ProductId, NN);
            SearchHelper.SearchM1(ProductId, NN, dgv);
        }


        private void btnF1_Click_1(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,systembackPressure as 系统背压,mediumPressureLoss as 中位压力损失,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='中位压力损失试验'", ProductId, NN);
            SearchHelper.Searchf1(ProductId, NN, dgv);
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderPressure as 升降阀压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='泄漏保压升降测试'", ProductId, NN);
            SearchHelper.Searchf3(ProductId, NN, dgv);
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderInPressure as 倾斜阀A口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='倾斜阀A1口内泄漏测试'", ProductId, NN);
            SearchHelper.Searchf3A(ProductId, NN, dgv);
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderOutPressure as 倾斜阀B口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='倾斜阀B1口内泄漏测试'", ProductId, NN);
            SearchHelper.Searchf3B(ProductId, NN, dgv);
        }

        private void btnF4_Click_1(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderPressure as 油缸压力,menjiaUpPreLoss as 上升压力损失,menjiaVerticalDis as 上升位移, menjiaUpV as 上升速度,forceIn  as 上升滑阀力,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架上升试验'", ProductId, NN);
            SearchHelper.Searchf6(ProductId, NN, dgv);
        }

        private void btnF5_Click_1(object sender, EventArgs e)
        {
            Sql = string.Format(" select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderPressure as 油缸压力,systembackpressure as 系统背压, menjiaDownPreLoss as 下降压力损失,menjiaVerticalDis as 下降位移, menjiaDownV as 下降速度, forceOut  as 下降滑阀力 ,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架下降试验'", ProductId, NN);
            SearchHelper.Searchf7(ProductId, NN, dgv);
        }

        private void btnF6_Click_1(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,menjiaForwardInLoss as 前倾进油压力损失,menjiaForwardOutLoss as 前倾回油压力损失,  menjiaLeanDis as 前倾位移, menjiaForwardV as 前倾速度,forceIn  as 前倾滑阀力,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架前倾试验'", ProductId, NN);
            SearchHelper.Searchf10(ProductId, NN, dgv);
        }

        private void btnF7_Click_1(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,menjiaBackInLoss as 后倾进油压力损失,menjiaBackOutLoss as 后倾回油压力损失,  menjiaLeanDis as 后倾位移, menjiaBackV as 后倾速度,forceIn  as 后倾滑阀力,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架后倾试验'", ProductId, NN);
            SearchHelper.Searchf11(ProductId, NN, dgv);
        }

        private void btnF8_Click_1(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,testUpDis as 上升回程位移, testForwardDis as 前倾回程位移, testBackDis as 后倾回程位移, pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,menjiaForwardInLoss as 前倾进油压力损失,menjiaForwardOutLoss as 前倾回油压力损失, forceIn  as 前倾自锁滑阀力,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架前倾自锁'", ProductId, NN);
            SearchHelper.Searchf13(ProductId, NN, dgv);
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,cylinderInPressure as 油缸进油口压力,cylinderOutPressure as 油缸出油口压力,systembackPressure as 系统背压,menjiaForwardInLoss as 前倾进油压力损失,menjiaForwardOutLoss as 前倾回油压力损失,  menjiaLeanDis as 前倾位移, menjiaForwardV as 前倾速度,backflow  as 回油流量,steerPressure as 转向压力,steerflow as 转向流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='门架前倾动作检测'", ProductId, NN);
            SearchHelper.Searchfnew(ProductId, NN, dgv);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='过载阀A口调定试验'", ProductId, NN);
            SearchHelper.SearchOverloadA(ProductId, NN, dgv);
        }
        //
        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='过载阀A2口调定试验'", ProductId, NN);
            SearchHelper.SearchOverloadA2(ProductId, NN, dgv);
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='过载阀B口调定试验'", ProductId, NN);
            SearchHelper.SearchOverloadB(ProductId, NN, dgv);
        }
        //
        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,mainPumpP1 as 主泵1压力,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName='过载阀B2口调定试验'", ProductId, NN);
            SearchHelper.SearchOverloadB2(ProductId, NN, dgv);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏上升口试验'", ProductId, NN);
            SearchHelper.SearchM3(ProductId, NN, dgv);
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏前倾口试验'", ProductId, NN);
            SearchHelper.SearchM3A(ProductId, NN, dgv);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏后倾口试验'", ProductId, NN);
            SearchHelper.SearchM3B(ProductId, NN, dgv);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏备用1口试验'", ProductId, NN);
            SearchHelper.SearchM31(ProductId, NN, dgv);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏备用2口试验'", ProductId, NN);
            SearchHelper.SearchM32(ProductId, NN, dgv);
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏备用3口试验'", ProductId, NN);
            SearchHelper.SearchM33(ProductId, NN, dgv);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Sql = string.Format("  select productId as 编号,n as 次数,mainPumpP1 as 主泵1压力,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 先导压力 ,pump1flow as 主泵1流量,mainPumpP2 as 主泵2压力,pump2flow as 主泵2流量,leakageflow as 泄漏流量 ,currentTime as 当前时间 from allData where productId='{0}' and n={1}and testName='换向泄漏备用4口试验'", ProductId, NN);
            SearchHelper.SearchM34(ProductId, NN, dgv);
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderInPressure as 阀口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName=备用1口内泄漏测试'", ProductId, NN);
            SearchHelper.Searchfb1(ProductId, NN, dgv);
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderInPressure as 阀口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName=备用2口内泄漏测试'", ProductId, NN);
            SearchHelper.Searchfb1(ProductId, NN, dgv);
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderInPressure as 阀口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName=备用3口内泄漏测试'", ProductId, NN);
            SearchHelper.Searchfb1(ProductId, NN, dgv);
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            Sql = string.Format("select productId as 编号,n as 次数,testName as 测试项目,tankTemp as 油箱温度 ,pump1OutTemp as 泵1出口温度, pump2OutTemp as 泵2出口温度 ,pilotPressure as 供油压力 ,cylinderInPressure as 阀口压力,leakageflow as 泄漏流量,currentTime as 当前时间 from allData where productId='{0}' and n={1} and testName=备用4口内泄漏测试'", ProductId, NN);
            SearchHelper.Searchfb1(ProductId, NN, dgv);
        }
    }
}