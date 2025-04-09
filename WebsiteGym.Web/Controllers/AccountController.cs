using System.Web.Mvc;
using eUseControl.BusinessLogic.Interface;
using WebsiteGym.Web.Models;
using eUseControl.BusinessLogic.Core;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;
using System;
namespace WebsiteGym.Web.Controllers
{
     public class AccountController : Controller
     {

          [HttpPost]
          public ActionResult Register(AuthPageModel model)
          { 
               if (!ModelState.IsValid)
               {
                    ModelState.AddModelError("", "Invalid data");
                    return View("~/Views/Home/AuthPage.cshtml", model);
               }
               else
               {
                    var user = new User
                    {
                         Name = model.Register.UserName,
                         Email = model.Register.Email,
                         Password = model.Register.Password,
                         Role = UserRoles.User,
                         ReggisterDateTime = DateTime.Now,
                         MembershipStatus = false,
                    };

                    var userService = new UserServices();
                    bool result = userService.RegisterUser(user);

                    if (result)
                    {
                         return RedirectToAction("AuthPage", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", "User already exists");
                         return View("~/Views/Home/AuthPage.cshtml", model);
                    }
               }
          }
          [HttpPost]
        public ActionResult Login(AuthPageModel model)
        {
               if (!ModelState.IsValid) {
                    ModelState.AddModelError("", "Invalid data");
                    return View("~/Views/Home/AuthPage.cshtml", model);
               }
               else
               {
                    var user = new User
                    {
                         Name = model.Login.UserName,
                         Password = model.Login.Password,
                    };
                    var userService = new UserServices();
                    var foundUser = userService.LoginUser(user);
                    if (foundUser != null)
                    {
                              Session["UserName"] = foundUser.Name;
                              Session["UserRole"] = foundUser.Role;
                         
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", "Invalid username or password");
                         return View("~/Views/Home/AuthPage.cshtml", model);
                    }
               }
        }
    }
}