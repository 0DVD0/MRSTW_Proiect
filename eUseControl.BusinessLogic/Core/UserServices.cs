using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Helper.AssistingLogic;
using Microsoft.Win32;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Order;

namespace eUseControl.BusinessLogic.Core
{
    public class UserServices: IUserServices
    {
          public UserMembership GetUserMembershipById(int id)
          {
               using (var context = new UserContext())
               {
                    return context.UserMemberships.FirstOrDefault(u => u.Id == id);
               }
          }

          public User GetUserById(int id)
          {
               using (var context = new UserContext())
               {
                    return context.Users.FirstOrDefault(u => u.Id == id);
               }
          }

          public bool RegisterUser(User user)
          {
               var helper = new UserHelper();
               using (var context = new UserContext())
               {
                  if ((context.Users.Any(u => u.Email == user.Email) || (context.Users.Any(u => u.Name == user.Name)))){
                    return false;
                  }

                  user.Password = helper.PasswordHash(user.Password);
                  context.Users.Add(user);
                  context.SaveChanges();
                  return true;
               }
              
          }

          public User LoginUser(User user)
          {
               var helper = new UserHelper();
               var hashedPassword= helper.PasswordHash(user.Password);
               using (var context = new UserContext())
               {
                    var UserExists = context.Users.FirstOrDefault(u => u.Name == user.Name && u.Password == hashedPassword);
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

        public bool CreateNewOrderAction(NewOrderDto order)
        {
            if (order.Id == 0 || order.totalPrice < 0)
            {
                return false;
            }

            using (var context = new OrderContext())
            {
                ODbTable newOrder = new ODbTable
                {
                    MembershipName = order.membershipName,
                    OrderDate = order.orderDate,
                    TotalPrice = order.totalPrice,
                    UserName = order.userName
                };

                context.Orders.Add(newOrder);
                context.SaveChanges();
            }
            return true;
        }
     }
}
