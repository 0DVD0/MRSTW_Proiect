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
        private List<MDbTable> membershipsList = new List<MDbTable>();
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


            MDbTable membership = new MDbTable()
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


            foreach (MDbTable membership in membershipsList)
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

            foreach (MDbTable membership in membershipsList)
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

            foreach (MDbTable membership in membershipsList)
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

        public MDbTable GetMembershipById(int membershipId)
        {
            if (membershipId < 0)
            {
                return null;
            }

            foreach (MDbTable membership in membershipsList)
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

            if (userId < 0 || membershipId == 0 || Id == 0 || totalPrice < 0 || userId < 0) { return; }

            Order newOrder = new Order
            {
                Id = Id,
                MembershipId = membershipId,
                OrderDate = orderDate,
                TotalPrice = totalPrice,
                UserId = userId
            };

            ordersList.Add(newOrder);
        }


        public List<Order> GetAllOrders()
        {
            return ordersList;
        }

        public bool DeleteOrder(int orderId)
        {
            if (orderId < 0)
            {
                return false;
            }

            Order orderToRemove = ordersList.FirstOrDefault(o => o.Id == orderId);

            if (orderToRemove != null)
            {
                ordersList.Remove(orderToRemove);
                return true;
            }
            return false;
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