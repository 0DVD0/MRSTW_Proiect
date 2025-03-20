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
          public List<User> userList = new List<User>();

          public void UserCreate(string name, string email, string password)
          {
               User user = new User();
               {
                    user.Name = name;
                    user.Email = email;
                    user.Password = password;
               }

               userList.Add(user);
               return;
          }

          public void UserDelete(string name, string password)
          {
               foreach (User user in userList) 
               {
                    if ((user.Name == name) & (user.Password == password))
                    {
                         userList.Remove(user);
                         return;
                    }
               }
               return;
          }

          public bool UserExists(string name, string password)
          {
               foreach (User user in userList)
               {
                    if ((user.Name == name) & (user.Password == password))
                    {
                         return true;
                    }
               }
               return false;
          }
     }
}
