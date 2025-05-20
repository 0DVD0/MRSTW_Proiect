using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using eUseControl.Domain.Entities.BaseEntities;

namespace WebsiteGym.Web.Models
{
    public class FeedbackModel : BaseEntity
    {
        [Required(ErrorMessage = "Username is required!")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message can not be empty")]
        [Display(Name = "Feedback")]
        public string FeedbackMessage { get; set; }
    }
}