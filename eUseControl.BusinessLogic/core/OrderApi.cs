using System;
using System.Collections.Generic;
using System.Linq;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Order;

namespace eUseControl.BusinessLogic.Core
{
    public class OrderApi : UserServices, IOrderApi
    {
        private List<ODbTable> orders = new List<ODbTable>();

        public bool CreateOrder(NewOrderDto order)
        {
            return CreateNewOrderAction(order);
        }

        public List<ODbTable> GetAllOrders()
        {
            using (var context = new OrderContext())
            {
                return context.Orders.ToList();
            }
        }

        public void ApplyDiscount(NewOrderDto order, string discountCode, decimal discountAmount)
        {
            if (string.IsNullOrEmpty(discountCode))
            {
                throw new ArgumentException("Discount code cannot be empty.");
            }

            using (var context = new DiscountContext())
            {
                var discount = context.DiscountCodes
                                      .FirstOrDefault(d => d.DiscountCode == discountCode);

                if (discount == null)
                {
                    throw new ArgumentException("Invalid discount code.");
                }

            
                discountAmount = (order.totalPrice * discount.DiscountPercentage) / 100;
                
                if (discountAmount > order.totalPrice)
                {
                    discountAmount = order.totalPrice;
                }

                order.totalPrice -= discountAmount;

                order.discountAmount = discountAmount;

                context.SaveChanges();
            }
        }
    }

}
   