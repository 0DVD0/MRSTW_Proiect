using System;

namespace eUseControl.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int MembershipId { get; set; }
        public DateTime OrderDate { get; set; }

        public int TotalPrice { get; set; }
        public int UserId { get; set; }
    }
}


