using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eUseControl.BusinessLogic.Interface;
using System.Web.Mvc;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities;
using WebsiteGym.Web.Models;

namespace WebsiteGym.Web.Controllers
{
     public class FeedbackController : Controller
     {

          private readonly IFeedback _feedbackApi;

          public FeedbackController()
          {
               var _bl = new BussinesLogic();
               _feedbackApi = _bl.GetFeedbackApi();
          }

          public ActionResult Contact()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult CreateFeedback(FeedbackModel model)
          {
               if (ModelState.IsValid) {
                    FeedbackDbTable feedback = new FeedbackDbTable()
                    {
                         UserName = model.UserName,
                         Email = model.Email,
                         FeedbackMessage = model.FeedbackMessage
                    };

                    var created = _feedbackApi.CreateFeedback(feedback);
                    if (created)
                    {
                         return RedirectToAction("ThankYou");
                    }
                    else
                    {
                         ModelState.AddModelError("", "Failed to submit feedback.");
                         return View(model);
                    }

               } else { 

                    ModelState.AddModelError("", "Invalid feedback data.");
               return View(model);
               }
          }
     

        public ActionResult ThankYou()
        {
            return View();
        }

    }
}