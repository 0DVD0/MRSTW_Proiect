using System.Web.Mvc;
using WebsiteGym.Web.Models;
using eUseControl.BusinessLogic.Core;
using eUseControl.Domain.Enums;
using System;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities.Order;

namespace WebsiteGym.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrderApi _order;
        public CheckoutController()
        {
            var bl = new BussinesLogic();
            _order = bl.GetOrderApi();
        }

        // GET: Checkout/CheckoutMembership
        public ActionResult CheckoutMembership(int? membershipId)
        {
            var model = new OrderViewModel();

            if (membershipId.HasValue)
            {
                model.MembershipName = membershipId.Value;
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

            var orderData = new NewOrderDto()
            {
                Id = model.OrderId,
                membershipName = model.MembershipName,
                orderDate = model.OrderDate,
                totalPrice = model.TotalPrice,
                userName = model.UserName

            };

            bool result = _order.CreateOrder(orderData);

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
