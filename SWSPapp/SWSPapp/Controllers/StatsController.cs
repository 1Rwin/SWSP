using SWSPapp.Services;
using System.Web.Mvc;

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
    }
}