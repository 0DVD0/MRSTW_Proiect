using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteGym.Web.Models
{
     public class UserRegData
     {
          [Required(ErrorMessage ="Username is required")]
          [StringLength(50, MinimumLength = 5, ErrorMessage = "Username is not valid")]
          public string UserName { get; set; }
          [Required(ErrorMessage = "Email is required")]
          [StringLength(50, MinimumLength = 11, ErrorMessage = "Email is not valid")]
          public string Email { get; set; }
          [Required(ErrorMessage = "Password is required")]
          [StringLength(50, MinimumLength = 8, ErrorMessage = "Password is not valid")]
          public string Password { get; set; }
     }
}