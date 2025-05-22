using System.Web.Mvc;
using eUseControl.BusinessLogic.Interface;
using WebsiteGym.Web.Models;
using eUseControl.BusinessLogic.Core;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;
using System;
using System.Runtime.Remoting.Messaging;
using System.IO;
using System.Web;
namespace WebsiteGym.Web.Controllers
{
     public class AccountController : Controller
     {
          private readonly IUserServices _userServices;

          public AccountController()
          {
               var bl = new BussinesLogic();
               _userServices = bl.GetUserApi();
          }

          public ActionResult UserDashboard()
          {
               if (Session["UserRole"]?.ToString() == "Admin")
               {
                    return RedirectToAction("AdminDashboard", "Admin");
               }
               else if (Session["UserRole"]?.ToString() == "User")
               {
                    int userId = (int)Session["UserId"];
     
                    var user = _userServices.GetUserById(userId);
                    UserMembership userMembership = null;
                    if (user != null)
                    {
                         if (user.UserMembershipID != null && user.MembershipStatus)
                         {
                              userMembership = _userServices.GetUserMembershipById((int)user.UserMembershipID);
                              if (userMembership != null && userMembership.MembershipExperationDate.Date <= DateTime.Now)
                              {
                                   _userServices.RemoveUserMembership(userMembership.Id);
                                   user.UserMembershipID = null;
                                   user.MembershipStatus = false;
                                   userMembership = null;
                              }
                         }
                         var model = new UserDashDto
                         {
                              UserName = user.Name,
                              Email = user.Email,
                              MembershipStatus = user.MembershipStatus,
                              RegisterDateTime = user.ReggisterDateTime,
                              MembershipExpiration = userMembership?.MembershipExperationDate,
                              MembershipType = userMembership?.MembershipType,
                              MembershipPurchaseDate = userMembership?.MembershipPurchaseDate,
                              QrCodeImage = userMembership?.QrCodeImage,
                              ProfilePicture = user.ProfilePicture,
                              FullName = user.FullName,
                              PhoneNumber = user.PhoneNumber,
                         };
                         return View(model);
                    }
                    else
                    {
                         ModelState.AddModelError("", "User not found");
                         return RedirectToAction("AuthPage", "Home");
                    }
               }
               else
               {
                    return RedirectToAction("AuthPage", "Home");
               }
          }
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
                         UserMembershipID = null,

                    };

                    bool result = _userServices.RegisterUser(user);

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

               if (!ModelState.IsValid)
               {
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
                    var foundUser = _userServices.LoginUser(user);
                    if (foundUser != null)
                    {
                         Session["UserId"] = foundUser.Id;
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

          public ActionResult Logout()
          {
               Session.Clear();
               Session.Abandon();

               return RedirectToAction("Index", "Home");
          }

          public ActionResult ForgotPassword()
          {
               return View();
          }

          [HttpPost]
          public ActionResult ForgotPassword(string email)
          {
              var user = _userServices.GetUserByEmail(email);
               if (user != null)
               {
                    return RedirectToAction("ResetPassword", new { email });
               }
               else
               {
                    ModelState.AddModelError("", "Email not found");
                    return View();
               }
          }
          public ActionResult ResetPassword(string email)
          {
               ViewBag.Email = email;
               return View();
          }

          [HttpPost]
          public ActionResult ResetPassword(string email, string newPassword)
          {
              var user = _userServices.GetUserByEmail(email);
               if (user != null)
               {
                    var passwordReseted = _userServices.UpdateUserPassword(user, newPassword);
                    if (passwordReseted)
                    {
                         if (Session == null)
                         {
                              return RedirectToAction("Login");
                         } else { 
                              return RedirectToAction("UserDashboard");
                         }

                    } else {
                         ModelState.AddModelError("", "Password reset failed");
                         return View();
                    }

               }
               else
               {
                    ModelState.AddModelError("", "Email not found");
                    return View();
               }
          }

          [HttpGet]
          public ActionResult EditUserProfile()
          {
               if (Session == null) {

                    return RedirectToAction("AuthPage", "Home");

               } else if (Session["UserRole"]?.ToString() == "Admin"){

                    return RedirectToAction("AdminDashboard", "Admin");

               } else {  
                    var user = _userServices.GetUserById((int)Session["UserId"]);
                    if (user != null)
                    {
                         var model = new EditUserProfileDTO
                         {
                              Id = user.Id,
                              UserName = user.Name,
                              PhoneNumber = user.PhoneNumber,
                              Email = user.Email,
                              FullName = user.FullName,
                         };
                         return View(model);
                    }
                    else
                    {
                         ModelState.AddModelError("", "User not found");
                         return RedirectToAction("AuthPage", "Home");
                    }
               }

                   
          }

          [HttpPost]
          public ActionResult EditUserProfile(EditUserProfileDTO model, HttpPostedFileBase ProfilePicture)
          {
               if (Session == null)
               {
                    return RedirectToAction("AuthPage", "Home");
               }
               else if (Session["UserRole"].ToString() == "Admin")
               {
                    return RedirectToAction("AdminDashboard", "Admin");
               }
               else
               {
                    var user = _userServices.GetUserById((int)Session["UserId"]);
                    if (user != null)
                    {
                         user.Name = model.UserName;
                         user.PhoneNumber = model.PhoneNumber;
                         user.Email = model.Email;
                         user.FullName = model.FullName;
                         if (ProfilePicture != null && ProfilePicture.ContentLength > 0)
                         {
                              using (var binaryReader = new BinaryReader(ProfilePicture.InputStream))
                              {
                                   user.ProfilePicture = binaryReader.ReadBytes(ProfilePicture.ContentLength);
                              }
                         }
                              bool result = _userServices.UpdateUser(user);
                         if (result)
                         {
                              return RedirectToAction("UserDashboard");
                         }
                         else
                         {
                              ModelState.AddModelError("", "Failed to update profile");
                              return View(model);
                         }
                    }
                    else
                    {
                         ModelState.AddModelError("", "User not found");
                         return RedirectToAction("AuthPage", "Home");
                    }
               }
          }
     }
}