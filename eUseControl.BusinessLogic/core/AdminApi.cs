using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;


namespace eUseControl.BusinessLogic.Core
{
    public class AdminApi : IMembershipApi, IOrderApi
    {
        private List<Membership> membershipsList = new List<Membership>();
        private List<Order> ordersList = new List<Order>();

        public void CreateMembership(string name, decimal price, DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                return;
            }

            if (price < 0)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }


            Membership membership = new Membership()
            {
                Price = price,
                Name = name,
                StartDate = startDate,
                EndDate = endDate
            };

            membershipsList.Add(membership);
        }

        public void RemoveMembership(int membershipId)
        {
            if (membershipId < 0)
            {
                // todo refactor this
                return;
            }


            foreach (Membership membership in membershipsList)
            {
                if (membership.Id == membershipId)
                {
                    membershipsList.Remove(membership);
                }
            }
        }

        public void ApplyDiscount(int membershipId, decimal discountAmount)
        {

        }

        public void UpdateMembership(int membershipId, string name, decimal price, DateTime startDate, DateTime endDate)
        {
            // validate 
            if (membershipId < 0)
            {
                return;
            }

            foreach (Membership membership in membershipsList)
            {
                if (membership.Id == membershipId)
                {
                    membership.Name = name;
                    membership.Price = price;
                    membership.StartDate = startDate;
                    membership.EndDate = endDate;

                    return;
                }
            }
        }

        public Membership GetMembershipById(int membershipId)
        {
            if (membershipId < 0)
            {
                return null;
            }

            foreach (Membership membership in membershipsList)
            {
                if (membership.Id == membershipId)
                {
                    return membership;
                }
            }
            return null;
        }


        public void CreateOrder(int Id, int membershipId, DateTime orderDate, int totalPrice, int userId)
        {

            Order order = new Order()
            {
                MembershipId = membershipId,    
                OrderDate = orderDate,
                TotalPrice = totalPrice,
                UserId = userId
            };
            
            ordersList.Add(order);
        }

        public List<Order> GetAllOrders()
        {
            return ordersList;
        }
    }
}