using System.Web.Mvc;
using eUseControl.BusinessLogic.DBModel;
using WebsiteGym.Web.Models;
using System.Linq;
using System.Diagnostics;

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
            var topMemberships = _context.Memberships.Take(3).ToList();
            return View(topMemberships);
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

        private readonly MembershipContext _context = new MembershipContext();

        public ActionResult Membership()
        {
            var memberships = _context.Memberships.ToList();
            return View(memberships); 
        }

        public ActionResult ShowTopMemberships()
        {
            var topMemberships = _context.Memberships.Take(3).ToList();
            return View(topMemberships);  
        }

    }
}