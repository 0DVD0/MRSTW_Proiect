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
            return View("PersonalTraining");
        }

        public ActionResult GroupPrograms()
        {
            return View("GroupPrograms");
        }

        public ActionResult NutritionCoachings()
        {
            return View("NutritionCoaching");
        }
    }
}