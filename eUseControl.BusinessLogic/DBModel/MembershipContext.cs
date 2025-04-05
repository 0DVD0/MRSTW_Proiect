using System;
using System.Collections.Generic;
using eUseControl.Domain.Entities;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eUseControl.BusinessLogic.DBModel
{
    public class MembershipContext : DbContext
    {
        public MembershipContext() : base("name=eUseControl")
        {
        }
        public virtual DbSet<MDbTable> Memberships { get; set; }
        public virtual DbSet<ODbTable> Orders { get; set; }

    }
}
