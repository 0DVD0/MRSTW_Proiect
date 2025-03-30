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

        public void ApplyDiscount(int membershipId, decimal discountAmount, decimal newPrice)
        {
            if (membershipId < 0 || discountAmount < 0)
            {
                return;
            }

            foreach (Membership membership in membershipsList)
            {
                if (membership.Id == membershipId)
                {
                    newPrice = membership.Price - discountAmount;
                }
                membership.Price = newPrice >= 0 ? newPrice : 0;
                return;
            }
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