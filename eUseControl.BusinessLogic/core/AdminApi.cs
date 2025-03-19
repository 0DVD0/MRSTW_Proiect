using System;
using System.Collections.Generic;
using System.Linq;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.Core
{
    public class AdminApi : IMembershipApi, IOrderApi
    {
        private List<Membership> memberships = new List<Membership>();
        private List<Order> orders = new List<Order>();

        public void CreateMembership(User user, MembershipType type, decimal price, DateTime startDate, bool autoRenewal)
        {
            if (user == null || string.IsNullOrEmpty(type.ToString()))
            {
                throw new MembershipException("Invalid membership details");
            }

            var membership = new Membership
            {
                UserId = user.Id,
                Type = type,
                Price = price,
                StartDate = startDate,
                EndDate = autoRenewal ? startDate.AddYears(1) : startDate.AddMonths(1),
                Status = MembershipStatus.Active,
                TrainerSessions = null,
                Discounts = false
            };

            memberships.Add(membership);
        }

        public void RenewMembership(int membershipId)
        {
            var membership = memberships.FirstOrDefault(m => m.Id == membershipId);
            if (membership == null)
            {
                throw new MembershipException("Membership not found");
            }

            if (membership.Status == MembershipStatus.Expired)
            {
                membership.EndDate = DateTime.Now.AddMonths(1);
                membership.Status = MembershipStatus.Active;
            }
        }

        public void CancelMembership(int membershipId)
        {
            var membership = memberships.FirstOrDefault(m => m.Id == membershipId);
            if (membership == null)
            {
                throw new MembershipException("Membership not found");
            }

            membership.Status = MembershipStatus.Canceled;
        }

        public MembershipStatus CheckMembershipStatus(int userId)
        {
            var membership = memberships.FirstOrDefault(m => m.UserId == userId);
            if (membership == null)
            {
                throw new MembershipException("Membership not found");
            }

            return membership.Status;
        }

        public Membership GetMembershipDetails(int userId)
        {
            var membership = memberships.FirstOrDefault(m => m.UserId == userId);
            if (membership == null)
            {
                throw new MembershipException("Membership not found");
            }

            return membership;
        }

        public void ApplyDiscount(int membershipId, decimal discountAmount)
        {
            var membership = memberships.FirstOrDefault(m => m.Id == membershipId);
            if (membership == null)
            {
                throw new MembershipException("Membership not found");
            }

            membership.Price -= discountAmount;
        }

        public void UpgradeMembership(int membershipId, MembershipType newType, decimal newPrice)
        {
            var membership = memberships.FirstOrDefault(m => m.Id == membershipId);
            if (membership == null)
            {
                throw new MembershipException("Membership not found");
            }

            membership.Type = newType;
            membership.Price = newPrice;
        }

        public List<Membership> GetExpiringMemberships()
        {
            return memberships
                .Where(m => m.EndDate <= DateTime.Now.AddDays(30) && m.Status == MembershipStatus.Active)
                .ToList();
        }

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

    public class MembershipException : Exception
    {
        public MembershipException(string message) : base(message) { }
    }
}