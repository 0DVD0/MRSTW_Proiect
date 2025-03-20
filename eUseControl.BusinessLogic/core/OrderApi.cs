using System;
using System.Collections.Generic;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.Core
{
    public class OrderApi : IOrderApi
    {
        private List<Order> orders = new List<Order>();

        public void CreateOrder(int Id, int membershipId, DateTime orderDate, int totalPrice, int userId)
        {
     
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }
    }
}