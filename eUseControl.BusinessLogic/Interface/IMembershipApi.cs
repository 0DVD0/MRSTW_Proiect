using System;
using System.Collections.Generic;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Order;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.Membership;

namespace eUseControl.BusinessLogic.Interface
{
    public interface IMembershipApi
    {
        List<MDbTable> GetAllMemberships();
        void CreateMembership(NewMembershipDto membership);
        void RemoveMembership(NewMembershipDto membership);
        MDbTable GetMembershipById(int Id);
        bool EditMembership(NewMembershipDto membership);
        List<MDbTable> GetTop3Memberships();


     }
}
