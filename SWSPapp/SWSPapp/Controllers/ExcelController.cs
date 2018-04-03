using OfficeOpenXml;
using SWSPapp.Services;
using System;
using System.IO;
using System.Web.Mvc;

namespace SWSPapp.Controllers
{
    [Auth]
    public class ExcelController : Controller
    {
        [HttpPost]
        public JsonResult ExportToExcel(int idPlayer)
        {
            var dataCollection = new StatisticsService().GetReportForPlayerLineChart(idPlayer);
            ExcelPackage excel = ExcelService.PrepareExcelFile(dataCollection);

            // Generate a new unique identifier against which the file can be stored
            string handle = Guid.NewGuid().ToString();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                excel.SaveAs(memoryStream);
                memoryStream.Position = 0;
                TempData[handle] = memoryStream.ToArray();
            }

            // Note we are returning a filename as well as the handle
            return new JsonResult()
            {
                Data = new { FileGuid = handle, FileName = "TestReportOutput.xlsx" }
            };
        }

        [HttpGet]
        public virtual ActionResult Download(string fileGuid, string fileName)
        {
            if (TempData[fileGuid] != null)
            {
                byte[] data = TempData[fileGuid] as byte[];
                return File(data, "application/vnd.ms-excel", fileName);
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}