using System.Web.Mvc;
using WebsiteGym.Web.Models;
using eUseControl.BusinessLogic.Core;
using eUseControl.Domain.Enums;
using System;

namespace WebsiteGym.Web.Controllers
{
    public class CheckoutController : Controller
    {

        // GET: Checkout/CheckoutMembership
        public ActionResult CheckoutMembership(int? membershipId, int? duration)
        {
            var model = new OrderViewModel();

            if (membershipId.HasValue)
            {
                model.MembershipId = membershipId.Value;
            }

            if (duration.HasValue)
            {
                model.Duration = duration.Value;
            }

            return View(model);
        }


        [HttpPost]
        public ActionResult CheckoutMembership(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid order data");
                return View("CheckoutMembership", model);
            }

            var orderService = new AdminApi(); 
            bool result = orderService.CreateOrder(
                model.OrderId,
                model.MembershipId,
                model.OrderDate,
                model.TotalPrice,
                model.UserId
            );

            if (result)
            {
                return RedirectToAction("OrderSuccess"); //TODO: To add View cu Oder success sau sa redirectioneze pe pagina utilizatorului in care sa-i arate ceeeeeee abonamente are
            }
            else
            {
                ModelState.AddModelError("", "Failed to create order");
                return View("CheckoutMembership", model);
            }
        }


        // GET: Checkout
        public ActionResult OrderSuccess()
        {
            return View("OrderSuccess");
        }

    }
}
