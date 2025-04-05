using System.Web.Mvc;
using eUseControl.BusinessLogic.Interface;
using WebsiteGym.Web.Models;
using eUseControl.BusinessLogic.Core;
using eUseControl.Domain.Entities;
using System;
using System.Collections.Generic;

namespace WebsiteGym.Web.Controllers
{
    public class CheckoutController : Controller
    {
     
        [HttpPost]
        public ActionResult CheckoutOrder(OrderViewModel model)
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
