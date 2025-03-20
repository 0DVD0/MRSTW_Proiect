using System;
using System.Collections.Generic;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.Interface
{
    public interface IOrderApi
    {
        void CreateOrder(int Id, int membershipId, DateTime orderDate, int totalPrice, int userId);
        List<Order> GetAllOrders();
    }
}