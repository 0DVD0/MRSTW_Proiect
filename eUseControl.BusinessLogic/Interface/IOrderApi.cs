using System.Collections.Generic;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.Interface
{
    public interface IOrderApi
    {
        void CreateOrder(Order order);
        IEnumerable<Order> GetAllOrders();
    }
}