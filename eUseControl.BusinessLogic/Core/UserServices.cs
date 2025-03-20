using eUseControl.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Core
{
    public class UserServices: IUserServices
    {
          private readonly IUserActions _userAction;

          public void RegisterUser(string name, string email, string password)
          {
               if (_userAction.UserExists(name, password))
               {
                    return;
               }
               _userAction.UserCreate(name, email, password);
               return; 
          }

          public string AuthUser(string name, string password)
          {
               // User authorization logic
               return null;
          }
     }
}
