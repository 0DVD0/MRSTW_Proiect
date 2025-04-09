using System;
using System.Collections.Generic;
using System.Linq;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.Core
{
    public class OrderApi : IOrderApi
    {
        private List<ODbTable> orders = new List<ODbTable>();

        public bool CreateOrder(int Id, int membershipName, DateTime orderDate, int totalPrice, int userName)
        {
            if (Id == 0 || totalPrice < 0)
            {
                return false;
            }

            using (var context = new OrderContext())
            {
                ODbTable newOrder = new ODbTable
                {
                    MembershipName = membershipName,
                    OrderDate = orderDate,
                    TotalPrice = totalPrice,
                    UserName = userName
                };

                context.Orders.Add(newOrder);
                context.SaveChanges();
            }
            return true;
        }

        public List<ODbTable> GetAllOrders()
        {
            using (var context = new OrderContext())
            {
                return context.Orders.ToList();
            }
        } 
        public bool DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}