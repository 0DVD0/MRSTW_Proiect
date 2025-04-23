using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Membership;
using WebsiteGym.Web.Models;


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
               using (var context = new UserContext())
               {
                    var users = context.Users.ToList();
                    ViewBag.Users = users;
               }
               return View();
          }

          public ActionResult DeleteUser(int id)
          {
               using (var context = new UserContext())
               {
                    var user = context.Users.FirstOrDefault(u => u.Id == id);
                    if (user != null)
                    {
                         context.Users.Remove(user);
                         context.SaveChanges();
                    }
               }
               return RedirectToAction("ListOfUsers");
          }









        private readonly IOrderApi _order;

        public AdminController()
        {
            var bl = new BussinesLogic();

            _order = bl.GetOrderApi();

            _membership = bl.GetMembershipApi();
        }


        public ActionResult ManageDiscountCodes()
        {
            using (var context = new DiscountContext())
            {
                var discountList = context.DiscountCodes.ToList();

                var model = new DiscountViewModel
                {
                    DiscountCodes = discountList
                };

                return View(model);
            }
        }


        [HttpGet]
        public ActionResult AddDiscountCode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDiscountCode(DiscountDbTable model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new DiscountContext())
                {
                    context.DiscountCodes.Add(model);
                    context.SaveChanges();
                }
                return RedirectToAction("ManageDiscountCodes");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult EditDiscountCode(int id)
        {
            using (var context = new DiscountContext())
            {
                var discountCode = context.DiscountCodes.FirstOrDefault(d => d.Id == id);
                if (discountCode == null)
                {
                    return HttpNotFound();
                }

                return View(discountCode);
            }
        }

        [HttpPost]
        public ActionResult EditDiscountCode(DiscountDbTable model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new DiscountContext())
                {
                    var discountCode = context.DiscountCodes.FirstOrDefault(d => d.Id == model.Id);
                    if (discountCode != null)
                    {
                        discountCode.DiscountCode = model.DiscountCode;
                        discountCode.DiscountPercentage = model.DiscountPercentage;
                        context.SaveChanges();
                    }
                }

                return RedirectToAction("ManageDiscountCodes");
            }

            return View(model);
        }

        public ActionResult DeleteDiscountCode(int id)
        {
            using (var context = new DiscountContext())
            {
                var discountCode = context.DiscountCodes.FirstOrDefault(d => d.Id == id);
                if (discountCode != null)
                {
                    context.DiscountCodes.Remove(discountCode);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("ManageDiscountCodes");
        }














        private readonly IMembershipApi _membership;


        public ActionResult ManageMemberships()
        {
            var model = new MembershipViewModel
            {
                Memberships = _membership.GetAllMemberships()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ManageMemberships(MembershipViewModel model)
        {
            if (!ModelState.IsValid)
            { 
                model.Memberships = _membership.GetAllMemberships(); 
                return View(model);
            }

            var dto = new NewMembershipDto
            {
                membershipName = model.MembershipName,
                price = model.Price,
                details = model.Details
            };

            _membership.CreateMembership(dto);  

            model.MembershipName = string.Empty;
            model.Price = 0;
            model.Details = string.Empty;

            model.Memberships = _membership.GetAllMemberships();

            return View(model);
        }


        [HttpGet]
        public ActionResult EditMembership(int id)
        {
            var dto = new NewMembershipDto { Id = id };
            var existing = _membership.GetMembershipById(dto);

            if (existing == null)
                return HttpNotFound();

            var model = new MembershipViewModel
            {
                Id = existing.Id,
                MembershipName = existing.MembershipName,
                Price = existing.Price,
                Details = existing.Details
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditMembership(MembershipViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = new NewMembershipDto
            {
                Id = model.Id,
                membershipName = model.MembershipName,
                price = model.Price,
                details = model.Details
            };

            _membership.EditMembership(dto); 
            return RedirectToAction("ManageMemberships");
        }

        public ActionResult DeleteMembership(int id)
        {
            _membership.RemoveMembership(new NewMembershipDto { Id = id }); 
            return RedirectToAction("ManageMemberships");
        }

    }
}