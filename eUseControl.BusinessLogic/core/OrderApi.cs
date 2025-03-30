using System;
using System.Collections.Generic;
using System.Linq;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.Core
{
    public class OrderApi : IOrderApi
    {
        private List<Order> orders = new List<Order>();

        public void CreateOrder(int Id, int membershipId, DateTime orderDate, int totalPrice, int userId)
        {

            if (userId < 0 || membershipId == 0 || Id == 0 || totalPrice < 0 || userId < 0) { return; }

            Order newOrder = new Order
            {
                Id = Id,
                MembershipId = membershipId,
                OrderDate = orderDate,
                TotalPrice = totalPrice,
                UserId = userId
            };

            orders.Add(newOrder);
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }

        public bool DeleteOrder(int orderId)
        {
            if (orderId < 0)
            {
                return false;
            }

            Order orderToRemove = orders.FirstOrDefault(o => o.Id == orderId);

            if (orderToRemove != null)
            {
                orders.Remove(orderToRemove);
                return true;
            }
            return false;
        }
    }
}