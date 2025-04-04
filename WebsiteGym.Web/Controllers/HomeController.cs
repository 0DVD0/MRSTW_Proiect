using System.Web.Mvc;
using WebsiteGym.Web.Models;

namespace WebsiteGym.Web.Controllers
{
    public class HomeController : Controller
    {
          [HttpGet]
          public ActionResult AuthPage()
          {
               return View("AuthPage", new AuthPageModel());
          }
          public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Membership()
        {
            return View();
        }
    }
}