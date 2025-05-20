using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities;
using WebsiteGym.Web.Models;

namespace WebsiteGym.Web.Controllers
{
    public class FeedbackController : Controller
    {

        private readonly FeedbackContext _feedback;
        public FeedbackController()
        {
            _feedback = new FeedbackContext();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFeedback(FeedbackModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = new FeedbackDbTable
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        FeedbackMessage = model.FeedbackMessage,
                    };

                    _feedback.Feedbacks.Add(entity);
                    _feedback.SaveChanges();
                    System.Diagnostics.Debug.WriteLine("alksamdlkadfnmleeeeeeeeeeee");

                    return RedirectToAction("ThankYou", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error occured");
                }
            }
            return View(model);
        }

        public ActionResult ThankYou()
        {
            return View();
        }

    }
}