using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;


namespace eUseControl.BusinessLogic.Core
{
    public class AdminApi : IMembershipApi
    {
        private List<Coach> coachList = new List<Coach>();

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

            using (var context = new MembershipContext())
            {
                MDbTable membership = new MDbTable()
                {
                    Name = name,
                    Price = price,
                };

                context.Memberships.Add(membership);
                context.SaveChanges();
            }
        }

        public void RemoveMembership(int membershipId)
        {
            if (membershipId < 0)
            {
                return;
            }

            using (var context = new MembershipContext())
            {
                var membership = context.Memberships.FirstOrDefault(m => m.Id == membershipId);

                if (membership != null)
                {
                    context.Memberships.Remove(membership);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateMembership(int membershipId, string name, decimal price, DateTime startDate, DateTime endDate)
        {
            if (membershipId < 0)
            {
                return;
            }

            using (var context = new MembershipContext())
            {
                var membership = context.Memberships.FirstOrDefault(m => m.Id == membershipId);

                if (membership != null)
                {
                    membership.Name = name;
                    membership.Price = price;

                    context.SaveChanges();
                }
            }
        }

        public void ApplyDiscount(int membershipId, decimal discountAmount, decimal newPrice)
        {
            if (membershipId < 0 || discountAmount < 0)
            {
                return;
            }

            using (var context = new MembershipContext())
            {

                var membership = context.Memberships.FirstOrDefault(m => m.Id == membershipId);
                if (membership != null)
                {
                    membership.Price = membership.Price - discountAmount >= 0 ? membership.Price - discountAmount : 0;
                    context.SaveChanges();
                }
            }
        }


        public MDbTable GetMembershipById(int membershipId)
        {
            if (membershipId < 0)
            {
                return null;
            }

            using (var context = new MembershipContext())
            {
                return context.Memberships.FirstOrDefault(m => m.Id == membershipId);
            }
        }

        public List<MDbTable> GetAllMemberships()
        {
            using (var context = new MembershipContext())
            {
                return context.Memberships.ToList();
            }
        }


        public void CreateCoach(string name, string surname, DateTime birthdate)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(surname))
            {
                return;
            }

            if (birthdate > DateTime.Now.AddYears(-18))
            {
                return;
            }

            Coach coach = new Coach()
            {
                Name = name,
                Surname = surname,
                Birthdate = birthdate
            };

            coachList.Add(coach);
        }

        public void RemoveCoach(int coachId)
        {
            if (coachId < 0)
            {
                return;
            }

            foreach (Coach coach in coachList)
            {
                if (coach.Id == coachId)
                {
                    coachList.Remove(coach);
                }
            }
        }

        public Coach GetCoachById(int coachId)
        {
            if (coachId < 0)
            {
                return null;
            }

            foreach (Coach coach in coachList)
            {
                if (coach.Id == coachId)
                {
                    return coach;
                }
            }
            return null;
        }

        public void UpdateCoach(int coachId, string name, string surname, DateTime birthdate)
        {
            if (coachId < 0)
            {
                return;
            }

            foreach (Coach coach in coachList)
            {
                if (coach.Id == coachId)
                {
                    coach.Name = name;
                    coach.Surname = surname;
                    coach.Birthdate = birthdate;

                    return;
                }
            }
        }

        public List<Coach> GetAll()
        {
            return coachList;
        }
    }
}