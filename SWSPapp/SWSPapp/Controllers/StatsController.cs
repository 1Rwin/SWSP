using SWSPapp.Services;
using System.IO;
using System.Web.Mvc;
using OfficeOpenXml;
using System;

namespace SWSPapp.Controllers
{
    [Auth]
    public class StatsController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RadarReport()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetStatsRadar(int idPlayer)
        {
            var data = new StatisticsService().GetReportForPlayer(idPlayer);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetPlayersForUser()
        {
            var data = new StatisticsService().GetPlayersForUser();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetStatsLineChart(int idPlayer)
        {
            var data = new StatisticsService().GetReportForPlayerLineChart(idPlayer);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ExportToExcel(int idPlayer)
        {
            var dataCollection = new StatisticsService().GetReportForPlayerLineChart(idPlayer);

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
                // Problem - Log the error, generate a blank file,
                //           redirect to another controller action - whatever fits with your application
                return new EmptyResult();
            }
        }


    }
}