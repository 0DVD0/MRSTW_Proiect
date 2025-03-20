using eUseControl.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Core
{
    
     internal class UserActions : IUserActions
     {
          
      public bool UserCreate(string name, string email, string password)
          {
               // User creation logic
               return true;
          }

          public bool UserDelete(string name, string password)
          {
               // User deletion logic
               return true;
          }

          public bool UserExists(string name, string password)
          {
               // User existence logic
               return true;
          }
     }
}
