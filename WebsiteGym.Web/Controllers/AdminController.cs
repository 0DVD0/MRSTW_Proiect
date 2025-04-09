using System.Linq;
using System.Web.Mvc;
using eUseControl.BusinessLogic.DBModel;     

namespace WebsiteGym.Web.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminDash()
        {
               using (var context = new UserContext())
               {
                    ViewBag.Users = context.Users.Count();
               }
               
                    return View();
        }
          public ActionResult ListOfUsers()
          {
               return View();
          }
    }
}