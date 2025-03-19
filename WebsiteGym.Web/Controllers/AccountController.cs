using eUseControl.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteGym.Web.Controllers
{
    public class AccountController : Controller
    {
          private readonly IUserServices _userService;
          public AccountController(IUserServices userService)
          {
               _userService = userService;
          }
          public ActionResult Login()
        {
            return View();
        }

          // Register user
          [HttpPost]
          public ActionResult Register(string name, string email, string password)
          {
               bool isRegistered = _userService.RegisterUser(name, email, password);
               if (isRegistered)
               {
                    return RedirectToAction("Login");
               }
               return View();
          }

     }
}