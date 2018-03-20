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

        [Auth]
        public ActionResult BasePage()
        {
            return View();
        }

        [Auth]
        public ActionResult Search()
        {
            var data = new StatisticsService().GetPlayersInfo(SessionPersister.User.Id);
            return View(data);
        }

        [Auth]
        [HttpPost]
        public void AddFavorite(int idPlayer)
        {         
            new StatisticsService().AddPlayerToFavorites(SessionPersister.User.Id, idPlayer);                  
        }

        [Auth]
        [HttpPost]
        public void RemoveFavorite(int idPlayer)
        {            
            new StatisticsService().RemovePlayerFromFavorites(SessionPersister.User.Id, idPlayer);
        }

        [Auth]
        public ActionResult About()
        {
            return View();
        }

    }
}