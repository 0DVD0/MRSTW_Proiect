using System;
using System.Collections.Generic;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Order;

namespace eUseControl.BusinessLogic.Interface
{
    public interface IOrderApi
    {
        List<ODbTable> GetAllOrders();
        bool CreateOrder(NewOrderDto order);

        void ApplyDiscount(NewOrderDto order);
    }
}