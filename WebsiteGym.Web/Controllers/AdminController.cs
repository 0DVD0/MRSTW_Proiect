using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using eUseControl.BusinessLogic.DBModel;
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

        public ActionResult ManageMemberships()
        {
            using (var context = new MembershipContext())
            {
                var memberships = context.Memberships.ToList();

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
                    using (var context = new MembershipContext())
                    {
                        var newMembership = new MDbTable
                        {
                            MembershipName = model.MembershipName,
                            Price = model.Price,
                            Details = model.Details
                        };

                        context.Memberships.Add(newMembership);
                        context.SaveChanges();
                    }

                    return RedirectToAction("ManageMemberships");
                }
            }

            using (var context = new MembershipContext())
            {
                model.Memberships = context.Memberships.ToList(); 
            }

            return View("ManageMemberships", model);
        }



    }
}