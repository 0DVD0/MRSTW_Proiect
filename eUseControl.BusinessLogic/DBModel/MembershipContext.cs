using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.DBModel
{
    internal class MembershipContext : DbContext
    {
        public MembershipContex() : base("name=eUseControl")
        {
        }
        public virtual DbSet<Membership> Memberships { get; set; }

    }
}
