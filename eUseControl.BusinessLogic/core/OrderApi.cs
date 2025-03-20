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
            // TODO: implement some logic
            throw new NotImplementedException();
        }

        public void CreateOrder(int Id, int membershipId, DateTime orderDate, int totalPrice, int userId)
        {
            Console.WriteLine("");
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }
    }
}