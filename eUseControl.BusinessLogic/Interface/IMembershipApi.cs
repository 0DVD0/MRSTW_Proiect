using eUseControl.Domain.Entities;
using System.Collections.Generic;
using System;
using eUseControl.BusinessLogic.Core;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Interface
{
    public interface IMembershipApi
    {
        void CreateMembership(User user, MembershipType type, decimal price, DateTime startDate, bool autoRenewal);

        void RenewMembership(int membershipId);
        void CancelMembership(int membershipId);
        MembershipStatus CheckMembershipStatus(int userId);
        Membership GetMembershipDetails(int userId);
        void ApplyDiscount(int membershipId, decimal discountAmount);
        void UpgradeMembership(int membershipId, MembershipType newType, decimal newPrice);
        List<Membership> GetExpiringMemberships();
    }
}
