using ExperimentTableDetectSystem.NPOI;
using ExperimentTableDetectSystem.Windows.ExperimentData;
using ExperimentTableDetectSystem.Windows.manual;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.service
{

    public class ExportToExcel
    {/// <summary>
     /// 导出excel文件
     /// </summary>
     /// <param name="sql">sql语句，为查询表的语句</param>
     /// <param name="path">保存excel文件的路径</param>


        public static void ExportData1(DataTable dt)
        {
            NPOIHelper npoi = new NPOIHelper();
            string id1 = HistoryDataWin.productId;
            int n1 = HistoryDataWin.N;
            try
            {
                npoi.ConvertTableToExcel(dt);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel文件|*.xls";

                saveFileDialog.FileName = id1 + "的第" + n1 + "次测试";
               // saveFileDialog.FileName = ConvertToString(DateTime.Now);
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                    npoi.WriteToFile2(fs);
                    MessageBox.Show("表" + dt.TableName + "生成成功");
                    // LoggerHelper.Log("导出界面", dt.TableName + "导出为Excel");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static void ExportData2(DataTable dt)
        {
            NPOIHelper npoi = new NPOIHelper();
            string id2 = HistoryDataWin2.ProductId;
            int n2 = HistoryDataWin2.NN;
            try
            {
                npoi.ConvertTableToExcel(dt);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel文件|*.xls";

                saveFileDialog.FileName = id2 + "的第" + n2 + "次测试";
                // saveFileDialog.FileName = ConvertToString(DateTime.Now);
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                    npoi.WriteToFile(fs);
                    MessageBox.Show("表" + dt.TableName + "生成成功");
                    // LoggerHelper.Log("导出界面", dt.TableName + "导出为Excel");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static void ExportDataTest(DataTable dt)
        {
            NPOIHelper npoi = new NPOIHelper();

            try
            {
                npoi.CreateExcelTest(dt);
                string id = ManualNumberInput.id;
                int n = ManualNumberInput.n;
                string company = ManualNumberInput.company;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel文件|*.xls";

                saveFileDialog.FileName = id + "的第" + n + "次测试报告（发往公司：" + company + ")";
                // saveFileDialog.FileName = ConvertToString(DateTime.Now);
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                    npoi.WriteToFile(fs);
                    MessageBox.Show("表" +/* dt.TableName +*/ "生成成功");
                    // LoggerHelper.Log("导出界面", dt.TableName + "导出为Excel");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void ExcelChart()
        {
            ChartExcel ch = new ChartExcel();
            try
            {
                ch.Excel();

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel文件|*.xls";
                saveFileDialog.FileName = "测试成图";
                // saveFileDialog.FileName = ConvertToString(DateTime.Now);
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                    ch.Write(fs);
                    MessageBox.Show("表" +/* dt.TableName +*/ "生成成功");
                    // LoggerHelper.Log("导出界面", dt.TableName + "导出为Excel");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private static string ConvertToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH-mm-ss ");
        }
    }
}



