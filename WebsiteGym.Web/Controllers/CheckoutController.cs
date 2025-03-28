using System.Web.Mvc;

namespace WebsiteGym.Web.Controllers
{
    public class CheckoutController : Controller
    {
        public ActionResult CheckoutMembership()
        {
            return View("CheckoutMembership");
        }

        public ActionResult TermsAndConditions()
        {
            return View("TermsAndConditions");
        }
    }
}