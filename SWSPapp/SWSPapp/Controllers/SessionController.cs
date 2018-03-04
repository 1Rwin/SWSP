using SWSPapp.Models;
using SWSPapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWSPapp.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            var user = LoginService.Log_In(userModel);
            if(user != null)
            {
                SessionPersister.User = user;
                return RedirectToAction("Stats", "Session");
            }
            else
            {
                ViewBag.Error = "Niepoprawne dane logowania";
                return View(user);
            }
           
        }


    }
}