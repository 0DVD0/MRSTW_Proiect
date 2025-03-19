using System;
using System.Collections.Generic;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.Core
{
    public class OrderApi : IOrderApi
    {
        private List<Order> orders = new List<Order>();

        public void CreateOrder(Order order)
        {
            if (order == null || order.MembershipId <= 0)
            {
                throw new OrderException("Invalid order");
            }
            orders.Add(order);
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }
    }
    public class OrderException : Exception
    {
        public OrderException(string message) : base(message) { }
    }
}