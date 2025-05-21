using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteGym.Web.Controllers
{
    public class ServicesController : Controller
    {
        public ActionResult PersonalTraining()
        {
            return View();
        }

        public ActionResult GroupPrograms()
        {
            return View();
        }

        public ActionResult NutritionCoaching()
        {
            return View();
        }
    }
}