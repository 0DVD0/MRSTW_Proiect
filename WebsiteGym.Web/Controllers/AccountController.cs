using System.Web.Mvc;
using eUseControl.BusinessLogic.Interface;

namespace WebsiteGym.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
    }
}