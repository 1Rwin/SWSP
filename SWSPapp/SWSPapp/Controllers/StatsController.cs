﻿using SWSPapp.Services;
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
        public ActionResult OldReport()
        {
            return View();
        }
        public ActionResult NewReport()
        {
            return View();
        }
    }
}