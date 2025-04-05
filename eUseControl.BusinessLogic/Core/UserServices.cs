using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.DBModel;

namespace eUseControl.BusinessLogic.Core
{
    public class UserServices: IUserServices
    {

          public bool RegisterUser(User user)
          {
               using (var context = new UserContext())
               {
                  if ((context.Users.Any(u => u.Email == user.Email) || (context.Users.Any(u => u.Name == user.Name)))){
                    return false;
                  }

               context.Users.Add(user);
               context.SaveChanges();
               return true;
               }
              
          }

          public User LoginUser(User user)
          {
               using (var context = new UserContext())
               {
                    var UserExists = context.Users.FirstOrDefault(u => u.Name == user.Name && u.Password == user.Password);
                    if (UserExists != null)
                    {
                         return UserExists;
                    }
                    else
                    {
                         return null;
                    }
               }
          }

          public bool RemoveUser(string name, string email)
          {
               return true;
          }
     }
}
