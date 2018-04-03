using SWSPapp.Services;
using System.IO;
using System.Web.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using SWSPapp.Models;

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