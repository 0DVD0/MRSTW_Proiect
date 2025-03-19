using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.BaseEntities;

namespace eUseControl.Domain.Entities
{
    public class Membership : BaseEntity
    {
        public string Name { get; set; }
        // Timespan is for months count for membership
        public TimeSpan TimeSpan { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public MembershipType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MembershipStatus Status { get; set; }
        public int? TrainerSessions { get; set; }
        public bool Discounts { get; set; }
    }

    public enum MembershipType
    {
        Basic,
        Standard,
        Premium,
        Elite,
        Friends
    }

    public enum MembershipStatus
    {
        Active,
        Expired,
        Canceled
    }
}
