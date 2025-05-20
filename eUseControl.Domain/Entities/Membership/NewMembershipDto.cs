using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.BaseEntities;

namespace eUseControl.Domain.Entities.Membership
{
     public class NewMembershipDto
    {
        public int Id { get; set; }
        public string membershipName { get; set; }

        public decimal price { get; set; }

        public string details { get; set; }
    }
}
