using System.Web.Mvc;
using eUseControl.BusinessLogic.Interface;
using WebsiteGym.Web.Models;
using eUseControl.BusinessLogic.Core;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;
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
                    return View("Auth", model);
               }
               else
               {
                    var user = new User
                    {
                         Name = model.Register.UserName,
                         Email = model.Register.Email,
                         Password = model.Register.Password,
                         Role = UserRoles.User,
                    };

                    var userService = new UserServices();
                    bool result = userService.RegisterUser(user);

                    if (result)
                    {
                         return RedirectToAction("Auth", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", "User already exists");
                         return View("Auth", model);
                    }
               }
          }
          [HttpPost]
        public ActionResult Login(AuthPageModel model)
        {
               if (!ModelState.IsValid) {
                    ModelState.AddModelError("", "Invalid data");
                    return View("Auth");
               }
               else
               {
                    var user = new User
                    {
                         Name = model.Login.UserName,
                         Password = model.Login.Password,
                    };
                    var userService = new UserServices();
                    bool result = userService.LoginUser(user);
                    if (result)
                    {
                         Session["User"] = user;
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", "Invalid username or password");
                         return View("Auth");
                    }
               }
        }
    }
}