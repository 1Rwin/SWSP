using SWSPapp.Services;
using System.Web.Mvc;

namespace SWSPapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [Auth]
        public ActionResult Search()
        {
            var data = new StatisticsService().GetPlayersInfo();
            return View(data);
        }

        [HttpPost]
        public void AddFavorite(int idPlayer)
        {
            //update favorite
         
          
        }

        [HttpPost]
        public void RemoveFavorite(int idPlayer)
        {
            //update favorite 

        }

    }
}