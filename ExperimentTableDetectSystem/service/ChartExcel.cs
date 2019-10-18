using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExperimentTableDetectSystem.service
{
    class ChartExcel
    {
        HSSFWorkbook wb;
        public ChartExcel()
        {
            wb = new HSSFWorkbook(new FileStream(@"C:\工作簿1.xls", FileMode.Open));
        }
        public void Excel()
        {

            HSSFSheet sheet1 = (HSSFSheet)wb.GetSheet("sheet1");
            HSSFRow row = (HSSFRow)sheet1.CreateRow(1);
            row.CreateCell(0).SetCellValue(1);
            row.CreateCell(1).SetCellValue(1);
            HSSFRow row2 = (HSSFRow)sheet1.CreateRow(2);
            row2.CreateCell(0).SetCellValue(2);
            row2.CreateCell(1).SetCellValue(4);


        }
        public void Write(FileStream fileStream)
        {
            wb.Write(fileStream);
            fileStream.Close();
        }
    }
}
