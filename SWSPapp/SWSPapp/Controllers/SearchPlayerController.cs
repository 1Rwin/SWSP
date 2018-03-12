using System.Collections.Generic;
using System.Web.Mvc;

namespace SWSPapp.Controllers
{
    public class SearchPlayerController : Controller
    {
        // GET: SearchPlayer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchPlayer(int page=1, string sort = "Name", string sortdir="asc", string search="")
        {
            int pagesize = 10;
            int totalrecord = 0;
            if (page < 1) page = 1;
            int skip = (page + pagesize) - pagesize;
            var data = GetPalyerStats(search, sort, sortdir, skip, pagesize, out totalrecord);
            return View(data);
        }

        public List<SearchPlayerController> GetPalyerStats(string search, string sort, string sortdir, int skip, int pagesize, out int totalRecord)
        {
            totalRecord = 0;
            return null;

            //nie commituj nie kompilującego się kodu

            //using (SWSPContext db = new SWSPContext())
            //{
            //    var v = (from a in db.players_statistics
            //             where
            //             a.attack.ToString().Contains(search) ||
            //             a.speed.ToString().Contains(search) ||
            //             a.weight.ToString().Contains(search) ||
            //             a.height.ToString().Contains(search) ||
            //             a.dribble.ToString().Contains(search) ||
            //             a.passing.ToString().Contains(search) ||
            //             a.defense.ToString().Contains(search) ||
            //             a.endurance.ToString().Contains(search)

            //             select a);
            //    totalRecord = v.Count();
            //    v = v.OrderBy(sort + "" + sortdir);
            //    if (pagesize >0)
            //    {
            //        v = v.Skip(skip).Take(pagesize);
            //    }
            //    return v.ToList();
            //}
        }
    }
}