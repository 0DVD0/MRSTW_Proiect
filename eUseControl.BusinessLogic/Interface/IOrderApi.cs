using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.Core;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.Interface
{
    public interface IOrderApi
    {
        void CreateOrder(Order order);
        IEnumerable<Order> GetAllOrders();
    }
}