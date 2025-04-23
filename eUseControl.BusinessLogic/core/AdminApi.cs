using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Membership;


namespace eUseControl.BusinessLogic.Core
{
    public class AdminApi : IMembershipApi
    {
        private List<Coach> coachList = new List<Coach>();

        public void CreateMembership(NewMembershipDto membership)
        { 
            if (membership.price < 0)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(membership.membershipName))
            {
                return;
            }

            using (var context = new MembershipContext())
            {
                MDbTable newMembership = new MDbTable()
                {
                    MembershipName = membership.membershipName,
                    Price = membership.price,
                    Details = membership.details
                };

                context.Memberships.Add(newMembership);
                context.SaveChanges(); 
            }
        }

        public void RemoveMembership(NewMembershipDto membership)
        {
            if (membership.Id < 0)
            {
                return;
            }

            using (var context = new MembershipContext())
            {
                var membershipToRemove = context.Memberships.FirstOrDefault(m => m.Id == membership.Id);

                if (membershipToRemove != null)
                {
                    context.Memberships.Remove(membershipToRemove);
                    context.SaveChanges();
                }
            }
        }

        public void EditMembership(NewMembershipDto membership)
        {
            if (membership.Id < 0)
            {
                return;
            }

            using (var context = new MembershipContext())
            {
                var membershipToEdit = context.Memberships.FirstOrDefault(m => m.Id == membership.Id);

                if (membership != null)
                {
                    membershipToEdit.MembershipName = membership.membershipName;
                    membershipToEdit.Price = membership.price;
                    membershipToEdit.Details = membership.details;

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