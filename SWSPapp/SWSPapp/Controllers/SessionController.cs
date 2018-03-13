using SWSPapp.Models;
using SWSPapp.Services;
using System.Web.Mvc;

namespace SWSPapp.Controllers
{
    public class SessionController : Controller
    {     
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {

            if (ModelState.IsValid)
            {
                var user = LoginService.SignIn(userModel);
                if (user != null)
                {
                    SessionPersister.User = user;
                    return RedirectToAction("Search", "Home");
                }  
                else
                {
                    ViewBag.Error = "Niepoprawne dane logowania";
                    return View(userModel);
                }
            }
            else
            {               
                return View(userModel);
            }

        }
        public ActionResult Logout()
        {
            SessionPersister.User = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LostPassword()
        {
            return View();
        }


    }
}