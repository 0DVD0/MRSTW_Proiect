using System;
using System.Collections.Generic;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Order;

namespace eUseControl.BusinessLogic.Interface
{
    public interface IOrderApi
    {
        List<ODbTable> GetAllOrders();
        decimal? GetTotalIncome();
        bool CreateOrder(ODbTable order);
    }
}