using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteGym.Web.Models
{
    public class ActiveMembershipViewModel
    {
        public int MembershipId { get; set; }
        public string UserName { get; set; }
        public string MembershipName { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }
    }

}