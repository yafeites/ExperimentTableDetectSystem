using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data.SqlClient;
using ExperimentTableDetectSystem.util;
using NPOI.SS.Util;
using ExperimentTableDetectSystem.Windows.manual;
using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.Windows.setParameterWin;

namespace ExperimentTableDetectSystem.NPOI
{
    public class NPOIHelper
    {
        static HSSFWorkbook workBook;
        static HSSFWorkbook workBook2;
        int thismain = SetParameterWin.main1;
        int thissteer = SetParameterWin.steer1;
        int thisover = SetParameterWin.over;
        DBHelper dbHelper;
        public NPOIHelper()
        {
            workBook = new HSSFWorkbook(new FileStream(@"E:\工作簿1.xls", FileMode.Open));
            workBook2 = new HSSFWorkbook();
            dbHelper = DBHelper.GetInstance();
        }
        public static int n = 1;
        /// <summary>
        /// 转换datatable数据为Excel表格
        /// </summary>
        /// <param name="dt"></param>
        public void ConvertTableToExcel(DataTable dt, string tableName = null)
        {
            HSSFSheet sheet;

            if (!string.IsNullOrEmpty(tableName))
            {
                sheet = (HSSFSheet)workBook2.CreateSheet(tableName);
            }
            else if (!string.IsNullOrEmpty(dt.TableName))
            {
                sheet = (HSSFSheet)workBook2.CreateSheet(dt.TableName);
            }
            else
            {
                sheet = (HSSFSheet)workBook2.CreateSheet(DateTime.Now.ToString("t"));
            }

            //标题行
            HSSFRow title = (HSSFRow)sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                title.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
            }

            //正文内容
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                HSSFRow row = (HSSFRow)sheet.CreateRow(i);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    var v = dt.Rows[i][j].ToString();
                    if (dt.Rows[i][j].ToString() == "")
                    {
                        break;
                    }
                    row.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                }
            }
        }

        public void CreateExcelTest(DataTable dt)
        {
            //创建表格
            HSSFSheet sheet1;
            sheet1 = (HSSFSheet)workBook.GetSheet("sheet1");
            sheet1.SetColumnWidth(1, 14 * 256);
            sheet1.SetColumnWidth(5, 14 * 256);
            sheet1.SetColumnWidth(2, 4 * 256);
            sheet1.SetColumnWidth(6, 4 * 256);
            //总标题style
            HSSFFont font = (HSSFFont)workBook.CreateFont();
            font.FontHeightInPoints = 14;
            ICellStyle style = workBook.CreateCellStyle();
            style.SetFont(font);
            style.Alignment = HorizontalAlignment.CENTER;
            style.BorderBottom = BorderStyle.THIN;
            style.BorderTop = BorderStyle.THIN;
            style.BorderLeft = BorderStyle.THIN;
            style.BorderRight = BorderStyle.THIN;


            //小标题style
            ICellStyle style1 = workBook.CreateCellStyle();
            style1.Alignment = HorizontalAlignment.CENTER;
            style1.BorderBottom = BorderStyle.THIN;
            style1.BorderTop = BorderStyle.THIN;
            style1.BorderLeft = BorderStyle.THIN;
            style1.BorderRight = BorderStyle.THIN;

            //其他style
            ICellStyle style2 = workBook.CreateCellStyle();
            style2.Alignment = HorizontalAlignment.LEFT;
            style2.BorderBottom = BorderStyle.THIN;
            style2.BorderTop = BorderStyle.THIN;
            style2.BorderLeft = BorderStyle.THIN;
            style2.BorderRight = BorderStyle.THIN;

            //最右style
            ICellStyle style3 = workBook.CreateCellStyle();
            style3.Alignment = HorizontalAlignment.RIGHT;

            //创建单元格
            for (int i = 0; i <= 38 + dt.Rows.Count; i++)
            {
                HSSFRow row = (HSSFRow)sheet1.CreateRow(i);
                for (int j = 0; j <= 7; j++)
                {
                    HSSFCell cell = (HSSFCell)row.CreateCell(j);
                }
            }

            //填充单元格
            //string sql = string.Format("select MAX(testUpDis) as max from allData where productId = 1 and testName = '转向优先阀流量试验'");
            // SqlDataReader reader = dbHelper.ExecuteReader(sql);
            //reader.Read();
            //string testn = reader["max"].ToString();
            // sheet1.GetRow(1).GetCell(2).SetCellValue(testn);
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                HSSFRow row = (HSSFRow)sheet1.GetRow(i);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    var v = dt.Rows[i][j].ToString();
                    if (dt.Rows[i][j].ToString() == "")
                    {
                        break;
                    }
                    row.CreateCell(j + 10).SetCellValue(Double.Parse(dt.Rows[i][j].ToString()));
                }
                row.CreateCell(9).SetCellValue(i * 0.1);

            }

            sheet1.GetRow(0).CreateCell(9).SetCellValue("时间(s)");
            sheet1.GetRow(0).GetCell(9).CellStyle = style3;
            sheet1.GetRow(0).CreateCell(10).SetCellValue("流量(L)");
            sheet1.GetRow(0).GetCell(10).CellStyle = style3;
            sheet1.GetRow(0).CreateCell(11).SetCellValue("泵1压力(bar)");
            sheet1.GetRow(0).GetCell(11).CellStyle = style3;
            sheet1.GetRow(0).CreateCell(12).SetCellValue("泵2压力(bar)");
            sheet1.GetRow(0).GetCell(12).CellStyle = style3;

            string ConvertToString(DateTime dateTime)
            {
                return dateTime.ToString("yyyy-MM-dd");
            }

            string sqlstr = "select * from tbProductId where Id=" + "'" + ManualNumberInput.id + "'";
            if (!OperateDb.IsTableNull(sqlstr))

            {
                DataTable dt1 = OperateDb.readTableN(sqlstr);
                n = dt1.Rows.Count;
            }
            //油液温度
            string sql1 = string.Format("select round(AVG(pump1OutTemp),2) as temp from allData where productId='{0}' and n={1} ", ManualNumberInput.id, n);
            SqlDataReader reader1 = dbHelper.ExecuteReader(sql1);
            reader1.Read();
            string temp = reader1["temp"].ToString();
            //主溢流阀调定压力、流量
            string sql2 = string.Format("select round(AVG(mainPumpP1)+3,2) as p1 , round(AVG(pump1flow),2)+round(AVG(pump2flow),2) as f1 from allData where testName='主溢流阀调定试验' and  productId='{0}' and n={1} and mainPumpP1 between {2} and {3} ", ManualNumberInput.id, n,thismain-5,thismain+2);
            SqlDataReader reader2 = dbHelper.ExecuteReader(sql2);
            reader2.Read();
            string p1 = reader2["p1"].ToString();
            string f1 = reader2["f1"].ToString();
            //转向溢流阀调定压力、流量
            string sql3 = string.Format("select round(AVG(steerPressure)+3,2)  as p1 , round(AVG(pump1flow),2)+round(AVG(pump2flow),2) as f1 from allData where testName='转向溢流阀调定试验' and productId='{0}' and n={1} and steerPressure between {2} and {3}", ManualNumberInput.id, n,thissteer-5,thissteer+2);
            SqlDataReader reader3 = dbHelper.ExecuteReader(sql3);
            reader3.Read();
            string p11 = reader3["p1"].ToString();
            string f11 = reader3["f1"].ToString();
            //门架上升压力损失、测试流量、滑阀最大推力、液压泵流量、转向流量
            string sql4 = string.Format("select round(MAX(menjiaUpPreLoss),2) as upl , round(AVG(pump1flow),2)+round(AVG(pump2flow),2) as f1 ,round(MAX(forceIn),2) as foi ,MAX(steerflow) as sf from allData where testName='门架上升试验' and productId='{0}' and n={1} ", ManualNumberInput.id, n);
            SqlDataReader reader4 = dbHelper.ExecuteReader(sql4);
            reader4.Read();
            string upl1 = reader4["upl"].ToString();
            string f111 = reader4["f1"].ToString();
           // string foi1 = reader4["foi"].ToString();
            string sf1 = reader4["sf"].ToString();
            //门架下降压力损失、测试流量、滑阀最大推力
            string sql5 = string.Format("select round(MAX(menjiaDownPreLoss),2) as udl , (round(AVG(backflow),2)-round(AVG(pump1flow),2)-round(AVG(pump2flow),2)) as f1 ,round(MAX(forceOut),2) as foo  from allData where testName='门架下降试验' and productId='{0}' and n={1} ", ManualNumberInput.id, n);
            SqlDataReader reader5 = dbHelper.ExecuteReader(sql5);
            reader5.Read();
            string udl1 = reader5["udl"].ToString();
            string f1111 = reader5["f1"].ToString();
            // string foo1 = reader5["foo"].ToString();

            //门架前倾进油压力损失、回油压力损失、测试流量
            string sql6 = string.Format("select round(MAX(menjiaForwardInLoss),2) as fil , round(MAX(menjiaForwardOutLoss),2) as fol ,round(AVG(pump1flow),2)+round(AVG(pump2flow),2) as f1 from allData where testName='门架前倾试验' and productId='{0}' and n={1} ", ManualNumberInput.id, n);
            SqlDataReader reader6 = dbHelper.ExecuteReader(sql6);
            reader6.Read();
            string fil = reader6["fil"].ToString();
            string fol = reader6["fol"].ToString();
            string f11111 = reader6["f1"].ToString();
            //门架后倾进油口压力损失、回油压力损失、测试流量
            string sql7 = string.Format("select round(MAX(menjiaBackInLoss),2) as fil , round(MAX(menjiaBackOutLoss),2) as fol ,round(AVG(pump1flow),2)+round(AVG(pump2flow),2) as f1 from allData where testName='门架后倾试验' and productId='{0}' and n={1} ", ManualNumberInput.id, n);
            SqlDataReader reader7 = dbHelper.ExecuteReader(sql7);
            reader7.Read();
            string filb = reader7["fil"].ToString();
            string folb = reader7["fol"].ToString();
            string f111111 = reader7["f1"].ToString();
            //中位压力损失、测试流量
            string sql8 = string.Format("select round(AVG(mediumPressureLoss),2) as mpl , round(AVG(pump1flow),2)+round(AVG(pump2flow),2) as f1 from allData where testName='中位压力损失试验' and productId='{0}' and n={1} ", ManualNumberInput.id, n);
            SqlDataReader reader8 = dbHelper.ExecuteReader(sql8);
            reader8.Read();
            string mpl = reader8["mpl"].ToString();
            string f1111111 = reader8["f1"].ToString();
            //前倾自锁泄漏流量、上升回程位移、前倾回程位移、后倾回程位移
            string sql9 = string.Format("select round(60/AVG(leakageflow),2) as lf , round(MAX(testUpDis),2) as ud,round(MAX(testForwardDis),2) as fd,round(MAX(testBackDis),2) as bd from allData where testName='门架前倾自锁' and productId='{0}' and n={1} ", ManualNumberInput.id, n);
            SqlDataReader reader9 = dbHelper.ExecuteReader(sql9);
            reader9.Read();
            string lf1 = reader9["lf"].ToString();
            string ud = reader9["ud"].ToString();
            string fd = reader9["fd"].ToString();
            string bd = reader9["bd"].ToString();
            //前倾口内泄漏流量、压力
            string sql10 = string.Format("select isnull((MAX(pilotPressure)-3),0) as p1 from allData where testName='倾斜阀A口内泄漏测试' and productId='{0}' and n={1}", ManualNumberInput.id, n);
            SqlDataReader reader10 = dbHelper.ExecuteReader(sql10);
            reader10.Read();
            string sql100 = string.Format("select isnull(round(60/AVG(leakageflow),2),0) as lf from (select top 5 leakageflow  from allData where testName='倾斜阀A口内泄漏测试' and productId='{0}' and n={1} and leakageflow!=600 order by currentTime desc) as temp", ManualNumberInput.id, n);
            SqlDataReader reader100 = dbHelper.ExecuteReader(sql100);
            reader100.Read();
            string lf11 = reader100["lf"].ToString();
            string p111 = reader10["p1"].ToString();
            //后倾口内泄漏流量、压力
            string sql11 = string.Format("select isnull((MAX(pilotPressure)-3),0) as p1 from allData where testName='倾斜阀B口内泄漏测试' and productId='{0}' and n={1}", ManualNumberInput.id, n);
            SqlDataReader reader11 = dbHelper.ExecuteReader(sql11);
            reader11.Read();
            string sql110 = string.Format("select isnull(round(60/AVG(leakageflow),2),0) as lf from (select top 5 leakageflow  from allData where testName='倾斜阀B口内泄漏测试' and productId='{0}' and n={1} and leakageflow!=600 order by currentTime desc) as temp", ManualNumberInput.id, n);
            SqlDataReader reader110 = dbHelper.ExecuteReader(sql110);
            reader110.Read();
            string lf111 = reader110["lf"].ToString();
            string p1111 = reader11["p1"].ToString();
            //升口内泄漏流量、压力
            string sql12 = string.Format("select isnull((MAX(pilotPressure)-3),0) as p1 from allData where testName='泄漏保压升降测试' and productId='{0}' and n={1}", ManualNumberInput.id, n);
            SqlDataReader reader12 = dbHelper.ExecuteReader(sql12);
            reader12.Read();
            string sql120 = string.Format("select isnull(round(60/AVG(leakageflow),2),0) as lf from (select top 5 leakageflow  from allData where testName='泄漏保压升降测试' and productId='{0}' and n={1} and leakageflow!=600 order by currentTime desc) as temp", ManualNumberInput.id, n);
            SqlDataReader reader120 = dbHelper.ExecuteReader(sql120);
            reader120.Read();
            string lf1111 = reader120["lf"].ToString();
            string p11111 = reader12["p1"].ToString();
            //过载阀A1口调定压力、主泵流量
            string sql13 = string.Format("select case when MAX(mainPumpP1) > MAX(mainPumpP2) then round(AVG(mainPumpP1)+3,2) else round(AVG(mainPumpP2)+2,2) end  as p1 , round(AVG(pump1flow),2)+round(AVG(pump2flow),2) as f1 from allData where testName='过载阀A1口调定试验' and productId='{0}' and n={1} and mainPumpP1 between {2} and {3}", ManualNumberInput.id, n,thisover-5,thisover+2);
            SqlDataReader reader13 = dbHelper.ExecuteReader(sql13);
            reader13.Read();
            string p2 = reader13["p1"].ToString();
            string f2 = reader13["f1"].ToString();
            //过载阀A2口调定压力、主泵流量
            string sql14 = string.Format("select case when MAX(mainPumpP1) > MAX(mainPumpP2) then round(AVG(mainPumpP1)+3,2) else round(AVG(mainPumpP2)+2,2) end  as p1 ,round(AVG(pump1flow),2)+round(AVG(pump2flow),2) as f1 from allData where testName='过载阀A2口调定试验' and productId='{0}' and n={1}and mainPumpP1 between {2} and {3}", ManualNumberInput.id, n, thisover - 5, thisover + 2);
            SqlDataReader reader14 = dbHelper.ExecuteReader(sql14);
            reader14.Read();
            string p3 = reader14["p1"].ToString();
            string f3 = reader14["f1"].ToString();

            //过载阀B1口调定压力、主泵流量
            string sql22 = string.Format("select case when MAX(mainPumpP1) > MAX(mainPumpP2) then round(AVG(mainPumpP1)+3,2) else round(AVG(mainPumpP2)+2,2) end  as p1 ,round(AVG(pump1flow),2)+round(AVG(pump2flow),2) as f1 from allData where testName='过载阀B1口调定试验' and productId='{0}' and n={1} and mainPumpP1 between {2} and {3}", ManualNumberInput.id, n, thisover - 5, thisover + 2);
            SqlDataReader reader22 = dbHelper.ExecuteReader(sql22);
            reader22.Read();
            string p21 = reader22["p1"].ToString();
            string f21 = reader22["f1"].ToString();
            //过载阀B2口调定压力、主泵流量
            string sql23 = string.Format("select case when MAX(mainPumpP1) > MAX(mainPumpP2) then round(AVG(mainPumpP1)+3,2) else round(AVG(mainPumpP2)+2,2) end  as p1 , round(AVG(pump1flow),2)+round(AVG(pump2flow),2) as f1 from allData where testName='过载阀B2口调定试验' and productId='{0}' and n={1} and mainPumpP1 between {2} and {3}", ManualNumberInput.id, n, thisover - 5, thisover + 2);
            SqlDataReader reader23 = dbHelper.ExecuteReader(sql23);
            reader23.Read();
            string p31 = reader23["p1"].ToString();
            string f31 = reader23["f1"].ToString();

            //换向泄漏上升口泄漏流量、测试压力
            string sql15 = string.Format("select case when isnull(MAX(mainPumpP1),0) > isnull(MAX(mainPumpP2),0) then round(AVG(mainPumpP1),2) else round(AVG(mainPumpP2),2) end as p1 from allData where testName='换向泄漏上升口试验' and productId='{0}' and n={1}", ManualNumberInput.id, n);
            SqlDataReader reader15 = dbHelper.ExecuteReader(sql15);
            reader15.Read();
            string sql150 = string.Format("select isnull(round(60/AVG(leakageflow),2),0) as lf from allData where testName='换向泄漏上升口试验' and productId='{0}' and n={1} and leakageflow!=600", ManualNumberInput.id, n);
            SqlDataReader reader150 = dbHelper.ExecuteReader(sql150);
            reader150.Read();
            string lf4 = reader150["lf"].ToString();
            string p4 = reader15["p1"].ToString();
            //换向泄漏前倾口泄漏流量、测试压力
            string sql16 = string.Format("select case when isnull(MAX(mainPumpP1),0) > isnull(MAX(mainPumpP2),0) then round(AVG(mainPumpP1),2) else round(AVG(mainPumpP2),2) end as p1 from allData where testName='换向泄漏前倾口试验' and productId='{0}' and n={1} ", ManualNumberInput.id, n);
            SqlDataReader reader16 = dbHelper.ExecuteReader(sql16);
            reader16.Read();
            string sql160 = string.Format("select isnull(round(60/AVG(leakageflow),2),0) as lf from allData where testName='换向泄漏前倾口试验' and productId='{0}' and n={1} and leakageflow!=600", ManualNumberInput.id, n);
            SqlDataReader reader160 = dbHelper.ExecuteReader(sql160);
            reader160.Read();
            string lf5 = reader160["lf"].ToString();
            string p5 = reader16["p1"].ToString();
            //换向泄漏后倾口泄漏流量、测试压力
            string sql17 = string.Format("select case when isnull(MAX(mainPumpP1),0) > isnull(MAX(mainPumpP2),0) then round(AVG(mainPumpP1),2) else round(AVG(mainPumpP2),2) end as p1 from allData where testName='换向泄漏后倾口试验' and productId='{0}' and n={1} ", ManualNumberInput.id, n);
            SqlDataReader reader17 = dbHelper.ExecuteReader(sql17);
            reader17.Read();
            string sql170 = string.Format("select isnull(round(60/AVG(leakageflow),2),0) as lf from allData where testName='换向泄漏后倾口试验' and productId='{0}' and n={1} and leakageflow!=600", ManualNumberInput.id, n);
            SqlDataReader reader170 = dbHelper.ExecuteReader(sql170);
            reader170.Read();
            string lf6 = reader170["lf"].ToString();
            string p6 = reader17["p1"].ToString();
            //换向泄漏备用1口泄漏流量、测试压力
            string sql18 = string.Format("select case when isnull(MAX(mainPumpP1),0) > isnull(MAX(mainPumpP2),0) then round(AVG(mainPumpP1),2) else round(AVG(mainPumpP2),2) end as p1 from allData where testName='换向泄漏备用1口试验' and productId='{0}' and n={1}", ManualNumberInput.id, n);
            SqlDataReader reader18 = dbHelper.ExecuteReader(sql18);
            reader18.Read();
            string sql180 = string.Format("select isnull(round(60/AVG(leakageflow),2),0) as lf from (select top 5 leakageflow  from allData where testName='换向泄漏备用1口试验' and productId='{0}' and n={1} and leakageflow!=600 order by currentTime desc) as temp", ManualNumberInput.id, n);
            SqlDataReader reader180 = dbHelper.ExecuteReader(sql180);
            reader180.Read();
            string lf7 = reader180["lf"].ToString();
            string p7 = reader18["p1"].ToString();
            //换向泄漏备用2口泄漏流量、测试压力
            string sql19 = string.Format("select case when isnull(MAX(mainPumpP1),0) > isnull(MAX(mainPumpP2),0) then round(AVG(mainPumpP1),2) else round(AVG(mainPumpP2),2) end as p1 from allData where testName='换向泄漏备用2口试验' and productId='{0}' and n={1}", ManualNumberInput.id, n);
            SqlDataReader reader19 = dbHelper.ExecuteReader(sql19);
            reader19.Read();
            string sql190 = string.Format("select isnull(round(60/AVG(leakageflow),2),0) as lf from (select top 5 leakageflow  from allData where testName='换向泄漏备用2口试验' and productId='{0}' and n={1} and leakageflow!=600 order by currentTime desc) as temp", ManualNumberInput.id, n);
            SqlDataReader reader190 = dbHelper.ExecuteReader(sql190);
            reader190.Read();
            string lf8 = reader190["lf"].ToString();
            string p8 = reader19["p1"].ToString();
            //换向泄漏备用3口泄漏流量、测试压力
            string sql20 = string.Format("select case when isnull(MAX(mainPumpP1),0) > isnull(MAX(mainPumpP2),0) then round(AVG(mainPumpP1),2) else round(AVG(mainPumpP2),2) end as p1 from allData where testName='换向泄漏备用3口试验' and productId='{0}' and n={1}", ManualNumberInput.id, n);
            SqlDataReader reader20 = dbHelper.ExecuteReader(sql20);
            reader20.Read();
            string sql200 = string.Format("select isnull(round(60/AVG(leakageflow),2),0) as lf from (select top 5 leakageflow  from allData where testName='换向泄漏备用3口试验' and productId='{0}' and n={1} and leakageflow!=600 order by currentTime desc) as temp", ManualNumberInput.id, n);
            SqlDataReader reader200 = dbHelper.ExecuteReader(sql200);
            reader200.Read();
            string lf9 = reader200["lf"].ToString();
            string p9 = reader20["p1"].ToString();
            //换向泄漏备用4口泄漏流量、测试压力
            string sql21 = string.Format("select case when isnull(MAX(mainPumpP1),0) > isnull(MAX(mainPumpP2),0) then round(AVG(mainPumpP1),2) else round(AVG(mainPumpP2),2) end as p1 from allData where testName='换向泄漏备用4口试验' and productId='{0}' and n={1}", ManualNumberInput.id, n);
            SqlDataReader reader21 = dbHelper.ExecuteReader(sql21);
            reader21.Read();
            string sql210 = string.Format("select isnull(round(60/AVG(leakageflow),2),0) as lf from (select top 5 leakageflow  from allData where testName='换向泄漏备用4口试验' and productId='{0}' and n={1} and leakageflow!=600 order by currentTime desc) as temp", ManualNumberInput.id, n);
            SqlDataReader reader210 = dbHelper.ExecuteReader(sql210);
            reader210.Read();
            string lf10 = reader210["lf"].ToString();
            string p10 = reader21["p1"].ToString();

            //备用1内泄漏
            string sqlb1a = string.Format("select isnull((MAX(pilotPressure)-3),0) as p1 from allData where testName='备用1口内泄漏测试' and productId='{0}' and n={1}", ManualNumberInput.id, n);
            SqlDataReader readerb1a = dbHelper.ExecuteReader(sqlb1a);
            readerb1a.Read();
            string sqlb1b = string.Format("select isnull(round(60/AVG(leakageflow),2),0) as lf from (select top 5 leakageflow  from allData where testName='备用1口内泄漏测试' and productId='{0}' and n={1} and leakageflow!=600 order by currentTime desc) as temp", ManualNumberInput.id, n);
            SqlDataReader readerb1b = dbHelper.ExecuteReader(sqlb1b);
            readerb1b.Read();
            string lfb1 = readerb1b["lf"].ToString();
            string p1b1 = readerb1a["p1"].ToString();
            //备用2内泄漏
            string sqlb2a = string.Format("select isnull((MAX(pilotPressure)-3),0) as p1 from allData where testName='备用2口内泄漏测试' and productId='{0}' and n={1}", ManualNumberInput.id, n);
            SqlDataReader readerb2a = dbHelper.ExecuteReader(sqlb2a);
            readerb2a.Read();
            string sqlb2b = string.Format("select isnull(round(60/AVG(leakageflow),2),0) as lf from (select top 5 leakageflow  from allData where testName='备用2口内泄漏测试' and productId='{0}' and n={1} and leakageflow!=600 order by currentTime desc) as temp", ManualNumberInput.id, n);
            SqlDataReader readerb2b = dbHelper.ExecuteReader(sqlb2b);
            readerb2b.Read();
            string lfb2 = readerb2b["lf"].ToString();
            string p1b2 = readerb2a["p1"].ToString();
            //备用3内泄漏
            string sqlb3a = string.Format("select isnull((MAX(pilotPressure)-3),0) as p1 from allData where testName='备用3口内泄漏测试' and productId='{0}' and n={1}", ManualNumberInput.id, n);
            SqlDataReader readerb3a = dbHelper.ExecuteReader(sqlb3a);
            readerb3a.Read();
            string sqlb3b = string.Format("select isnull(round(60/AVG(leakageflow),2),0) as lf from (select top 5 leakageflow  from allData where testName='备用3口内泄漏测试' and productId='{0}' and n={1} and leakageflow!=600 order by currentTime desc) as temp", ManualNumberInput.id, n);
            SqlDataReader readerb3b = dbHelper.ExecuteReader(sqlb3b);
            readerb3b.Read();
            string lfb3 = readerb3b["lf"].ToString();
            string p1b3 = readerb3a["p1"].ToString();
            //备用4内泄漏
            string sqlb4a = string.Format("select isnull((MAX(pilotPressure)-3),0) as p1 from allData where testName='备用4口内泄漏测试' and productId='{0}' and n={1}", ManualNumberInput.id, n);
            SqlDataReader readerb4a = dbHelper.ExecuteReader(sqlb4a);
            readerb4a.Read();
            string sqlb4b = string.Format("select isnull(round(60/AVG(leakageflow),2),0) as lf from (select top 5 leakageflow  from allData where testName='备用4口内泄漏测试' and productId='{0}' and n={1} and leakageflow!=600 order by currentTime desc) as temp", ManualNumberInput.id, n);
            SqlDataReader readerb4b = dbHelper.ExecuteReader(sqlb4b);
            readerb4b.Read();
            string lfb4 = readerb4b["lf"].ToString();
            string p1b4 = readerb4a["p1"].ToString();

            sheet1.GetRow(0).GetCell(0).SetCellValue("测试表格");
            sheet1.GetRow(1).GetCell(0).SetCellValue("被测阀编号"); sheet1.GetRow(1).GetCell(2).SetCellValue(ManualNumberInput.id);
            sheet1.GetRow(1).GetCell(4).SetCellValue("测试时间"); sheet1.GetRow(1).GetCell(6).SetCellValue(ConvertToString(DateTime.Now));
            sheet1.GetRow(2).GetCell(0).SetCellValue("测试人");
            sheet1.GetRow(2).GetCell(4).SetCellValue("油液温度"); sheet1.GetRow(2).GetCell(6).SetCellValue(temp);
            sheet1.GetRow(3).GetCell(0).SetCellValue("阀压力调定测试");
            sheet1.GetRow(4).GetCell(0).SetCellValue("主溢流阀调定压力(bar)"); sheet1.GetRow(4).GetCell(2).SetCellValue(p1);
            sheet1.GetRow(4).GetCell(4).SetCellValue("主泵流量（l/min）"); sheet1.GetRow(4).GetCell(6).SetCellValue(f1);
            sheet1.GetRow(5).GetCell(0).SetCellValue("转向溢流阀调定压力(bar)"); sheet1.GetRow(5).GetCell(2).SetCellValue(p11);
            sheet1.GetRow(5).GetCell(4).SetCellValue("主泵流量（l/min）"); sheet1.GetRow(5).GetCell(6).SetCellValue(f11);
            sheet1.GetRow(6).GetCell(0).SetCellValue("过载阀B3口调定压力(bar)"); sheet1.GetRow(6).GetCell(2).SetCellValue(p2);
            sheet1.GetRow(6).GetCell(4).SetCellValue("主泵流量（l/min）"); sheet1.GetRow(6).GetCell(6).SetCellValue(f2);
            sheet1.GetRow(7).GetCell(0).SetCellValue("过载阀A3口调定压力(bar)"); sheet1.GetRow(7).GetCell(2).SetCellValue(p3);
            sheet1.GetRow(7).GetCell(4).SetCellValue("主泵流量（l/min）"); sheet1.GetRow(7).GetCell(6).SetCellValue(f3);
            sheet1.GetRow(8).GetCell(0).SetCellValue("过载阀B4口调定压力(bar)"); sheet1.GetRow(8).GetCell(2).SetCellValue(p21);
            sheet1.GetRow(8).GetCell(4).SetCellValue("主泵流量（l/min）"); sheet1.GetRow(8).GetCell(6).SetCellValue(f21);
            sheet1.GetRow(9).GetCell(0).SetCellValue("过载阀A4口调定压力(bar)"); sheet1.GetRow(9).GetCell(2).SetCellValue(p31);
            sheet1.GetRow(9).GetCell(4).SetCellValue("主泵流量（l/min）"); sheet1.GetRow(9).GetCell(6).SetCellValue(f31);
            sheet1.GetRow(8+2).GetCell(0).SetCellValue("换向泄漏测试");
            sheet1.GetRow(9 + 2).GetCell(0).SetCellValue("上升口泄漏流量（ml/min）"); sheet1.GetRow(9 + 2).GetCell(2).SetCellValue(lf4);
            sheet1.GetRow(9 + 2).GetCell(4).SetCellValue("测试压力(bar)"); sheet1.GetRow(9 + 2).GetCell(6).SetCellValue(p4);
            sheet1.GetRow(10 + 2).GetCell(0).SetCellValue("前倾口泄漏流量（ml/min）"); sheet1.GetRow(10 + 2).GetCell(2).SetCellValue(lf5);
            sheet1.GetRow(10 + 2).GetCell(4).SetCellValue("测试压力(bar)"); sheet1.GetRow(10 + 2).GetCell(6).SetCellValue(p5);
            sheet1.GetRow(11 + 2).GetCell(0).SetCellValue("后倾口泄漏流量（ml/min）"); sheet1.GetRow(11 + 2).GetCell(2).SetCellValue(lf6);
            sheet1.GetRow(11 + 2).GetCell(4).SetCellValue("测试压力(bar)"); sheet1.GetRow(11 + 2).GetCell(6).SetCellValue(p6);
            sheet1.GetRow(12 + 2).GetCell(0).SetCellValue("B3口泄漏流量（ml/min）"); sheet1.GetRow(12 + 2).GetCell(2).SetCellValue(lf7);
            sheet1.GetRow(12 + 2).GetCell(4).SetCellValue("测试压力(bar)"); sheet1.GetRow(12 + 2).GetCell(6).SetCellValue(p7);
            sheet1.GetRow(13 + 2).GetCell(0).SetCellValue("A3口泄漏流量（ml/min）"); sheet1.GetRow(13 + 2).GetCell(2).SetCellValue(lf8);
            sheet1.GetRow(13 + 2).GetCell(4).SetCellValue("测试压力(bar)"); sheet1.GetRow(13 + 2).GetCell(6).SetCellValue(p8);
            sheet1.GetRow(14 + 2).GetCell(0).SetCellValue("B4口泄漏流量（ml/min）"); sheet1.GetRow(14 + 2).GetCell(2).SetCellValue(lf9);
            sheet1.GetRow(14 + 2).GetCell(4).SetCellValue("测试压力(bar)"); sheet1.GetRow(14 + 2).GetCell(6).SetCellValue(p9);
            sheet1.GetRow(15 + 2).GetCell(0).SetCellValue("A4口泄漏流量（ml/min）"); sheet1.GetRow(15 + 2).GetCell(2).SetCellValue(lf10);
            sheet1.GetRow(15 + 2).GetCell(4).SetCellValue("测试压力(bar)"); sheet1.GetRow(15 + 2).GetCell(6).SetCellValue(p10);
            sheet1.GetRow(16 + 2).GetCell(0).SetCellValue("转向优先阀测试");
            sheet1.GetRow(17 + 2).GetCell(0).SetCellValue("液压泵流量（l/min）"); sheet1.GetRow(17 + 2).GetCell(2).SetCellValue(f111);
            sheet1.GetRow(17 + 2).GetCell(4).SetCellValue("转向流量（ml/min）"); sheet1.GetRow(17 + 2).GetCell(6).SetCellValue(sf1);
            sheet1.GetRow(18 + 2).GetCell(0).SetCellValue("倾斜阀测试");
            sheet1.GetRow(19 + 2).GetCell(0).SetCellValue("前倾进油压力损失(bar)"); sheet1.GetRow(19 + 2).GetCell(2).SetCellValue(fil);
            sheet1.GetRow(19 + 2).GetCell(4).SetCellValue("回油压力损失(bar)"); sheet1.GetRow(19 + 2).GetCell(6).SetCellValue(fol);
            sheet1.GetRow(20 + 2).GetCell(0).SetCellValue("后倾进油压力损失(bar)"); sheet1.GetRow(20 + 2).GetCell(2).SetCellValue(filb);
            sheet1.GetRow(20 + 2).GetCell(4).SetCellValue("回油压力损失(bar)"); sheet1.GetRow(20 + 2).GetCell(6).SetCellValue(folb);
            sheet1.GetRow(21 + 2).GetCell(0).SetCellValue("前倾测试流量（l/min）"); sheet1.GetRow(21 + 2).GetCell(2).SetCellValue(f11111);
            sheet1.GetRow(21 + 2).GetCell(4).SetCellValue("后倾测试流量（l/min）"); sheet1.GetRow(21 + 2).GetCell(6).SetCellValue(f111111);
            // sheet1.GetRow(12).GetCell(0).SetCellValue("后倾压力损失(bar)");
            //sheet1.GetRow(12).GetCell(4).SetCellValue("测试流量（l/min）");
            sheet1.GetRow(22 + 2).GetCell(0).SetCellValue("前倾口内泄漏流量（ml/min）"); sheet1.GetRow(22 + 2).GetCell(2).SetCellValue(lf11);
            sheet1.GetRow(22 + 2).GetCell(4).SetCellValue("测试压力(bar)"); sheet1.GetRow(22 + 2).GetCell(6).SetCellValue(p111);
            sheet1.GetRow(23 + 2).GetCell(0).SetCellValue("后倾口内泄漏流量（ml/min）"); sheet1.GetRow(23 + 2).GetCell(2).SetCellValue(lf111);
            sheet1.GetRow(23 + 2).GetCell(4).SetCellValue("测试压力(bar)"); sheet1.GetRow(23 + 2).GetCell(6).SetCellValue(p1111);
            // sheet1.GetRow(15).GetCell(0).SetCellValue("前倾滑阀最大推力(N)");
            // sheet1.GetRow(15).GetCell(4).SetCellValue("后倾滑阀最大推力(N)");
            sheet1.GetRow(24 + 2).GetCell(0).SetCellValue("前倾自锁泄漏流量(ml/min）"); sheet1.GetRow(24 + 2).GetCell(2).SetCellValue(lf1);
            sheet1.GetRow(24 + 2).GetCell(4).SetCellValue("自锁上升回程位移(mm)"); sheet1.GetRow(24 + 2).GetCell(6).SetCellValue(ud);
            sheet1.GetRow(25 + 2).GetCell(0).SetCellValue("自锁前倾回程位移(mm)"); sheet1.GetRow(25 + 2).GetCell(2).SetCellValue(fd);
            sheet1.GetRow(25 + 2).GetCell(4).SetCellValue("自锁后倾回程位移(mm)"); sheet1.GetRow(25 + 2).GetCell(6).SetCellValue(bd);
            sheet1.GetRow(26 + 2).GetCell(0).SetCellValue("升降阀测试");
            sheet1.GetRow(27 + 2).GetCell(0).SetCellValue("上升压力损失(bar)"); sheet1.GetRow(27 + 2).GetCell(2).SetCellValue(upl1);
            sheet1.GetRow(27 + 2).GetCell(4).SetCellValue("测试流量（l/min）"); sheet1.GetRow(27 + 2).GetCell(6).SetCellValue(f111);
            sheet1.GetRow(28 + 2).GetCell(0).SetCellValue("下降压力损失(bar)"); sheet1.GetRow(28 + 2).GetCell(2).SetCellValue(udl1);
            sheet1.GetRow(28 + 2).GetCell(4).SetCellValue("测试流量（l/min）"); sheet1.GetRow(28 + 2).GetCell(6).SetCellValue(f1111);
            sheet1.GetRow(29 + 2).GetCell(0).SetCellValue("升口内泄漏流量（ml/min）"); sheet1.GetRow(29 + 2).GetCell(2).SetCellValue(lf1111);
            sheet1.GetRow(29 + 2).GetCell(4).SetCellValue("测试压力(bar)"); sheet1.GetRow(29 + 2).GetCell(6).SetCellValue(p11111);
            // sheet1.GetRow(21).GetCell(0).SetCellValue("上升滑阀最大推力(N)"); sheet1.GetRow(22).GetCell(2).SetCellValue(foi1);
            // sheet1.GetRow(21).GetCell(4).SetCellValue("下降滑阀最大推力(N)"); sheet1.GetRow(22).GetCell(6).SetCellValue(foo1);
            sheet1.GetRow(30 + 2).GetCell(0).SetCellValue("中位压力损失测试"); 
            sheet1.GetRow(31 + 2).GetCell(0).SetCellValue("中位压力损失（bar）"); sheet1.GetRow(31 + 2).GetCell(2).SetCellValue(mpl);
            sheet1.GetRow(31 + 2).GetCell(4).SetCellValue("测试流量（l/min）"); sheet1.GetRow(31 + 2).GetCell(6).SetCellValue(f1111111);
            sheet1.GetRow(34).GetCell(0).SetCellValue("备用阀中位泄漏测试");
            sheet1.GetRow(35).GetCell(0).SetCellValue("B3口内泄漏流量（ml/min）"); sheet1.GetRow(35).GetCell(2).SetCellValue(lfb1);
            sheet1.GetRow(35).GetCell(4).SetCellValue("测试压力（bar）"); sheet1.GetRow(35).GetCell(6).SetCellValue(p1b1);
            sheet1.GetRow(36).GetCell(0).SetCellValue("A3口内泄漏流量（ml/min）"); sheet1.GetRow(36).GetCell(2).SetCellValue(lfb2);
            sheet1.GetRow(36).GetCell(4).SetCellValue("测试压力（bar）"); sheet1.GetRow(36).GetCell(6).SetCellValue(p1b2);
            sheet1.GetRow(37).GetCell(0).SetCellValue("B4内泄漏流量（ml/min）"); sheet1.GetRow(37).GetCell(2).SetCellValue(lfb3);
            sheet1.GetRow(37).GetCell(4).SetCellValue("测试压力（bar）"); sheet1.GetRow(37).GetCell(6).SetCellValue(p1b3);
            sheet1.GetRow(38).GetCell(0).SetCellValue("A4内泄漏流量（ml/min）"); sheet1.GetRow(38).GetCell(2).SetCellValue(lfb4);
            sheet1.GetRow(38).GetCell(4).SetCellValue("测试压力（bar）"); sheet1.GetRow(38).GetCell(6).SetCellValue(p1b4);
            //合并单元格、设置style
            for (int i = 0; i <= 38; i++)
            {
                if (i == 0 | i == 3 | i == 10 | i == 20 | i == 28 | i == 32 | i == 18 |i==34)
                {
                    sheet1.AddMergedRegion(new CellRangeAddress(i, i, 0, 7));
                    for (int j = 0; j <= 7; j++)
                    {
                        if (i == 0)
                        {
                            sheet1.GetRow(0).GetCell(j).CellStyle = style;
                        }
                        else
                        {
                            sheet1.GetRow(i).GetCell(j).CellStyle = style1;
                        }
                    }
                }

                else
                {
                    sheet1.AddMergedRegion(new CellRangeAddress(i, i, 0, 1));
                    sheet1.AddMergedRegion(new CellRangeAddress(i, i, 2, 3));
                    sheet1.AddMergedRegion(new CellRangeAddress(i, i, 4, 5));
                    sheet1.AddMergedRegion(new CellRangeAddress(i, i, 6, 7));
                    for (int j = 0; j < 8; j++)
                    {
                        sheet1.GetRow(i).GetCell(j).CellStyle = style2;
                    }
                }

            }
        }
        /// <summary>
        /// 转换DataSet中每张datatable数据为Excel表格
        /// </summary>
        /// <param name="ds"></param>
        public void ConvertTableToExcel(DataSet ds)
        {
            foreach (DataTable dt in ds.Tables)
            {
                ConvertTableToExcel(dt);
            }
        }

        /// <summary>
        /// 生成Excel文件
        /// </summary>
        /// <param name="filePath"></param>
        public void WriteToFile(FileStream fileStream)
        {
            workBook.Write(fileStream);
            fileStream.Close();
        }
        //用于直接在historydata中打印表格
        public void WriteToFile2(FileStream fileStream)
        {
            workBook2.Write(fileStream);
            fileStream.Close();
        }

    }
}
