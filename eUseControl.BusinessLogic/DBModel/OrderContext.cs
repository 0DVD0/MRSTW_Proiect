using System.Data.Entity;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.DBModel
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("GymMembershipDb")
        {
        }
        public virtual DbSet<ODbTable> Orders { get; set; }
    }
}
