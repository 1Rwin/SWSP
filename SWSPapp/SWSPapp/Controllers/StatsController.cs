using SWSPapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWSPapp.Controllers
{
    public class StatsController : Controller
    {
        // GET: Stats
        [Auth]
        public ActionResult Index()
        {
            return View();
        }

        [Auth]
        [HttpGet]
        public JsonResult GetPlayersForUser()
        {
            var data = new StatisticsService().GetPlayersForUser();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [Auth]
        [HttpGet]
        public JsonResult GetStats2(int idPlayer = 1)
        {
            var data = new StatisticsService().GetReportForPlayerLineChart(idPlayer);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [Auth]
        [HttpGet]
        public JsonResult GetStats(int idPlayer = 1)
        {
            var data = new StatisticsService().GetReportForPlayer(idPlayer);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [Auth]
        public ActionResult NewReport()
        {
            return View();
        }

        public ActionResult OldReport()
        {
            return View();
        }

    }
}