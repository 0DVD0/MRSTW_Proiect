using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteGym.Web.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int MembershipId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }
        public int UserId { get; set; }
    }
}