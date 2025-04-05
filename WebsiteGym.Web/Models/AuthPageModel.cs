using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteGym.Web.Models
{
     public class AuthPageModel
     {
          public UserLogData Login { get; set; }
          public UserRegData Register { get; set; }
     }
}