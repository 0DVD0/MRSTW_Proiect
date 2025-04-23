using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;
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


        private readonly IMembershipApi _membership;

        public AdminController()
        {
            var bl = new BussinesLogic();
            _membership = bl.GetMembershipApi();
        }

        public ActionResult ManageMemberships()
        {
            using (var context = new MembershipContext())
            {
                var memberships = _membership.GetAllMemberships();

                var model = new MembershipViewModel
                {
                    Memberships = memberships 
                };

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult AddMembership(MembershipViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Price < 0)
                {
                    ModelState.AddModelError("Price", "Price cannot be negative.");
                }

                if (ModelState.IsValid)
                {
                    _membership.CreateMembership(model.MembershipName, model.Price, model.Details);

                    return RedirectToAction("ManageMemberships");
                }
            }

            var memberships = _membership.GetAllMemberships();
            model.Memberships = memberships;

            return View("ManageMemberships", model);
        }


        [HttpGet]
        public ActionResult UpdateMembership(int id)
        {
            var membership = _membership.GetMembershipById(id); 
            if (membership == null)
                return HttpNotFound();

            var viewModel = new MembershipViewModel
            {
                Id = membership.Id,
                MembershipName = membership.MembershipName,
                Price = membership.Price,
                Details = membership.Details
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditMembership(MembershipViewModel model)
        {
            if (ModelState.IsValid)
            {
                _membership.UpdateMembership(model.Id, model.MembershipName, model.Price, model.StartDate, model.EndDate);

                return RedirectToAction("ManageMemberships");
            }

            return View(model);
        }

        public ActionResult DeleteMembership(int id)
        {
            _membership.RemoveMembership(id);
            return RedirectToAction("ManageMemberships");
        }

    }
}