using OfficeOpenXml;
using SWSPapp.Models;
using System.Collections.Generic;

namespace SWSPapp.Services
{
    public class ExcelService
    {
        public static ExcelPackage PrepareExcelFile(List<StatisticBasicModel> dataCollection)
        {
            ExcelPackage excel = new ExcelPackage();
            // Do something to populate your workbook            
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");

            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Cells[1, 1].Value = "Lp";
            workSheet.Cells[1, 2].Value = "Id";
            workSheet.Cells[1, 3].Value = "Attack";
            workSheet.Cells[1, 4].Value = "Dribble";

            int recordIndex = 2;
            foreach (var data in dataCollection)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = data.IdPlayer;
                workSheet.Cells[recordIndex, 3].Value = data.Attack;
                workSheet.Cells[recordIndex, 4].Value = data.Dribble;
                recordIndex++;
            }

            return excel;
        }
    }
}