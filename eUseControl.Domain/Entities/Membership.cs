using System;
using eUseControl.Domain.Entities.BaseEntities;

namespace eUseControl.Domain.Entities
{
    public class Membership : BaseEntity
    {
        public string Name { get; set; }
        // Timespan is for months count for membership
        public TimeSpan TimeSpan { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? DiscountPrice { get; set; }
    }
}
