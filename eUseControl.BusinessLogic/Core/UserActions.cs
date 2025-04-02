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
          public List<UDBTable> userList = new List<UDBTable>();

          public void UserCreate(string name, string email, string password)
          {
               UDBTable user = new UDBTable();
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
               foreach (UDBTable user in userList) 
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
               foreach (UDBTable user in userList)
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
